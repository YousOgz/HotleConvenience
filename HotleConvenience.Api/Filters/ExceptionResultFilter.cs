using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotleConvenience.Api.Filters
{
    public class ExceptionResultFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult
               (
                   new
                   {
                       code = 500,
#if DEBUG
                       exceptionMsg = context.Exception.Message,
                       stack =context.Exception.StackTrace
#else
                       exceptionMsg = "系统出错"
#endif
                   }
               );
        }
    }
}
