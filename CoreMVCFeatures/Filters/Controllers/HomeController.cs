using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [HttpsOnly]
        public string Index() => "Hello from Index";
    }
}
