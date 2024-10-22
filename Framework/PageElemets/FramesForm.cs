using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Framework.PageElemets.Frames;
using Framework.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class FramesForm : BaseForm
    {
        private Div _frameWrapper2 => _controlsFactory.CreateControl<Div>(_form, "Frame wrapper №2", By.XPath(".//*[@id='frame2Wrapper']"));

        private readonly TopFrame _topFrame;
        private readonly BottomFrame _botFrame;

        public readonly Menu Menu;

        private readonly BrowserUtils _browserUtils;

        public FramesForm(ControlsFactory controlsFactory, BottomFrame bottomFrame, TopFrame topFrame, BrowserUtils browserUtils, Menu menu,
            IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='framesWrapper']")
        {
            Menu = menu;

            _topFrame = topFrame;
            _botFrame = bottomFrame;

            _browserUtils = browserUtils;
        }

        public string GetTopFrameText()
        {
            _browserUtils.SwitchToFrame(_form.FindElement(By.XPath(_topFrame.IframeLocator)));
            var frameText = _topFrame.GetFrameText();
            _browserUtils.LeaveFrames();
            return frameText;
        }

        public string GetBotFrameText()
        {
            _browserUtils.SwitchToFrame(_form.FindElement(By.XPath(_botFrame.IframeLocator)));
            var frameText = _botFrame.GetFrameText();
            _browserUtils.LeaveFrames();
            return frameText;
        }

        public override bool IsLoaded()
        {
            return _frameWrapper2.IsDisplayed();
        }
    }
}
