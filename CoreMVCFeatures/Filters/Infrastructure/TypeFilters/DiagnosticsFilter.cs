using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure.TypeFilters
{
    public class DiagnosticsFilter : IAsyncResultFilter
    {
        private readonly IFilterDiagnostics _diagnostics;

        public DiagnosticsFilter(IFilterDiagnostics diag)
        {
            _diagnostics = diag;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            await next();
            if (_diagnostics?.Messages != null)
                foreach (var message in _diagnostics?.Messages)
                {
                    var bytes = Encoding.ASCII
                        .GetBytes($"\n{message}");
                    await context.HttpContext.Response.Body
                        .WriteAsync(bytes, 0, bytes.Length);
                }
        }
    }
}