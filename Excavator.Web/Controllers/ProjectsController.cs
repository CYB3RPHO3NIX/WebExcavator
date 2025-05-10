using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
