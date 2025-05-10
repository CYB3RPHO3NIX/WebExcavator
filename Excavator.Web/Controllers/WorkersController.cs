using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class WorkersController : Controller
    {
        //Keep this page for Managing all the workers.
        public IActionResult Index()
        {
            return View();
        }
    }
}
