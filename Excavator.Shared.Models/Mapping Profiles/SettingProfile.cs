using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            // Entity -> DTO
            CreateMap<Setting, SettingDTO>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.DropdownOptions))
                .ForMember(dest => dest.IntValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Integer ? src.IntValue : null))
                .ForMember(dest => dest.DecimalValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Decimal ? src.DecimalValue : null))
                .ForMember(dest => dest.BoolValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Boolean ? src.BoolValue : null))
                .ForMember(dest => dest.DateTimeValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.DateTime ? src.DateTimeValue : null));

            // DTO -> Entity
            CreateMap<SettingDTO, Setting>()
                .ForMember(dest => dest.Options,
                    opt => opt.MapFrom((src, dest) => JsonSerializer.Serialize(src.Options, new JsonSerializerOptions())))
                .ForMember(dest => dest.IntValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Integer ? src.IntValue : null))
                .ForMember(dest => dest.DecimalValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Decimal ? src.DecimalValue : null))
                .ForMember(dest => dest.BoolValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.Boolean ? src.BoolValue : null))
                .ForMember(dest => dest.DateTimeValue,
                    opt => opt.MapFrom(src => src.Type == SettingType.DateTime ? src.DateTimeValue : null))
                .ForMember(dest => dest.TypedValue, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.TypedValue = src.Type switch
                    {
                        SettingType.Integer => src.IntValue,
                        SettingType.Decimal => src.DecimalValue,
                        SettingType.Boolean => src.BoolValue,
                        SettingType.DateTime => src.DateTimeValue,
                        _ => src.Value
                    };
                });
        }
    }
}
