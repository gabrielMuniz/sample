using Microsoft.Extensions.DependencyInjection;
using SampleApp.SampleApi.HostedServices;

namespace SampleApp.SampleApi.Configuration
{
    public static class HostedServicesConfig
    {

        public static IServiceCollection AddHostedServicesConfig(this IServiceCollection services)
        {
            services.AddHostedService<UpdateStatusTodoService>();
            return services;
        }

    }
}
