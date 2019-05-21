using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LearnNlog.Logging.FilterExtensions
{
    public class ExceptionLogFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetName().Name;
            WriteLog.Error(context.Exception.Message, name, controllerName, context.Exception);
        }
    }
}
