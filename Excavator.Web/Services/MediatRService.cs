using Excavator.CommandHandlers;
using Excavator.CommandHandlers.Settings;
using Excavator.Queries.Settings;
using Excavator.QueryHandlers;
using Excavator.QueryHandlers.Settings;
namespace Excavator.Web.Services
{
    public static class MediatRService
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(GetAllSettingsQueryHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(AddNewSettingCommandHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(GetSettingsBySectionNameQueryHandler).Assembly);
                // Add more assemblies here as needed
            });
            return services;
        }
    }
}
