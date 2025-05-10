using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Keep this page for showing statistics. overall
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
