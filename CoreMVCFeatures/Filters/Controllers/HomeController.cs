using System;
using Filters.Infrastructure;
using Filters.Infrastructure.ServiceFilters;
using Filters.Infrastructure.TypeFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [TypeFilter(typeof(DiagnosticsFilter))]
    [ServiceFilter(typeof(ServiceTimeFilter))]
    public class HomeController : Controller
    {
        public string Index() => "Hello from Index";

        public string GenerateException(bool? gen)
        {
            switch (gen)
            {
                case null:
                    throw new ArgumentNullException(nameof(gen));
                case true:
                    throw new ArgumentException("This is generated in GenerateException");
                default:
                    return "No exception has been thrown";
            }
        }
    }
}