using api.API.Middlewares.Policy;
using api.BLL.Helpers;
using api.BLL.Interfaces;
using api.BLL.Services;
using api.DAL.Interfaces;
using api.DAL.Interfaces.Common;
using api.DAL.Repositories;
using api.DAL.Repositories.Common;
using Microsoft.AspNetCore.Authorization;

namespace api
{
    public static class ProgramDIExtension {


        public static IServiceCollection AddInjektables(this IServiceCollection services) {



            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectUserService, ProjectUserService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IDictionaryService, DictionaryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJWTHandler, JWTHandler>();



            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUserRepository, ProjectUserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IDictionaryManagerRepository, DictionaryManagerRepository>();



            // Helpers
            services.AddScoped<IRecordInfoHelper, RecordInfoHelper>();
            services.AddScoped<IPartialUpdateHelper, PartialUpdateHelper>();
            services.AddScoped<IUserHelper, UserHelper>();

            // Auth requirements
            services.AddSingleton<IAuthorizationHandler, UserInProjectRequirementAuthorzationHandler>();
            

            return services;
        }
    }
}
