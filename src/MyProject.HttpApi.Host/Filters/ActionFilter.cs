using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using MyProject.HttpResult;

namespace MyProject.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            base.OnActionExecuted(actionContext);
        }
    }
}
