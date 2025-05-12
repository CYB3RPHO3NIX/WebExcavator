using Excavator.Database.DbContexts;
using Excavator.Database.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Excavator.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace Excavator.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<ExcavatorDatabaseContext>(
                builder.Configuration.GetConnectionString("Database")
            );

            builder.Services.AddAutoMapperServices();

            builder.Services.AddMediatRServices();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ExcavatorDatabaseContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
