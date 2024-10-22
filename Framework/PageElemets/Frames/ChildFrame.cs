using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Framework.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets.Frames
{
    public class ChildFrame : BaseForm
    {
        private readonly BrowserUtils _browserUtils;

        private Text _body => _controlsFactory.CreateControl<Text>(_form, "Child frame body text", By.XPath(".//body"));

        public string IframeLocator => ".//iframe";

        public ChildFrame(ControlsFactory controlsFactory, BrowserUtils browserUtils, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger)
        {
            _browserUtils = browserUtils;
        }

        public override bool IsLoaded()
        {
            return _body.IsDisplayed();
        }

        public string GetFrameText()
        {
            return _body.GetText();
        }
    }
}
