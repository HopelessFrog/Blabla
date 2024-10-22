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
    public class LinksForm : BaseForm
    {
        private readonly BrowserUtils _browserUtils;

        public readonly Menu Menu;

        private Link _homeLink => _controlsFactory.CreateControl<Link>(_form, "Home link", By.XPath(".//*[@id='simpleLink']"));

        public LinksForm(ControlsFactory controlsFactory, BrowserUtils utils, Menu menu, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='linkWrapper']")
        {
            Menu = menu;
            _browserUtils = utils;
        }

        public override bool IsLoaded()
        {
            return _homeLink.IsDisplayed();
        }

        public void OpenHomePage()
        {
            _homeLink.Click();
            _browserUtils.SwithToLastTab();
        }
    }
}
