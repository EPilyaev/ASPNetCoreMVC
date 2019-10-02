using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ProfileToResultAttribute : ActionFilterAttribute
    {
        private double _actionTime;
        private Stopwatch _timer;

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            _timer = Stopwatch.StartNew();
            await next();
            _actionTime = _timer.Elapsed.TotalMilliseconds;
        }

        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            await next();
            _timer.Stop();
            var result = "\n\n\nAction time: "
                         + $"{_actionTime} ms\nTotal time: "
                         + $"{_timer.Elapsed.TotalMilliseconds} ms";
            
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes,
                0, bytes.Length);
        }
    }
}