using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
        }
    }
}
