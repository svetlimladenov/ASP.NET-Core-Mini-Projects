using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using MishMashExamASP.NET.Services;

namespace MishMashExamASP.NET.Filters
{
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
    public class MyAuthorizeFilter : IAuthorizationFilter
    {
        private readonly ICounterService counterService;

        public MyAuthorizeFilter(ICounterService counterService)
        {
            this.counterService = counterService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            return;
        }
    }

    public class AddHeaderAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string header;
        private readonly string value;

        public AddHeaderAttribute(string header, string value)
        {
            this.header = header;
            this.value = value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(this.header,this.value);
            //OnActionExecuting
            await next();  //the Action itself
            //OnActionExecuted
        }
    }
    public class ValidateModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ContentResult() {Content = "Invalid Model State"};
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new OkResult();
        }
    }
}
