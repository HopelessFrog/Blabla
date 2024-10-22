using Core.BrowserFactory;
using Core.Config;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using Shared.Exceptions;

namespace Core.DriverFactorys
{
    public class DriverFactory : IDriverFactory
    {
        private BrowserConfiguration configuration;

        public DriverFactory(IOptions<BrowserConfiguration> configuration)
            => this.configuration = configuration.Value;

        private BrowserFactoryBase _browserFactory;

        public IWebDriver CreateDriver()
        {
            switch (configuration.Browser)
            {
                case BrowserType.Chrome:
                    _browserFactory = new ChromeBrowserFactory(configuration);
                    break;
                case BrowserType.Firefox:
                    _browserFactory = new FirefoxBrowserFactory(configuration);
                    break;
                default:
                    throw new UnrealizedBrowserException("This browser is not supported");
            }

            return _browserFactory.GetDriver();
        }
    }
}
