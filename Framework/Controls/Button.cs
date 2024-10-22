using Framework.Base;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Framework.Controls
{
    public class Button : BaseControl
    {
        public Button(IWebDriver driver, IWebElement parentForm, By by, string name, int delay, ILogger? logger = null) : base(driver, parentForm, by, name, delay, logger)
        {
        }
    }
}
