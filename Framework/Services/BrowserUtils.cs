using OpenQA.Selenium;

namespace Framework.Services
{
    public class BrowserUtils
    {
        private readonly IWebDriver _driver;

        public string CurrentTab => _driver.CurrentWindowHandle;

        public BrowserUtils(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CloseCurrentTab()
        {
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public void SwapTabTo(string tab)
        {
            _driver.SwitchTo().Window(tab);
        }

        public void SwithToLastTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public void SwitchToFrame(IWebElement frame)
        {
            _driver.SwitchTo().Frame(frame);
        }

        public void LeaveFrames()
        {
            _driver.SwitchTo().DefaultContent();
        }
    }
}
