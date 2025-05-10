using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
