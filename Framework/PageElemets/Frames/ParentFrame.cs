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
    public class ParentFrame : BaseForm
    {
        private Text _frameText => _controlsFactory.CreateControl<Text>(_form, "Parent frame body text", By.XPath(".//body"));

        private readonly BrowserUtils _browserUtils;

        public readonly ChildFrame ChildFrame;

        public string IframeLocator => ".//*[@id='frame1']";

        public ParentFrame(ControlsFactory controlsFactory, BrowserUtils browserUtils, ChildFrame childFrame, IWebDriver driver,
            IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger)
        {
            ChildFrame = childFrame;

            _browserUtils = browserUtils;
        }

        public void OpenChildFrame()
        {
            _browserUtils.SwitchToFrame(_form.FindElement(By.XPath(ChildFrame.IframeLocator)));
        }

        public override bool IsLoaded()
        {
            return _frameText.IsDisplayed();
        }

        public string GetFrameText()
        {
            return _frameText.GetText();
        }
    }
}
