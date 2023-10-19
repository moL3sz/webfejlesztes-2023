using api.BLL.Interfaces;
using api.BLL.Services;
using api.DAL.Interfaces;
using api.DAL.Repositories;

namespace api {
    public static class ProgramDIExtension {


        public static IServiceCollection AddInjektables(this IServiceCollection services) {


            // Dependecy injection

            services.AddScoped<IAuthService, AuthService>();


            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
