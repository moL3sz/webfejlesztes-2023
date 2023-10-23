using api.API.DTO.Project;
using api.API.DTO.Ticket;
using api.DAL.Entities;
using AutoMapper;

namespace api.BLL.MappingProfiles {
    public class TicketProfile: Profile {

        public TicketProfile() {
            CreateMap<Ticket, TicketFullViewDTO>().ReverseMap();
            CreateMap<Ticket, TicketCompactDTO>().ReverseMap();
            CreateMap<TicketModifiableDTO, Ticket>().ReverseMap();
            CreateMap<TicketModifiableDTO, TicketFullViewDTO>().ReverseMap();
        }
    }
}
