using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Framework.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class BrowserWindowsForm : BaseForm
    {
        private readonly BrowserUtils _browserUtils;

        public readonly Menu Menu;

        private Button _tabButton => _controlsFactory.CreateControl<Button>(_form, "New tab button", By.XPath(".//*[@id='tabButton']"));

        public BrowserWindowsForm(ControlsFactory controlsFactory, BrowserUtils browserUtils, Menu menu,
            IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='browserWindows']")
        {
            Menu = menu;

            _browserUtils = browserUtils;
        }

        public void CreateNewTab()
        {
            _tabButton.Click();
            _browserUtils.SwithToLastTab();
        }

        public override bool IsLoaded()
        {
            return _tabButton.IsDisplayed();
        }
    }
}
