using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Database.Entities.Settings
{
    public class Setting : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Section { get; set; }
        public bool IsEncrypted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Entity configuration
        public class Configuration : IEntityTypeConfiguration<Setting>
        {
            public void Configure(EntityTypeBuilder<Setting> builder)
            {
                // Primary key
                builder.HasKey(s => s.Id);

                // Indexes
                builder.HasIndex(s => s.Key).IsUnique();

                // Constraints
                builder.Property(s => s.Key)
                    .IsRequired()
                    .HasMaxLength(100);

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
            }
        }
    }
}
