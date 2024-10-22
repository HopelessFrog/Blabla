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
    public class TopFrame : BaseForm
    {
        private readonly BrowserUtils _browserUtils;

        private Text _heading => _controlsFactory.CreateControl<Text>(_form, "Sample heading", By.XPath(".//*[@id='sampleHeading']"));

        public string IframeLocator => ".//*[@id='frame1']";

        public TopFrame(ControlsFactory controlsFactory, BrowserUtils browserUtils, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger)
        {
            _browserUtils = browserUtils;
        }

        public string GetFrameText()
        {
            return _heading.GetText();
        }

        public override bool IsLoaded()
        {
            return _heading.IsDisplayed();
        }
    }
}
