using Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.BrowserFactory
{
    public class FirefoxBrowserFactory : BrowserFactoryBase
    {
        public FirefoxBrowserFactory(BrowserConfiguration configuration) : base(configuration)
        {
        }

        protected override IWebDriver CreateDriver()
        {
            return new FirefoxDriver(GetOptions());
        }

        protected override FirefoxOptions GetOptions()
        {
            var options = new FirefoxOptions();

            options.SetPreference("intl.accept_languages", _configuration.Lang);
            options.PageLoadStrategy = _configuration.PageLoadStrategy;

            return options;
        }
    }
}
