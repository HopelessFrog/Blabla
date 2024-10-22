using Core.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.SetUps
{
    public class LogTestCaseInfoSetUp : ISetUp
    {
        private readonly IWebDriver _driver;

        private readonly BrowserConfiguration _browserConfiguration;

        private readonly ILogger? _logger;

        public LogTestCaseInfoSetUp(IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
        {
            _browserConfiguration = config.Value;
            _logger = logger;
        }

        public void SetUp()
        {
            _logger?.LogTrace($"\nUrl = {_browserConfiguration.Url}\nBrowser = {_browserConfiguration.Browser}");
        }
    }
}
