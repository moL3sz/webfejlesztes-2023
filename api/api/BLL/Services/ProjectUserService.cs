using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using AutoMapper;

namespace api.BLL.Services {
    public class ProjectUserService : IProjectUserService {

        private readonly IProjectUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;
        private readonly IUserHelper _userHelper;



        public ProjectUserService(IProjectUserRepository repo, IRecordInfoHelper recordInfoHelper, IMapper mapper, IUserHelper userHelper) {
            _repo = repo;
            _recordInfoHelper = recordInfoHelper;
            _mapper = mapper;
            _userHelper = userHelper;
        }

        public async Task AcceptProject(int projectId) {
            var user = await _userHelper.GetCurrentUser();
            if (user == null) {
                throw new UnauthorizedAccessException();
            }
            await _repo.AcceptProject(user.Id, projectId);
        }

        public async Task AddUserToProjectAsync(ProjectUserDTO dto) {
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
    }
}
