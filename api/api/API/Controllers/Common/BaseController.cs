using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.API.Controllers.Common {
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller {


        /// <summary>
        /// Logoló
        /// </summary>
        private readonly ILogger _logger;


        public BaseController(ILogger logger) {
            _logger = logger;

        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            _logger.LogInformation(1, $"API hívás kezdet: {context.ActionDescriptor.DisplayName} {context.ActionDescriptor.Id}");

            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuted(ActionExecutedContext context) {
            _logger.LogInformation(1, $"API hívás vége: {context.ActionDescriptor.DisplayName} {context.ActionDescriptor.Id}");

            base.OnActionExecuted(context);
        }
    }
}
