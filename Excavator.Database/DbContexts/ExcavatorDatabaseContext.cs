using Excavator.Database.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excavator.Database.DbContexts
{
    public class ExcavatorDatabaseContext : DbContext
    {
        public ExcavatorDatabaseContext(DbContextOptions<ExcavatorDatabaseContext> options) : base(options)
        { }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var settings = new List<Setting>
            {
                // General Settings
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "General",
                    Key = "AppName",
                    Name = "Application Name",
                    Type = SettingType.String,
                    Value = "Excavator Pro",
                    Description = "The display name of the application",
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "General",
                    Key = "AppVersion",
                    Name = "Application Version",
                    Type = SettingType.String,
                    Value = "2.5.0",
                    Description = "Current application version",
                    CreatedAt = DateTime.UtcNow
                },

                // Security Settings
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "Security",
                    Key = "MaxLoginAttempts",
                    Name = "Maximum Login Attempts",
                    Type = SettingType.Integer,
                    Value = "5",
                    IntValue = 5,
                    MinIntValue = 1,
                    MaxIntValue = 10,
                    Description = "Maximum allowed login attempts before lockout",
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "Security",
                    Key = "SessionTimeout",
                    Name = "Session Timeout",
                    Type = SettingType.Integer,
                    Value = "30",
                    IntValue = 30,
                    MinIntValue = 5,
                    MaxIntValue = 120,
                    Description = "Session timeout in minutes",
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "Security",
                    Key = "ApiToken",
                    Name = "API Token",
                    Type = SettingType.Secret,
                    Value = "encrypted-token-value",
                    IsEncrypted = true,
                    Description = "API access token",
                    CreatedAt = DateTime.UtcNow
                },

                // UI Settings
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "UI",
                    Key = "Theme",
                    Name = "Application Theme",
                    Type = SettingType.Dropdown,
                    Value = "Dark",
                    Options = "[\"Light\",\"Dark\",\"System\"]",
                    Description = "Application color theme",
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "UI",
                    Key = "ResultsPerPage",
                    Name = "Results Per Page",
                    Type = SettingType.Integer,
                    Value = "25",
                    IntValue = 25,
                    MinIntValue = 5,
                    MaxIntValue = 100,
                    Description = "Number of items to display per page",
                    CreatedAt = DateTime.UtcNow
                },

                // Notification Settings
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "Notifications",
                    Key = "EmailAlertsEnabled",
                    Name = "Email Alerts Enabled",
                    Type = SettingType.Boolean,
                    Value = "true",
                    BoolValue = true,
                    Description = "Enable email notifications",
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "Notifications",
                    Key = "AlertThreshold",
                    Name = "Alert Threshold",
                    Type = SettingType.Decimal,
                    Value = "0.75",
                    DecimalValue = 0.75m,
                    MinDecimalValue = 0.1m,
                    MaxDecimalValue = 1.0m,
                    Description = "Threshold for sending alerts (0.0-1.0)",
                    CreatedAt = DateTime.UtcNow
                },

                // System Settings
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "System",
                    Key = "MaintenanceMode",
                    Name = "Maintenance Mode",
                    Type = SettingType.Boolean,
                    Value = "false",
                    BoolValue = false,
                    Description = "Put system in maintenance mode",
                    IsSystem = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Setting
                {
                    Id = Guid.NewGuid(),
                    Section = "System",
                    Key = "NextMaintenanceWindow",
                    Name = "Next Maintenance Window",
                    Type = SettingType.DateTime,
                    Value = DateTime.UtcNow.AddDays(30).ToString("o"),
                    DateTimeValue = DateTime.UtcNow.AddDays(30),
                    Description = "Scheduled next maintenance window",
                    IsSystem = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Setting>().HasData(settings);
        }
    }
}
