using Core.Config;
using Framework.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.Factorys
{
    public class ControlsFactory
    {
        private readonly IWebDriver _driver;

        private readonly BrowserConfiguration _configuration;

        private readonly ILogger? _logger;

        public ControlsFactory(IWebDriver driver, IOptions<BrowserConfiguration> config, ILogger? logger = null)
        {
            _driver = driver;
            _configuration = config.Value;
            _logger = logger;
        }

        public T CreateControl<T>(IWebElement parentForm, string name, By by) where T : BaseControl
        {
            return Activator.CreateInstance(typeof(T), [_driver, parentForm, by, name, _configuration.Delay, _logger]) as T;
        }
    }
}
