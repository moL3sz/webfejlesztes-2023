using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;
using api.DAL.Entities;
using AutoMapper;

namespace api.BLL.MappingProfiles {
    public class ProjectUserProfile : Profile {

        public ProjectUserProfile() {
            CreateMap<ProjectUser, ProjectUserDTO>().ReverseMap();
        }
    }
}
