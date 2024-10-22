using Core.DriverFactorys;
using Framework.Factorys;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace Core.ServicesProvider
{
    public class ServiceсProviderBuilder
    {
        public ServiceProvider Build(Action<IServiceCollection> configure)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBrowserConfiguration()
            .AddScoped<IDriverFactory, DriverFactory>()
            .AddScoped<ControlsFactory>()
            .AddScoped<IWebDriver>(s => s.GetRequiredService<IDriverFactory>().CreateDriver())
            .AddLogger();

            configure(serviceCollection);

            return serviceCollection.BuildServiceProvider(new ServiceProviderOptions() { ValidateOnBuild = true, ValidateScopes = true });
        }
    }
}
