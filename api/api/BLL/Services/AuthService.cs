using api.API.DTO.Auth;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.Shared.Enums;
using api.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.BLL.Services {
    public class AuthService : IAuthService {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserHelper _userHelper;

        public AuthService(UserManager<User> userManager,
            IConfiguration configuration,
            ILogger<AuthService> logger,
            IUserRepository userRepository,
            RoleManager<IdentityRole> roleManager,
            IUserHelper userHelper,
            IMapper mapper
            ) {


            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userHelper = userHelper;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsers() {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);

        }

        #region User Claims
        public async Task<List<Claim>> GetUserClaims() {
            var user = await _userHelper.GetCurrentUser();
            if (user == null) {
                throw new UnauthorizedAccessException();
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.GivenName, user.FirstName[0].ToString().ToUpper() + user.LastName[0].ToString().ToUpper()),
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles) {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            return authClaims;
        }
        private async Task<List<Claim>> GetUserClaims(User user) {

            if (user == null) {
                throw new UnauthorizedAccessException();
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.GivenName, user.FirstName[0].ToString().ToUpper() + user.LastName[0].ToString().ToUpper()),
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles) {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            return authClaims;
        }

        #endregion

        public async Task<string> Login(LoginUserDTO userDTO) {
            _logger.LogInformation("User is going to login" + userDTO.Email);

            var user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
                throw new Exception("Login failed!");
            if (!await _userManager.CheckPasswordAsync(user, userDTO.Password))
                throw new Exception("Login failed!");


            _logger.LogInformation("Successful login!");


            var claims = await this.GetUserClaims(user);
            return GenerateToken(claims);
        }

        public async Task Register(RegisterUserDTO userDTO) {

            _logger.LogInformation("NEW User will be registered with data: " + userDTO.Email);
            var userExists = await _userManager.FindByEmailAsync(userDTO.Email);
            if (userExists != null)
                throw new Exception($"User exists with email: {userDTO.Email}");

            User user = _mapper.Map<User>(userDTO);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            var createUserResult = await _userManager.CreateAsync(user, userDTO.Password);

            if (!createUserResult.Succeeded)
                throw new Exception("User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(Enum.GetName(RoleEnum.DEVELOPER))) {
                await _roleManager.CreateAsync(new IdentityRole(Enum.GetName(RoleEnum.DEVELOPER)));
            }

            await _userManager.AddToRoleAsync(user, Enum.GetName(RoleEnum.DEVELOPER));
            _logger.LogInformation("User created successfully");


        }

        public string GenerateToken(IEnumerable<Claim> claims) {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var tokenDescriptor = new SecurityTokenDescriptor {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
                Expires = DateTime.UtcNow.AddMinutes(180),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
