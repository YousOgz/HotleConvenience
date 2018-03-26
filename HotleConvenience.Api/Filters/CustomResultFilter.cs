using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotleConvenience.Api.Filters
{
    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            context.Result = new JsonResult
            (
                new
                {
                    code = result.StatusCode,
                    result = result.Value
                }
            );
        }
    }
}
