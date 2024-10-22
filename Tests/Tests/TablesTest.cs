using Core.ServicesProvider;
using Framework.DataSources;
using Framework.PageElemets;
using Framework.PageObjects;
using Framework.SetUps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using Tests.Base;

namespace Tests.Tests
{

    public class TablesTest : TestBase
    {
        public TablesTest() : base(collection => collection
        .AddScoped<ISetUp, GoToDemoqaMainPageSetUp>()
        .AddScoped<ISetUp, LogTestCaseInfoSetUp>()
        .AddLoggerScope<TablesTest>()
        .AddScoped<HomePage>()
        .AddScoped<Menu>()
        .AddScoped<UserTableForm>()
        .AddScoped<MainPage>()
        .AddScoped<WebTablesForm>()
        .AddScoped<RegistrationForm>())
        { }

        [Test, TestCaseSource(typeof(UserDataSource<UserData>))]
        public void TestTables(UserData userData)
        {
            _logger?.LogTrace("STEP 1: Go to home page");
            var homePage = Resolve<HomePage>();
            Assert.IsTrue(homePage.IsLoaded(), "Home page is not loaded");
            _logger?.LogTrace("Home page is  opened");

            _logger?.LogTrace("STEP 2: Click on the Elements button.On the page that opens, in the left menu, click Web Tables");
            homePage.GoToMainPageElements();
            var mainPage = Resolve<MainPage>();
            Assert.IsTrue(mainPage.IsLoaded(), "Main page is not loaded");
            _logger?.LogTrace("Main page is opened");
            mainPage.Menu.GoToWebTablesForm();
            var webTablesForm = Resolve<WebTablesForm>();
            Assert.IsTrue(webTablesForm.IsLoaded(), "Web tables form is not loaded");
            _logger?.LogTrace("Web tables form is opened");

            _logger?.LogTrace("STEP 3: Click on the Add button");
            webTablesForm.OpenRegisterUserForm();
            var registrationForm = Resolve<RegistrationForm>();
            Assert.IsTrue(registrationForm.IsLoaded(), "Registration form is not loaded");
            _logger?.LogTrace("Registration form is opened");

            _logger?.LogTrace("STEP 4: Enter user data User No. from the table and then click on the Submit button");
            registrationForm.InputFirstName(userData.FirsName);
            registrationForm.InputLastName(userData.LastName);
            registrationForm.InputEmail(userData.Email);
            registrationForm.InputAge(userData.Age);
            registrationForm.InputSalary(userData.Salary);
            registrationForm.InputDepartment(userData.Department);
            registrationForm.Submit();
            var record = webTablesForm.UserTable.FindRecord(userData);
            Assert.IsNotNull(record, "User was not added to the table");
            _logger?.LogInformation("User was  added to the table");

            _logger?.LogTrace("STEP 5: Click on the Delete button in the User line №");
            var count = webTablesForm.UserTable.GetRecordsCount();
            webTablesForm.UserTable.DeleteTableItem(record);
            var afterDeleteCount = webTablesForm.UserTable.GetRecordsCount();
            Assert.That(afterDeleteCount, Is.Not.EqualTo(count), "Count does not changed");
            _logger?.LogInformation($"Records count changed from {count} to {afterDeleteCount}");
            var afterDeleteRecord = webTablesForm.UserTable.FindRecord(userData);
            Assert.IsNull(afterDeleteRecord, "User has not been removed");
            _logger?.LogInformation($"User has  been removed");
        }
    }
}
