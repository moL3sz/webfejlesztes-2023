using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace api.API.Middlewares.Policy {
    public class UserInProjectRequirementAuthorzationHandler : AuthorizationHandler<UserInProjectRequirement, HttpContext> {

        private readonly ILogger<UserInProjectRequirementAuthorzationHandler> _logger;

        public UserInProjectRequirementAuthorzationHandler(ILogger<UserInProjectRequirementAuthorzationHandler> logger) {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserInProjectRequirement requirement, HttpContext resource) {
            try {
                int projectId = int.Parse(resource.Request.RouteValues.GetValueOrDefault("projectId", 0).ToString());

                var hasAdminPermission = context.User.HasClaim(ClaimTypes.Role, $"{projectId}_ADMIN");
                var hasDeveloperPermission = context.User.HasClaim(ClaimTypes.Role, $"{projectId}_DEVELOPER");

                if (hasAdminPermission || hasDeveloperPermission) {
                    context.Succeed(requirement);
                }
            }
            catch (Exception ex) {

                _logger.LogError(ex,null);
            }
            return Task.CompletedTask;


        }
    }
}
