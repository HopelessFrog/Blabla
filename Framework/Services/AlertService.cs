using Core.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Framework.Services
{
    public class AlertService
    {
        private readonly IWebDriver _driver;

        private readonly BrowserConfiguration _configuration;

        private readonly ILogger? _logger;

        private WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.Delay));

        private IAlert _currentAlert => _wait.Until(ExpectedConditions.AlertIsPresent());

        public AlertService(IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
        {
            _driver = driver;
            _configuration = config.Value;
            _logger = logger;
        }

        public string GetText()
        {
            return _currentAlert.Text;
        }

        public bool IsDisplayed()
        {
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
            return (alert != null);
        }

        public void Accept()
        {
            _currentAlert.Accept();
        }

        public void Dismiss()
        {
            _currentAlert.Dismiss();
        }

        public void InputText(string text)
        {
            _currentAlert.SendKeys(text);
            _logger?.LogTrace($"Entered text {text}");
        }
    }
}
