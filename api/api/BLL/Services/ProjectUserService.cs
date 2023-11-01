using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;
using api.API.Hubs;
using api.BLL.Enums;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace api.BLL.Services {
    public class ProjectUserService : IProjectUserService {

        private readonly IProjectUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;
        private readonly IUserHelper _userHelper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProjectUserService> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHubContext<NotificationHub> _hub;
        private readonly IProjectRepository _projectRepository;



        public ProjectUserService(
            IProjectUserRepository repo,
            IRecordInfoHelper recordInfoHelper,
            IMapper mapper,
            IUserHelper userHelper,
            UserManager<User> userManager,
            ILogger<ProjectUserService> logger,
            RoleManager<IdentityRole> roleManager,
            IHubContext<NotificationHub> hub,
            IProjectRepository projectRepository) {

            _repo = repo;
            _recordInfoHelper = recordInfoHelper;
            _mapper = mapper;
            _userHelper = userHelper;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _hub = hub;
            _projectRepository = projectRepository;
        }

        private async Task SendNotificationToUser(string userId, ProjectCompactDTO project) {
            await _hub.Clients.Group(userId).SendAsync("notify", project);

        }


        public async Task AcceptProject(int projectId) {
            var user = await _userHelper.GetCurrentUser();
            if (user == null) {
                throw new UnauthorizedAccessException();
            }

            await _repo.AcceptProject(user.Id, projectId);

            // create role for the user
            var roleName = $"{projectId}_{RoleEnum.DEVELOPER}";
            await _roleManager.CreateAsync(new IdentityRole { Name = roleName, ConcurrencyStamp = Guid.NewGuid().ToString() });
            await _userManager.AddToRoleAsync(user, roleName);

        }

        public async Task AddUserToProjectAsync(ProjectUserDTO dto) {
            var user = await _userHelper.GetCurrentUser();
            if (user == null) {
                throw new UnauthorizedAccessException();
            }
            var entity = _mapper.Map<ProjectUser>(dto);
            _recordInfoHelper.SetNewRecordInfo(ref entity);
            await _repo.AddUserToProjectAsync(entity);

        }



        public async Task<List<ProjectCompactDTO>> GetPendingProjectByUser(string userId) {
            var projects = await _repo.GetProjectsByUser(userId);
            return _mapper.Map<List<ProjectCompactDTO>>(projects.Where(x => !x.Accepted).Select(x => x.Project).ToList());
        }
        public async Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId) {
            var projects = await _repo.GetProjectsByUser(userId);
            return _mapper.Map<List<ProjectCompactDTO>>(projects.Where(x => x.Accepted).Select(x => x.Project).ToList());
        }

        public async Task<List<UserDTO>> GetUsersByProject(int projectId) {
            var users = await _repo.GetUsersByProject(projectId);
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task InvitePeople(MembersDTO members, int projectId) {

            var users = new List<ProjectUser>();
            var project = _mapper.Map<ProjectCompactDTO>(await _projectRepository.GetById(projectId));
            foreach (var email in members.Emails) {
                var currentUser = await _userManager.FindByEmailAsync(email);
                if (currentUser == null) {
                    _logger.LogWarning($"Cannot invite user with email {email}");
                    continue;
                }
                var projectUser = _mapper.Map<ProjectUser>(new ProjectUserDTO { UserId = currentUser.Id, ProjectId = projectId });
                _recordInfoHelper.SetNewRecordInfo(ref projectUser);
                users.Add(projectUser);
               await  this.SendNotificationToUser(currentUser.Id, project);


            }
            await _repo.BulkAddUsersToProjectAsync(users);

        }
    }
}
