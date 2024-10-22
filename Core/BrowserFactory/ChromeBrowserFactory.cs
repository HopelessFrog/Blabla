using Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.BrowserFactory
{
    public class ChromeBrowserFactory : BrowserFactoryBase
    {
        public ChromeBrowserFactory(BrowserConfiguration configuration) : base(configuration)
        {
        }

        protected override IWebDriver CreateDriver()
        {
            return new ChromeDriver(GetOptions());
        }

        protected override ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--lang=" + _configuration.Lang);
            options.PageLoadStrategy = _configuration.PageLoadStrategy;

            return options;
        }
    }
}
