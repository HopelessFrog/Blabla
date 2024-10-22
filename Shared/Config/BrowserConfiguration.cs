using Core.DriverFactorys;
using OpenQA.Selenium;

namespace Core.Config
{
    public class BrowserConfiguration
    {
        public string Url { get; set; }
        public int Delay { get; set; }
        public BrowserType Browser { get; set; }
        public string Lang { get; set; }
        public PageLoadStrategy PageLoadStrategy { get; set; }
    }
}
