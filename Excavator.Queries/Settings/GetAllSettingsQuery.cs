using Excavator.Shared.Models.DTOs.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Queries.Settings
{
    public class GetAllSettingsQuery : IRequest<IEnumerable<SettingDTO>>
    {

    }
}
