using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.SampleApi.Configuration.Profile;

namespace SampleApp.SampleApi.Configuration
{
    public static class AutoMapperConfig
    {

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(CreateMapper());
            return services;
        }

        private static MapperConfiguration CreateMapper()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            });
        }

    }
}
