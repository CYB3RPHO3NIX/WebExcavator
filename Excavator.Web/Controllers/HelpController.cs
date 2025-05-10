using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
