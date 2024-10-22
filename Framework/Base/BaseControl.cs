using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Framework.Base
{
    public abstract class BaseControl
    {
        private IWebDriver _driver;

        private readonly IWebElement _parentForm;

        private By _by;

        private int _delay;

        protected ILogger? _logger;

        private WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(_delay));

        protected IWebElement _webElement => _wait.Until(d => _parentForm.FindElement(_by));

        protected readonly string _name;

        public BaseControl(IWebDriver driver, IWebElement parentForm, By by, string name, int delay, ILogger? logger = null)
        {
            _driver = driver;
            _by = by;
            _name = name;
            _delay = delay;
            _logger = logger;
            _parentForm = parentForm;
        }

        public string GetText()
        {
            return _webElement.Text;
        }

        public void Click()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_webElement));
            _webElement.Click();
            _logger?.LogTrace($"{_name} clicked");
        }

        public bool IsDisplayed()
        {
            return _wait.Until(d => _webElement.Displayed);
        }
    }
}
