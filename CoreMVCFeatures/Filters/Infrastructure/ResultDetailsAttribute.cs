using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ResultDetailsAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string result = "Result type: " 
                            + context.Result.GetType().Name 
                            + "\nAction name: " + context.ActionDescriptor.DisplayName;

            if (context.Result is ObjectResult res && res.Value is string s)
            {
                result += "\nResult value: " + s;
            }
            
            context.Result = new ObjectResult(result);
        }
    }
}