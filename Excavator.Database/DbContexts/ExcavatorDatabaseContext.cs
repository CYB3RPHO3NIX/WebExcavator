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
            //base.OnModelCreating(modelBuilder);

            var settings = new List<Setting>
            {
                // General Settings
                new Setting
                {
                    Key = "AppName",
                    Value = "MyApplication",
                    Description = "The display name of the application",
                    Section = "General",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "AppVersion",
                    Value = "1.0.0",
                    Description = "Current application version",
                    Section = "General",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "CompanyName",
                    Value = "Acme Inc.",
                    Description = "The company name",
                    Section = "General",
                    IsEncrypted = false
                },
    
                // Security Settings
                new Setting
                {
                    Key = "MaxLoginAttempts",
                    Value = "5",
                    Description = "Maximum allowed failed login attempts before lockout",
                    Section = "Security",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "PasswordExpiryDays",
                    Value = "90",
                    Description = "Number of days before passwords expire",
                    Section = "Security",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "RequireTwoFactor",
                    Value = "true",
                    Description = "Whether two-factor authentication is required",
                    Section = "Security",
                    IsEncrypted = false
                },
    
                // Integration Settings
                new Setting
                {
                    Key = "ApiKey",
                    Value = "encrypted-value-here",
                    Description = "Third-party API access key",
                    Section = "Integration",
                    IsEncrypted = true
                },
                new Setting
                {
                    Key = "ExternalApiUrl",
                    Value = "https://api.example.com/v1",
                    Description = "Base URL for external API",
                    Section = "Integration",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "SyncIntervalMinutes",
                    Value = "30",
                    Description = "How often to sync with external services (in minutes)",
                    Section = "Integration",
                    IsEncrypted = false
                },
    
                // System Settings
                new Setting
                {
                    Key = "MaintenanceMode",
                    Value = "false",
                    Description = "Whether the application is in maintenance mode",
                    Section = "System",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "CacheDuration",
                    Value = "60",
                    Description = "Default cache duration in seconds",
                    Section = "System",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "LogRetentionDays",
                    Value = "30",
                    Description = "Number of days to keep log files",
                    Section = "System",
                    IsEncrypted = false
                },
    
                // Localization Settings
                new Setting
                {
                    Key = "DefaultCulture",
                    Value = "en-US",
                    Description = "Default culture for the application",
                    Section = "Localization",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "SupportedCultures",
                    Value = "en-US,es-ES,fr-FR",
                    Description = "Comma-separated list of supported cultures",
                    Section = "Localization",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "TimeZone",
                    Value = "UTC",
                    Description = "Default timezone for the application",
                    Section = "Localization",
                    IsEncrypted = false
                },
    
                // Email Settings
                new Setting
                {
                    Key = "SmtpServer",
                    Value = "mail.example.com",
                    Description = "SMTP server for sending emails",
                    Section = "Email",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "SmtpPort",
                    Value = "587",
                    Description = "SMTP server port",
                    Section = "Email",
                    IsEncrypted = false
                },
                new Setting
                {
                    Key = "SmtpUsername",
                    Value = "encrypted-username",
                    Description = "SMTP authentication username",
                    Section = "Email",
                    IsEncrypted = true
                },
                new Setting
                {
                    Key = "SmtpPassword",
                    Value = "encrypted-password",
                    Description = "SMTP authentication password",
                    Section = "Email",
                    IsEncrypted = true
                },
                new Setting
                {
                    Key = "FromEmail",
                    Value = "noreply@example.com",
                    Description = "Default sender email address",
                    Section = "Email",
                    IsEncrypted = false
                }
            };

            modelBuilder.Entity<Setting>().HasData(settings);
        }
    }
}
