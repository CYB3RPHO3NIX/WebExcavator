using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excavator.Database.Entities.Settings
{
    public enum SettingType
    {
        String,
        Integer,
        Decimal,
        Boolean,
        DateTime,
        Secret,
        Dropdown,
        Json
    }
    public class Setting : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Key { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        // Main value storage (for string type or serialized values)
        [Required]
        public string Value { get; set; } = string.Empty;

        // Type information
        public SettingType Type { get; set; } = SettingType.String;

        // Additional typed values for better querying
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? DateTimeValue { get; set; }

        // Metadata
        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Section { get; set; }

        public bool IsEncrypted { get; set; }
        public bool IsSystem { get; set; } = false;

        // For dropdown options (stored as JSON)
        [Column(TypeName = "nvarchar(max)")]
        public string? Options { get; set; }

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

        // Helper property to get/set typed value
        [NotMapped]
        public object TypedValue
        {
            get
            {
                return Type switch
                {
                    SettingType.String => Value,
                    SettingType.Integer => IntValue,
                    SettingType.Decimal => DecimalValue,
                    SettingType.Boolean => BoolValue,
                    SettingType.DateTime => DateTimeValue,
                    SettingType.Secret => Value,
                    SettingType.Dropdown => Value,
                    SettingType.Json => Value,
                    _ => Value
                };
            }
            set
            {
                switch (Type)
                {
                    case SettingType.String:
                    case SettingType.Secret:
                    case SettingType.Dropdown:
                    case SettingType.Json:
                        Value = value?.ToString() ?? string.Empty;
                        break;
                    case SettingType.Integer:
                        IntValue = value != null ? Convert.ToInt32(value) : (int?)null;
                        Value = IntValue?.ToString() ?? string.Empty;
                        break;
                    case SettingType.Decimal:
                        DecimalValue = value != null ? Convert.ToDecimal(value) : (decimal?)null;
                        Value = DecimalValue?.ToString() ?? string.Empty;
                        break;
                    case SettingType.Boolean:
                        BoolValue = value != null ? Convert.ToBoolean(value) : (bool?)null;
                        Value = BoolValue?.ToString() ?? string.Empty;
                        break;
                    case SettingType.DateTime:
                        DateTimeValue = value != null ? Convert.ToDateTime(value) : (DateTime?)null;
                        Value = DateTimeValue?.ToString("o") ?? string.Empty; // ISO 8601 format
                        break;
                }
            }
        }

        // Helper property for dropdown options
        [NotMapped]
        public List<string> DropdownOptions
        {
            get => !string.IsNullOrEmpty(Options) ?
                System.Text.Json.JsonSerializer.Deserialize<List<string>>(Options) ?? new List<string>() :
                new List<string>();
            set => Options = System.Text.Json.JsonSerializer.Serialize(value);
        }

        // Entity configuration
        public class Configuration : IEntityTypeConfiguration<Setting>
        {
            public void Configure(EntityTypeBuilder<Setting> builder)
            {
                // Primary key
                builder.HasKey(s => s.Id);

                // Indexes
                builder.HasIndex(s => s.Key).IsUnique();
                builder.HasIndex(s => s.Section);

                // Constraints
                builder.Property(s => s.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(s => s.Value)
                    .IsRequired();

                builder.Property(s => s.Description)
                    .HasMaxLength(500);

                builder.Property(s => s.Section)
                    .HasMaxLength(100);

                // Default values
                builder.Property(s => s.Id)
                    .ValueGeneratedOnAdd();

                builder.Property(s => s.CreatedAt)
                    .ValueGeneratedOnAdd();

                // Configure JSON conversion for Options
                builder.Property(s => s.Options)
                    .HasConversion(
                        v => v ?? string.Empty,
                        v => string.IsNullOrEmpty(v) ? null : v);
            }
        }
    }
}
