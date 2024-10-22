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
    public class NestedFramesForm : BaseForm
    {
        private readonly ParentFrame _parentFrame;

        private readonly BrowserUtils _browserUtils;

        public readonly Menu Menu;

        private Text _title => _controlsFactory.CreateControl<Text>(_form, "Nested Frames title", By.XPath(".//*[contains(text(),'Nested Frames')]"));

        public NestedFramesForm(ControlsFactory controlsFactory, Menu menu, BrowserUtils browserUtils, ParentFrame parentFrame, ChildFrame childFrame,
            IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='framesWrapper']")
        {
            Menu = menu;

            _parentFrame = parentFrame;

            _browserUtils = browserUtils;
        }

        public string GetParentFrameText()
        {
            _browserUtils.SwitchToFrame(_form.FindElement(By.XPath(_parentFrame.IframeLocator)));
            var parentText = _parentFrame.GetFrameText();
            _browserUtils.LeaveFrames();
            return parentText;
        }

        public string GetChildFrameText()
        {
            _browserUtils.SwitchToFrame(_form.FindElement(By.XPath(_parentFrame.IframeLocator)));
            _parentFrame.OpenChildFrame();
            var childFrameText = _parentFrame.ChildFrame.GetFrameText();
            _browserUtils.LeaveFrames();
            return childFrameText;
        }

        public override bool IsLoaded()
        {
            return _title.IsDisplayed();
        }
    }
}
