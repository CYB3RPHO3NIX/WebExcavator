using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Commands.Settings
{
    public class AddNewSettingCommand : IRequest<bool>
    {
        public string? Section { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsEncrypted { get; set; }
    }
}
