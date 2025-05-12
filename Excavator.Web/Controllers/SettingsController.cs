using Excavator.Commands.Settings;
using Excavator.Queries.Settings;
using Excavator.QueryHandlers.Settings;
using Excavator.Shared.Models.DTOs.Settings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetMenu()
        {
            // Get distinct sections for the menu
            var settings = _mediator.Send(new GetAllSettingsQuery()).GetAwaiter().GetResult();
            var sections = settings.Select(x => x.Section).Distinct().ToList();

            return PartialView("_SettingsMenu", sections);
        }

        public IActionResult GetSettings(string section)
        {
            var settings = _mediator.Send(new GetSettingsBySectionNameQuery() { SectionName = section}).GetAwaiter().GetResult();
            return PartialView("_SettingsContent", settings);
        }
    }
}
