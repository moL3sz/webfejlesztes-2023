using api.API.DTO.Common;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;
using api.API.DTO.Ticket;
using api.BLL.Enums;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace api.BLL.Services {
    public class ProjectService : IProjectService {

        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;
        private readonly IProjectUserService _projectUserService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserHelper _userHelper;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketService _ticketService;
        public ProjectService(IProjectRepository repo,
            IRecordInfoHelper recordInfoHelper,
            IMapper mapper, IProjectUserService projectUserService,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IUserHelper userHelper,
            ITicketRepository ticketRepository, ITicketService ticketService) {

            _repo = repo;
            _recordInfoHelper = recordInfoHelper;
            _mapper = mapper;
            _projectUserService = projectUserService;
            _roleManager = roleManager;
            _userManager = userManager;
            _userHelper = userHelper;
            _ticketRepository = ticketRepository;
            _ticketService = ticketService;
        }
        public async Task<List<ProjectCompactDTO>> GetAll() {
            var projects = await _repo.GetAll();
            return _mapper.Map<List<ProjectCompactDTO>>(projects);
        }

        public async Task<ProjectFullDTO> GetById(int Id) {
            return _mapper.Map<ProjectFullDTO>(await _repo.GetById(Id));
        }

        public async Task<ProjectFullDTO> Insert(ProjectFullDTO dto) {

            var entity = _mapper.Map<Project>(dto);
            _recordInfoHelper.SetNewRecordInfo(ref entity);
            entity = await _repo.Insert(entity);

            //Generate roles to current project
            List<string> roleNamesForProject = Enum.GetNames(typeof(RoleEnum))
                  .Select(x => $"{entity.Id}_{x}")
                  .ToList();
            foreach (var roleName in roleNamesForProject) {

                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Add the current project creator User to Admin ROLE!
            var currentUser = await _userHelper.GetCurrentUser();
            if (currentUser == null) {
                throw new UnauthorizedAccessException();
            }
            await _userManager.AddToRoleAsync(currentUser, $"{entity.Id}_{Enum.GetName(RoleEnum.ADMIN)}");


            await _projectUserService.AddUserToProjectAsync(new ProjectUserDTO { UserId = entity.CreatorUserId, ProjectId = entity.Id });
            var newDto = _mapper.Map<ProjectFullDTO>(entity);
            return newDto;


        }

        public async Task<ProjectFullDTO> Update(dynamic dto) {
            var entity = _repo.PartialUpdate<Project>(dto);
            var modifiedDto = _mapper.Map<ProjectFullDTO>(entity);
            return modifiedDto;
        }
        public async Task<ProjectFullDTO> Delete(int id) {
            var deletedEntity = await _repo.Delete(id);
            return _mapper.Map<ProjectFullDTO>(deletedEntity);
        }

        public async Task<List<KanbanDTO>> GetKanbanBoard(int projectId) {

            var tickets = await _ticketRepository.GetByProject(projectId);

            var statusGroups = tickets.GroupBy(x => new { x.Status.Id, x.Status.OrderNumber, x.Status.NameL1 }).Select(x => {

                return new KanbanDTO {
                    Status = new BaseDictionaryDTO { Id = x.Key.Id, NameL1 = x.Key.NameL1, OrderNumber = x.Key.OrderNumber },
                    Tickets = _mapper.Map<List<TicketCompactDTO>>(x)
                };
            });

            return statusGroups.ToList();
        }

        public async Task<List<ProjectBurnDownChartDTO>> GetProjectBurnDownChart(int projectId) {

            var tickets = await _ticketRepository.GetByProject(projectId);
            var project = await _repo.GetById(projectId);

            List<ProjectBurnDownChartDTO> result = new List<ProjectBurnDownChartDTO>();

            // Step 
            for (DateTime currentDate = project.Start; currentDate <= project.End; currentDate = currentDate.AddDays(1)) {
                var tasks = tickets.Where(x => !_ticketService.IsTicketDone(x) && DateTime.Now.AddDays(5) > currentDate).Select(x => x.Title).ToList();
                var expectedRemainging = tickets.Where(x => x.DeadLine > currentDate).Count();
                result.Add(new ProjectBurnDownChartDTO { Day = currentDate, ExpectedRemainingTasksCount = expectedRemainging, RemainingTasks = tasks });
            }
            return result;


        }


    }
}
