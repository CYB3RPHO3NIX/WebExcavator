using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Excavator.Database.Entities.Settings;
using Excavator.Shared.Models.DTOs.Settings;

namespace Excavator.Shared.Models.Mapping_Profiles
{
    public class SettingProfile : Profile
    {
        public SettingProfile()
        {
            CreateMap<Setting, SettingDTO>().ReverseMap();
        }
    }
}
