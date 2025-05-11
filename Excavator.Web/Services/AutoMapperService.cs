using Excavator.Shared.Models.Mapping_Profiles;

namespace Excavator.Web.Services
{
    public static class AutoMapperService
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(SettingProfile).Assembly
                //Add Here
            );
            return services;
        }
    }
}
