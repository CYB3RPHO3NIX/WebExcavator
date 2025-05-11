using Excavator.Commands.Settings;
using Excavator.Queries.Settings;
using Excavator.QueryHandlers.Settings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Excavator.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IMediator _mediator;
        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
