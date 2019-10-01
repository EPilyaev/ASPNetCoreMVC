using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ResultDetailsAsync]
    public class HomeController : Controller
    {
        public string Index() => "Hello from Index";
    }
}