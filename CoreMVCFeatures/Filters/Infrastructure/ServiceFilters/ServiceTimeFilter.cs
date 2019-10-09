using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure.TypeFilters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure.ServiceFilters
{
    public class ServiceTimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private readonly ConcurrentQueue<double> _actionTimes = new ConcurrentQueue<double>();
        private readonly ConcurrentQueue<double> _resultTimes = new ConcurrentQueue<double>();
        private readonly IFilterDiagnostics _diagnostics;

        public ServiceTimeFilter(IFilterDiagnostics diags)
        {
            _diagnostics = diags;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            _actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            _diagnostics.AddMessage($@"Action time:{timer.Elapsed.TotalMilliseconds}"+
                                    $"\nAverage: {_actionTimes.Average():F2}");
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            _resultTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            _diagnostics.AddMessage($@"Result time:{timer.Elapsed.TotalMilliseconds}"+
                                    $"\nAverage: {_resultTimes.Average():F2}");
        }
    }
}