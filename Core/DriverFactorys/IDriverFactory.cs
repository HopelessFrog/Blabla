using OpenQA.Selenium;

namespace Core.DriverFactorys
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
}