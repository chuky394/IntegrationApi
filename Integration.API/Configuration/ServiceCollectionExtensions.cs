using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
            }

            var applicationOptions = new ApplicationOptions();
            configuration.GetSection(ApplicationOptions.Section).Bind(applicationOptions);
            services.AddSingleton(typeof(ApplicationOptions), applicationOptions);
        }
        public static void AddMicrosoftApiConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
            }

            var microsoftApiOptions = new MicrosoftApiOptions();
            configuration.GetSection(MicrosoftApiOptions.Section).Bind(microsoftApiOptions);
            services.AddSingleton(typeof(MicrosoftApiOptions), microsoftApiOptions);
        }
    }
}