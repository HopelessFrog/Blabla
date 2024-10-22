using Core.Config;
using Framework.Base;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using Shared;

namespace Framework.PageElemets
{
    public class UserTableForm : BaseForm
    {
        public UserTableForm(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[contains(@class,'rt-table')]")
        {
        }

        public IWebElement? FindRecord(UserData userData)
        {
            try
            {
                return _form.FindElement(By.XPath($".//*[contains(@class,'rt-tr') and .//*[contains(text(),'{userData.FirsName}')]" +
                    $" and .//*[contains(text(),'{userData.LastName}')] and .//*[contains(text(),'{userData.Email}')]" +
                    $"and .//*[contains(text(),'{userData.Age}')] and .//*[contains(text(),'{userData.Department}')] and .//*[contains(text(),'{userData.Salary}')]]"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteTableItem(IWebElement item)
        {
            item.FindElement(By.XPath(".//*[contains(@id,'delete-record')]")).Click();
        }

        public int GetRecordsCount()
        {
            var records = _form.FindElements(By.XPath(".//*[contains(@class,'rt-tr ') and not(contains(@class,'-padRow'))]"));
            return records.Count();
        }

        public override bool IsLoaded()
        {
            return _form.Displayed;
        }
    }
}
