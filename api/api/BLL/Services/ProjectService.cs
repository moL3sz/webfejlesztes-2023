using api.API.DTO.Project;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.DAL.Repositories;
using AutoMapper;

namespace api.BLL.Services {
    public class ProjectService : IProjectService {

        private readonly IProjectRepository _repo;
        private readonly Mapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository repo, IRecordInfoHelper recordInfoHelper) {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectFullDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectCompactDTO>().ReverseMap();
                cfg.CreateMap<Project, ProjectModifiableDTO>().ReverseMap();
            }));
            _recordInfoHelper = recordInfoHelper;
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
    }
}
