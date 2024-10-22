using Core.ServicesProvider;
using Framework.Helpers;
using Framework.PageElemets;
using Framework.PageObjects;
using Framework.Services;
using Framework.SetUps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tests.Base;

namespace Tests.Tests
{
    public class AlertsTest : TestBase
    {
        private const string DEFAULT_ALERT_TEXT = "You clicked a button";
        private const string CONFIRM_ALERT_TEXT = "Do you confirm action?";
        private const string PROMPT_ALERT_TEXT = "Please enter your name";
        private const string CONFIRM_ALERT_RESULT_TEXT = "You selected Ok";

        private const int RANDOM_TEXT_LENGHT = 10;

        public AlertsTest()
            : base(collection => collection
            .AddLoggerScope<AlertsTest>()
            .AddScoped<ISetUp, GoToDemoqaMainPageSetUp>()
            .AddScoped<ISetUp, LogTestCaseInfoSetUp>()
            .AddScoped<AlertService>()
            .AddScoped<HomePage>()
            .AddScoped<Menu>()
            .AddScoped<MainPage>()
            .AddScoped<AlertsForm>())
        { }

        [Test]
        public void TestAlerts()
        {
            _logger?.LogTrace("STEP 1: Go to home page");
            var homePage = Resolve<HomePage>();
            Assert.IsTrue(homePage.IsLoaded(), "Home page is not loaded");
            _logger?.LogTrace("Home page is  opened");

            _logger?.LogTrace("STEP 2: Click on the Alerts, Frame & Windows button. On the page that opens, in the left menu, click Alerts");
            homePage.GoToMainPageAlertsFrameWindows();
            var mainPage = Resolve<MainPage>();
            Assert.IsTrue(mainPage.IsLoaded(), "Main page is not loaded");
            _logger?.LogTrace("Main page is opened");
            mainPage.Menu.GotToAlertsForm();
            var alertsForm = Resolve<AlertsForm>();
            Assert.IsTrue(alertsForm.IsLoaded(), "Alerts form is not loaded");
            _logger?.LogTrace("Alert form is opened");

            _logger?.LogTrace("STEP 3: Click on the Click Button to see alert");
            alertsForm.ClickDefaultAlertButton();
            var alertsService = Resolve<AlertService>();
            Assert.IsTrue(alertsService.IsDisplayed(), "Default alert did not displayed");
            _logger?.LogTrace("Default alert is displayed");
            Assert.IsTrue(alertsService.GetText().Contains(DEFAULT_ALERT_TEXT), "Wrong default alert text");
            _logger?.LogInformation($"Alert text  equal {DEFAULT_ALERT_TEXT}");

            _logger?.LogTrace("STEP 4: Click on the OK button");
            alertsService.Accept();
            Assert.IsFalse(alertsService.IsDisplayed(), "Default alert did not close");
            _logger?.LogTrace("Default alert is closed");

            _logger?.LogTrace("STEP 5: Click On button click, confirm box will appear");
            alertsForm.ClickConfirmAlertButton();
            Assert.IsTrue(alertsService.IsDisplayed(), "Confirm alert did not displayed");
            _logger?.LogTrace("Confirm alert is displayed");
            Assert.IsTrue(alertsService.GetText().Contains(CONFIRM_ALERT_TEXT), "Wrong confirm alert text");
            _logger?.LogInformation($"Confirm alert text  equal {CONFIRM_ALERT_TEXT}");

            _logger?.LogTrace("STEP 6: Click on the OK button");
            alertsService.Accept();
            Assert.IsFalse(alertsService.IsDisplayed(), "Confirm alert did not close");
            _logger?.LogTrace("Confirm alert is closed");
            Assert.IsTrue(alertsForm.GetAlertConfirmResultText().Contains(CONFIRM_ALERT_RESULT_TEXT), "Wrong confirm alert result text");
            _logger?.LogInformation($"Confirm alert result text  equal {CONFIRM_ALERT_RESULT_TEXT}");

            _logger?.LogTrace("STEP 7: Click on the button On button click, prompt box will appear");
            alertsForm.ClickPromtAlertButton();
            Assert.IsTrue(alertsService.IsDisplayed(), "Prompt alert did not displayed");
            _logger?.LogTrace("Prompt alert is displayed");
            Assert.IsTrue(alertsService.GetText().Contains(PROMPT_ALERT_TEXT), "Wrong prompt alert text");
            _logger?.LogInformation($"Prompt alert text  equal {PROMPT_ALERT_TEXT}");

            _logger?.LogTrace("STEP 8: Enter randomly generated text, click on the OK button");
            var randomText = GenerateRandomTextHelper.GenerateRandomText(RANDOM_TEXT_LENGHT);
            alertsService.InputText(randomText);
            alertsService.Accept();
            Assert.IsFalse(alertsService.IsDisplayed(), "Prompt alert did not close");
            _logger?.LogTrace("Prompt alert is closed");
            Assert.IsTrue(alertsForm.GetAlertPromptResultText().Contains(randomText), "Entered and received text is not equal");
            _logger?.LogInformation($"Entered and received text is  equal: {randomText}");
        }
    }
}