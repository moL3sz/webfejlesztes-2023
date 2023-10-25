using api.API.DTO.User;
using api.BLL.Interfaces;
using api.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace api.BLL.Services {
    public class UserService : IUserService {



        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper) {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserFullDTO> GetUserById(string userId) {
           var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<UserFullDTO>(user);
        }
    }
}
