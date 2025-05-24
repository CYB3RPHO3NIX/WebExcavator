using Excavator.Database.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Shared.Models.DTOs.Settings
{
    public class SettingDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Section { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        // Value storage and type information
        public string Value { get; set; } = string.Empty;
        public SettingType Type { get; set; } = SettingType.String;

        // Typed values for easier client-side usage
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? DateTimeValue { get; set; }

        // Metadata
        public string? Description { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsSystem { get; set; }

        // Dropdown options
        public List<string> Options { get; set; } = new List<string>();

        // Validation constraints
        public int? MinIntValue { get; set; }
        public int? MaxIntValue { get; set; }
        public decimal? MinDecimalValue { get; set; }
        public decimal? MaxDecimalValue { get; set; }
        public DateTime? MinDateTimeValue { get; set; }
        public DateTime? MaxDateTimeValue { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Helper properties for view
        public string DisplayValue => IsEncrypted ? new string('*', 8) : Value;
        public string MinValue => GetMinValueString();
        public string MaxValue => GetMaxValueString();

        private string GetMinValueString()
        {
            return Type switch
            {
                SettingType.Integer => MinIntValue?.ToString() ?? "none",
                SettingType.Decimal => MinDecimalValue?.ToString() ?? "none",
                SettingType.DateTime => MinDateTimeValue?.ToString("yyyy-MM-ddTHH:mm") ?? "none",
                _ => "none"
            };
        }

        private string GetMaxValueString()
        {
            return Type switch
            {
                SettingType.Integer => MaxIntValue?.ToString() ?? "none",
                SettingType.Decimal => MaxDecimalValue?.ToString() ?? "none",
                SettingType.DateTime => MaxDateTimeValue?.ToString("yyyy-MM-ddTHH:mm") ?? "none",
                _ => "none"
            };
        }
    }
}
