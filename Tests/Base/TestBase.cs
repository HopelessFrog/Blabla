using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Interfaces;

namespace Tests.Base
{
    public abstract class TestBase : FixtureBase
    {
        protected ILogger? _logger { get; set; }

        public TestBase(Action<IServiceCollection> configure) : base(configure)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _logger = Resolve<ILogger>();
            _logger?.LogTrace(TestContext.CurrentContext.Test.Name + " started");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                _logger?.LogError($"{TestContext.CurrentContext.Test.Name} failed.\n{TestContext.CurrentContext.Result.Message}\n");
            }
            else
            {
                _logger?.LogInformation($"{TestContext.CurrentContext.Test.Name} success.\n");
            }
        }
    }
}
