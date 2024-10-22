using Core.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.ServicesProvider
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AddBrowserConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json", optional: true)
               .Build();

            return services.Configure<BrowserConfiguration>(configuration.GetSection("BrowserSettings"));
        }
    }
}
