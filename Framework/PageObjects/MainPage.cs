using Core.Config;
using Framework.Base;
using Framework.Factorys;
using Framework.PageElemets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class MainPage : BaseForm
    {
        public readonly Menu Menu;

        public MainPage(ControlsFactory controlsFactory, Menu menu, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='app']")
        {
            Menu = menu;
        }

        public override bool IsLoaded()
        {
            return Menu.IsLoaded();
        }
    }
}
