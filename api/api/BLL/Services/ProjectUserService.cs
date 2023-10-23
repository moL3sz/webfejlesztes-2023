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
        private readonly Mapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;



        public ProjectUserService(IProjectUserRepository repo, IRecordInfoHelper recordInfoHelper) {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectCompactDTO>().ReverseMap();
                cfg.CreateMap<ProjectUser, ProjectUserDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            }));
            _recordInfoHelper = recordInfoHelper;
        }

        public async Task AddUserToProjectAsync(ProjectUserDTO dto) {
            var entity = _mapper.Map<ProjectUser>(dto);
            _recordInfoHelper.SetNewRecordInfo(ref entity);
            await _repo.AddUserToProjectAsync(entity);
        }

        public async Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId) {
            var projects = await _repo.GetProjectsByUser(userId);
            return _mapper.Map<List<ProjectCompactDTO>>(projects);
        }

        public async Task<List<UserDTO>> GetUsersByProject(int projectId) {
            var users = await _repo.GetUsersByProject(projectId);
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
