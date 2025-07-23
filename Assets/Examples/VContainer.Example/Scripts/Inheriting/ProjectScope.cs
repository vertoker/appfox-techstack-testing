using VContainer;
using VContainer.Unity;

namespace Examples.VContainer.Example.Inheriting
{
    public class ProjectScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Service1>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Service1>();
        }
    }
}