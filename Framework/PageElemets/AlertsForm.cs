using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class AlertsForm : BaseForm
    {
        private Button _defaultAlert => _controlsFactory.CreateControl<Button>(_form, "Click Button to see alert", By.XPath(".//*[@id=\"alertButton\"]"));
        private Button _confirmAlert => _controlsFactory.CreateControl<Button>(_form, "On button click, confirm box will appear", By.XPath(".//*[@id='confirmButton']"));
        private Button _promptAlert => _controlsFactory.CreateControl<Button>(_form, "On button click, prompt box will appear", By.XPath(".//*[@id='promtButton']"));

        private Text _confirmAlertResult => _controlsFactory.CreateControl<Text>(_form, "Confirm alert result", By.XPath(".//*[@id='confirmResult']"));
        private Text _promptAlertResult => _controlsFactory.CreateControl<Text>(_form, "Prompt alert result", By.XPath(".//*[@id='promptResult']"));

        public readonly Menu Menu;

        public AlertsForm(ControlsFactory controlsFactory, Menu menu, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='javascriptAlertsWrapper']")
        {
            Menu = menu;
        }

        public override bool IsLoaded()
        {
            return _defaultAlert.IsDisplayed();
        }

        public string GetAlertConfirmResultText()
        {
            return _confirmAlertResult.GetText();
        }

        public string GetAlertPromptResultText()
        {
            return _promptAlertResult.GetText();
        }

        public void ClickDefaultAlertButton()
        {
            _defaultAlert.Click();
        }

        public void ClickConfirmAlertButton()
        {
            _confirmAlert.Click();
        }

        public void ClickPromtAlertButton()
        {
            _promptAlert.Click();
        }
    }
}
