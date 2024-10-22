using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class Menu : BaseForm
    {
        private Button _alerts => _controlsFactory.CreateControl<Button>(_form, "Alerts menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Alerts')]"));
        private Button _nestedFrames =>
            _controlsFactory.CreateControl<Button>(_form, "Nested frames menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Nested Frames')]"));
        private Button _frames => _controlsFactory.CreateControl<Button>(_form, "Frames menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Frames')]"));
        private Button _webTables =>
            _controlsFactory.CreateControl<Button>(_form, "Web tables menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Web Tables')]"));
        private Button _browserWindows =>
            _controlsFactory.CreateControl<Button>(_form, "Browser windows menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Browser Windows')]"));
        private Button _elements =>
            _controlsFactory.CreateControl<Button>(_form, "Elements menu button", By.XPath(".//*[contains(@class,'header-wrapper')]//*[contains(text(),'Elements')]"));
        private Button _links =>
            _controlsFactory.CreateControl<Button>(_form, "Browser windows menu button", By.XPath(".//*[contains(@class,'menu-list')]//*[contains(text(),'Links')]"));

        public Menu(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[contains(@class,'left-pannel')]")
        {
        }

        public void GoToLinksForm()
        {
            _elements.Click();
            _links.IsDisplayed();
            _links.Click();
        }

        public void GoToBrowserWindowsForm()
        {
            _browserWindows.Click();
        }

        public void GoToWebTablesForm()
        {
            _webTables.Click();
        }

        public void GotToAlertsForm()
        {
            _alerts.Click();
        }

        public void GoToNestedFramesForm()
        {
            _nestedFrames.Click();
        }

        public void GoToFramesForm()
        {
            _frames.Click();
        }

        public override bool IsLoaded()
        {
            return _elements.IsDisplayed();
        }
    }
}
