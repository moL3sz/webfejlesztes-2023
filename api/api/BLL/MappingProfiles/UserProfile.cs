using api.API.DTO.Auth;
using api.DAL.Entities;
using AutoMapper;

namespace api.BLL.MappingProfiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
