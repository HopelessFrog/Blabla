using Core.ServicesProvider;
using Framework.PageElemets;
using Framework.PageElemets.Frames;
using Framework.PageObjects;
using Framework.Services;
using Framework.SetUps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tests.Base;

namespace Tests.Tests
{
    public class IFrameTest : TestBase
    {
        private const string PARENT_FRAME_TEXT = "Parent frame";
        private const string CHILD_FRAME_TEXT = "Child Iframe";

        public IFrameTest() : base(collection => collection
            .AddLoggerScope<IFrameTest>()
            .AddScoped<ISetUp, GoToDemoqaMainPageSetUp>()
            .AddScoped<ISetUp, LogTestCaseInfoSetUp>()
            .AddScoped<HomePage>()
            .AddScoped<BrowserUtils>()
            .AddScoped<Menu>()
            .AddScoped<MainPage>()
            .AddScoped<TopFrame>()
            .AddScoped<BottomFrame>()
            .AddScoped<ParentFrame>()
            .AddScoped<ChildFrame>()
            .AddScoped<NestedFramesForm>()
            .AddScoped<FramesForm>())
        { }

        [Test]
        public void TestIframe()
        {
            _logger?.LogTrace("STEP 1: Go to home page");
            var homePage = Resolve<HomePage>();
            Assert.IsTrue(homePage.IsLoaded(), "Home page is not loaded");
            _logger?.LogTrace("Home page is  opened");

            _logger?.LogTrace("STEP 2: Click on the Alerts, Frame & Windows button. On the page that opens, in the left menu, click on Nested Frames");
            homePage.GoToMainPageAlertsFrameWindows();
            var mainPage = Resolve<MainPage>();
            Assert.IsTrue(mainPage.IsLoaded(), "Main page is not loaded");
            _logger?.LogTrace("Main page is opened");
            mainPage.Menu.GoToNestedFramesForm();
            var nestedFramesForm = Resolve<NestedFramesForm>();
            Assert.IsTrue(nestedFramesForm.IsLoaded());
            _logger?.LogTrace("Nested frames form is opened");
            Assert.IsTrue(nestedFramesForm.GetParentFrameText().Contains(PARENT_FRAME_TEXT), $"Parent frame text not equal:{PARENT_FRAME_TEXT}");
            _logger?.LogInformation($"Parent frame text equal:{PARENT_FRAME_TEXT}");
            Assert.IsTrue(nestedFramesForm.GetChildFrameText().Contains(CHILD_FRAME_TEXT), $"Parent frame text not equal:{CHILD_FRAME_TEXT}");
            _logger?.LogInformation($"Child frame text equal:{CHILD_FRAME_TEXT}");

            _logger?.LogTrace("STEP 3: Select Frames from the left menu");
            nestedFramesForm.Menu.GoToFramesForm();
            var frameForm = Resolve<FramesForm>();
            Assert.IsTrue(mainPage.IsLoaded(), "Frame form is not loaded");
            _logger?.LogTrace("Frame form is opened");
            Assert.That(frameForm.GetTopFrameText(),
                        Is.EqualTo(expected: frameForm.GetBotFrameText()), "Top and bot frames texts is not equal");
            _logger?.LogInformation($"Top ans bot texts is equal");
        }
    }
}
