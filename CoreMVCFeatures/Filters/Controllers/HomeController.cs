using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ProfileAsync]
    public class HomeController : Controller
    {
        public string Index() => "Hello from Index";
    }
}