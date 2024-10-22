using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class HomePage : BaseForm
    {
        private Button _alertsFrameWindowButton =>
            _controlsFactory.CreateControl<Button>(_form, "Alerts, Frame & Windows", By.XPath(".//*[contains(@class, 'card-body')]//*[contains(text(), 'Alerts')]"));
        private Button _elementsButton =>
            _controlsFactory.CreateControl<Button>(_form, "Elements", By.XPath(".//*[contains(@class, 'card-body')]//*[contains(text(), 'Elements')]"));

        public HomePage(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='app']")
        {
        }

        public void GoToMainPageAlertsFrameWindows()
        {
            _alertsFrameWindowButton.Click();
        }

        public void GoToMainPageElements()
        {
            _elementsButton.Click();
        }

        public override bool IsLoaded()
        {
            return _elementsButton.IsDisplayed();
        }
    }
}
