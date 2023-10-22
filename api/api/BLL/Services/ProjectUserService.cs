using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using AutoMapper;

namespace api.BLL.Services {
    public class ProjectUserService : IProjectUserService {

        private readonly IProjectUserRepository _repo;
        private readonly Mapper _mapper;
        public ProjectUserService(IProjectUserRepository repo) {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectCompactDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            }));
        }

        public Task AddUserToProjectAsync(ProjectUser projectUser) {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId) {
            var projects = await _repo.GetProjectsByUser(userId);
            return _mapper.Map<List<ProjectCompactDTO>>(projects);
        }

        public async Task<List<UserDTO>> GetUsersByProject(long projectId) {
            var users = await _repo.GetUsersByProject(projectId);
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
