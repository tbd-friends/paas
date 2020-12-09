using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gamer.Menu.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(cfg =>
                cfg.UseSqlServer(configuration.GetConnectionString("menus")));

            services.AddScoped<IApplicationContext, ApplicationContext>();

            return services;
        }
    }
}