using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService, ProductHubService>();
            services.AddSignalR();
            
        }
    }
}
