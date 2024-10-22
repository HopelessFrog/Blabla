using Core.Config;
using Framework.Base;
using Framework.Controls;
using Framework.Factorys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Framework.PageElemets
{
    public class RegistrationForm : BaseForm
    {
        private Input _firstName => _controlsFactory.CreateControl<Input>(_form, "First name input", By.XPath(".//*[@id='firstName']"));
        private Input _lastName => _controlsFactory.CreateControl<Input>(_form, "Last name input", By.XPath(".//*[@id='lastName']"));
        private Input _email => _controlsFactory.CreateControl<Input>(_form, "Email input", By.XPath(".//*[@id='userEmail']"));
        private Input _age => _controlsFactory.CreateControl<Input>(_form, "Age input", By.XPath(".//*[@id='age']"));
        private Input _salary => _controlsFactory.CreateControl<Input>(_form, "Salaty input", By.XPath(".//*[@id='salary']"));
        private Input _department => _controlsFactory.CreateControl<Input>(_form, "Department input", By.XPath(".//*[@id='department']"));

        private Button _submit => _controlsFactory.CreateControl<Button>(_form, "Submit button", By.XPath(".//*[@id='submit']"));

        public RegistrationForm(ControlsFactory controlsFactory, IWebDriver driver, IOptionsSnapshot<BrowserConfiguration> config, ILogger? logger = null)
            : base(controlsFactory, driver, config, logger, "//*[@id='userForm']")
        {
        }

        public override bool IsLoaded()
        {
            return _firstName.IsDisplayed();
        }

        public void InputFirstName(string text)
        {
            _firstName.InputText(text);
        }

        public void InputLastName(string text)
        {
            _lastName.InputText(text);
        }

        public void InputEmail(string text)
        {
            _email.InputText(text);
        }

        public void InputAge(string text)
        {
            _age.InputText(text);
        }

        public void InputSalary(string text)
        {
            _salary.InputText(text);
        }

        public void InputDepartment(string text)
        {
            _department.InputText(text);
        }

        public void Submit()
        {
            _submit.Click();
        }
    }
}
