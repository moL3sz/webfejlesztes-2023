using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Middlewares.Policy {
    public class UserInProjectRequirement : IAuthorizationRequirement{


        public UserInProjectRequirement() { 
        }
    }
}
