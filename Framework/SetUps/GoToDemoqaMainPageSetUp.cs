using Core.Config;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.SetUps
{
    public class GoToDemoqaMainPageSetUp : ISetUp
    {
        private readonly IWebDriver _driver;

        private readonly BrowserConfiguration _browserConfiguration;

        public GoToDemoqaMainPageSetUp(IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config)
        {
            _driver = driver;
            _browserConfiguration = config.Value;
        }

        public void SetUp()
        {
            _driver.Navigate().GoToUrl(_browserConfiguration.Url);
        }
    }
}
