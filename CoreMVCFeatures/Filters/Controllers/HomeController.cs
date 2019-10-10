using System;
using Filters.Infrastructure;
using Filters.Infrastructure.ServiceFilters;
using Filters.Infrastructure.TypeFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]
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