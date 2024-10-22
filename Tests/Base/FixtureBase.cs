using Core.ServicesProvider;
using Framework.SetUps;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Base
{
    public abstract class FixtureBase
    {
        private readonly ServiceProvider serviceProvider;

        private IServiceScope serviceScope;

        protected FixtureBase(Action<IServiceCollection> configure)
        {
            serviceProvider = new ServiceсProviderBuilder().Build(configure);
        }

        [SetUp]
        public void Setup()
        {
            serviceScope = serviceProvider.CreateScope();
            foreach (var setUp in serviceScope.ServiceProvider.GetServices<ISetUp>())
                setUp.SetUp();
        }

        [TearDown]
        public void DisposeScope() => serviceScope.Dispose();

        [OneTimeTearDown]
        public void DisposeContainer() => serviceProvider.Dispose();

        protected T Resolve<T>() => serviceScope.ServiceProvider.GetService<T>();
    }
}
