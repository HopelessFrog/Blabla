using Core.Config;
using OpenQA.Selenium;

namespace Core.BrowserFactory
{
    public abstract class BrowserFactoryBase
    {
        protected readonly BrowserConfiguration _configuration;

        public BrowserFactoryBase(BrowserConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IWebDriver GetDriver()
        {
            var driver = CreateDriver();

            driver.Manage().Window.Maximize();

            return driver;
        }

        protected abstract IWebDriver CreateDriver();

        protected abstract DriverOptions GetOptions();
    }
}
