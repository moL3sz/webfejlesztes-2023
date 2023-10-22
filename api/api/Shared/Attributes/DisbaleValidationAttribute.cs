using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace api.Shared.Attributes {


    public class DisableModelStateValidationAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            context.ModelState.Clear();
        }
    }

}

