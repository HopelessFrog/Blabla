using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class SamplePage : BaseForm
    {
        private Text _text => _controlsFactory.CreateControl<Text>(_form, "Sample heading", By.XPath(".//*[contains(text(),'sample')]"));

        public SamplePage(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger)
        {
        }

        public override bool IsLoaded()
        {
            return _text.IsDisplayed();
        }
    }
}
