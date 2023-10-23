using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.API.Controllers.Common {
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller {


        private readonly ILogger _logger;

        private readonly HttpContextAccessor _contextAccessor = new HttpContextAccessor();

        public BaseController(ILogger logger) {
            _logger = logger;

        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuted(ActionExecutedContext context) {
            base.OnActionExecuted(context);
        }
    }
}
