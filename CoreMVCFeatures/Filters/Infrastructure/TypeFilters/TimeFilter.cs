using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure.TypeFilters
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private readonly IFilterDiagnostics _diagnostics;
        private Stopwatch _timer;

        public TimeFilter(IFilterDiagnostics diag)
        {
            _diagnostics = diag;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            _timer = Stopwatch.StartNew();
            await next();
            _diagnostics.AddMessage($@"Action time:{_timer.Elapsed.TotalMilliseconds}");
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            await next();
            _timer.Stop();
            _diagnostics.AddMessage($@"Result time:{_timer.Elapsed.TotalMilliseconds}");
        }
    }
}