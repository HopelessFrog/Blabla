using Framework.Base;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Framework.Controls
{
    public class Input : BaseControl
    {
        public Input(IWebDriver driver, IWebElement parentForm, By by, string name, int delay, ILogger? logger = null) : base(driver, parentForm, by, name, delay, logger)
        {
        }

        public void InputText(string text)
        {
            _webElement.SendKeys(text);
            _logger?.LogTrace($"Entered {text} in {_name}");
        }
    }
}
