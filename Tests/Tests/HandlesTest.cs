using Core.ServicesProvider;
using Framework.PageElemets;
using Framework.PageObjects;
using Framework.Services;
using Framework.SetUps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tests.Base;

namespace Tests.Tests
{
    public class HandlesTest : TestBase
    {
        public HandlesTest() : base(collection => collection
        .AddLoggerScope<HandlesTest>()
        .AddScoped<ISetUp, GoToDemoqaMainPageSetUp>()
        .AddScoped<ISetUp, LogTestCaseInfoSetUp>()
        .AddScoped<Menu>()
        .AddScoped<MainPage>()
        .AddScoped<HomePage>()
        .AddScoped<BrowserWindowsForm>()
        .AddScoped<BrowserUtils>()
        .AddScoped<SamplePage>()
        .AddScoped<LinksForm>())
        { }

        [Test]
        public void TestHandles()
        {
            _logger?.LogTrace("STEP 1: Go to home page");
            var homePage = Resolve<HomePage>();
            Assert.IsTrue(homePage.IsLoaded(), "Home page is not loaded");
            _logger?.LogTrace("Home page is  opened");

            _logger?.LogTrace("STEP 2: Click on the Alerts, Frame & Windows button. On the page that opens, in the left menu, click Browser Windows");
            homePage.GoToMainPageAlertsFrameWindows();
            var mainPage = Resolve<MainPage>();
            Assert.IsTrue(mainPage.IsLoaded(), "Main page is not loaded");
            _logger?.LogTrace("Main page is opened");
            mainPage.Menu.GoToBrowserWindowsForm();
            var browserWindowsForm = Resolve<BrowserWindowsForm>();
            Assert.IsTrue(browserWindowsForm.IsLoaded(), "Browser windows form is not loaded");
            _logger?.LogTrace("Browser windows form is opened");

            _logger?.LogTrace("STEP 3: Click on the New Tab button");
            browserWindowsForm.CreateNewTab();
            var samplePage = Resolve<SamplePage>();
            Assert.IsTrue(samplePage.IsLoaded(), "Sample page is not loaded");
            _logger?.LogTrace("Sample page is opened");

            _logger?.LogTrace("STEP 4: Close the current tab");
            Resolve<BrowserUtils>().CloseCurrentTab();
            Assert.IsTrue(browserWindowsForm.IsLoaded(), "Browser windows form is not loaded");
            _logger?.LogTrace("Browser windows form is opened");

            _logger?.LogTrace("STEP 5: In the left menu select Elements → Links");
            browserWindowsForm.Menu.GoToLinksForm();
            var linkForm = Resolve<LinksForm>();
            Assert.IsTrue(linkForm.IsLoaded(), "Link form is not loaded");
            _logger?.LogTrace("Link form is opened");

            _logger?.LogTrace("STEP 6: Go to the Home link");
            var currentTab = Resolve<BrowserUtils>().CurrentTab;
            linkForm.OpenHomePage();
            Assert.IsTrue(homePage.IsLoaded(), "Home page is not loaded");
            _logger?.LogTrace("Home page is  opened");

            _logger?.LogTrace("STEP 7: Switch to previous tab");
            Resolve<BrowserUtils>().SwapTabTo(currentTab);
            Assert.IsTrue(linkForm.IsLoaded(), "Link form is not loaded");
            _logger?.LogTrace("Link form is opened");
        }
    }
}
