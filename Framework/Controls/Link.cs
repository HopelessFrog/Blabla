using Framework.Base;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Framework.Controls
{
    public class Link : BaseControl
    {
        public Link(IWebDriver driver, IWebElement parentForm, By by, string name, int delay, ILogger? logger = null) : base(driver, parentForm, by, name, delay, logger)
        {
        }
    }
}
