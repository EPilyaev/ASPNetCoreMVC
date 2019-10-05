using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new ObjectResult($"Custom exception filter\n" +
                                 $"Exception type: {context.Exception.GetType()}\n" +
                                 $"Exception message: {context.Exception.Message}");
            }
        }
    }
}