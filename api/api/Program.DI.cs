using api.BLL.Helpers;
using api.BLL.Interfaces;
using api.BLL.Services;
using api.DAL.Interfaces;
using api.DAL.Interfaces.Common;
using api.DAL.Repositories;
using api.DAL.Repositories.Common;

namespace api
{
    public static class ProgramDIExtension {


        public static IServiceCollection AddInjektables(this IServiceCollection services) {



            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectUserService, ProjectUserService>();



            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUserRepository, ProjectUserRepository>();



            // Helpers
            services.AddScoped<IRecordInfoHelper, RecordInfoHelper>();
            services.AddScoped<IPartialUpdateHelper, PartialUpdateHelper>();
            services.AddScoped<IUserHelper, UserHelper>();
            

            return services;
        }
    }
}
