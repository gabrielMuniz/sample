using Microsoft.Extensions.DependencyInjection;
using SampleApp.Domain.Interfaces.Repositories;
using SampleApp.Domain.Interfaces.Services;
using SampleApp.Domain.Services;
using SampleApp.Infra.Data.Contexts;
using SampleApp.Infra.Data.Repositories;

namespace SampleApp.SampleApi.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DefaultContext>();

            //Repositories
            services.AddScoped<ITodoRepository, TodoRepository>();

            //Services
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }

    }
}
