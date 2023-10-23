using api.API.DTO.Project;
using api.DAL.Entities;
using AutoMapper;

namespace api.BLL.MappingProfiles {
    public class ProjectProfile : Profile {
        public ProjectProfile() {
            CreateMap<Project, ProjectFullDTO>().ReverseMap();
            CreateMap<Project, ProjectCompactDTO>().ReverseMap();
            CreateMap<Project, TicketModifiableDTO>().ReverseMap();
        }
    }
}
