using Excavator.Shared.Models.DTOs.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Queries.Settings
{
    public class GetSettingsBySectionNameQuery : IRequest<IEnumerable<SettingDTO>>
    {
        public string SectionName { get; set; }
    }
}
