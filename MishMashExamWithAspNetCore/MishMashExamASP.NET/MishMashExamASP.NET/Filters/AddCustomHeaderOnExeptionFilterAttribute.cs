using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MishMashExamASP.NET.Filters
{
    public class AddCustomHeaderOnExeptionFilterAttribute : Attribute, IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult {ViewName = "Index"};
            context.HttpContext.Response.Clear();
            context.Result = result;
        }
    }
}
