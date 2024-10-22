using Core.Config;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Base
{
    public abstract class BaseForm
    {
        private readonly IWebDriver _driver;

        private readonly int _delay;

        protected readonly ControlsFactory _controlsFactory;

        protected readonly ILogger? _logger;

        private string _locator;

        protected WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(_delay));

        protected IWebElement _form => _wait.Until(d => d.FindElement(By.XPath(_locator)));

        protected BaseForm(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null, string locator = "//html")
        {
            _controlsFactory = controlsFactory;
            _logger = logger;
            _driver = driver;
            _delay = config.Value.Delay;
            _locator = locator;
        }

        public abstract bool IsLoaded();
    }
}
