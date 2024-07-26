using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Infrastructure.Filters
{
    public class ValidationFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var error=  context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();
                context.Result=new BadRequestObjectResult(error);
                return;
            }
             await next();

        }
    }
}
