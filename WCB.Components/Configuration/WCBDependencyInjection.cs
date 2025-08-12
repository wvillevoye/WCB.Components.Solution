using Microsoft.Extensions.DependencyInjection;
using WCB.Components.Services.WCBModal;
using WCB.Components.Services.WCBOffcanvas;
using WCB.Components.Services.WCBPagination;
using WCB.Components.Services.WCBToast;

namespace WCB.Components.Configuration
{
    public class WCBDependencyInjection: IDependency
    {

        public void AddDependencies(IServiceCollection services)
        {
            if (!services.IsServiceRegistered<HttpClient>())
            {
                services.AddHttpClient();
            }


            services.AddScoped<WCBToastService>();
            services.AddScoped<WCBModalService>();
            services.AddScoped<WCBOffcanvasService>();
            services.AddScoped<WCBPaginationService>();
            services.AddScoped<WCBApiService>();
            services.AddScoped<WCBApiPaginationService>();
        }
    }
    public static class ServiceCollectionExtensions
    {
        public static bool IsServiceRegistered<TService>(this IServiceCollection services)
        {
            return services.Any(sd => sd.ServiceType == typeof(TService));
        }
    }
}
