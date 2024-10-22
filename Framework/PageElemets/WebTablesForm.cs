using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class WebTablesForm : BaseForm
    {
        public readonly UserTableForm UserTable;

        public readonly Menu Menu;

        private Button _addButton => _controlsFactory.CreateControl<Button>(_form, "Add record button", By.XPath(".//*[@id='addNewRecordButton']"));

        public WebTablesForm(ControlsFactory controlsFactory, Menu menu, UserTableForm userTableForm, IWebDriver driver,
            IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[contains(@class,'web-tables-wrapper')]")
        {
            Menu = menu;

            UserTable = userTableForm;
        }

        public override bool IsLoaded()
        {
            return _addButton.IsDisplayed();
        }

        public void OpenRegisterUserForm()
        {
            _addButton.Click();
        }
    }
}
