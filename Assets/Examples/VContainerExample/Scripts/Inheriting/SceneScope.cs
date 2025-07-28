using VContainer;
using VContainer.Unity;

namespace Examples.VContainerExample.Inheriting
{
    public class SceneScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Service2>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Service2>();
        }
    }
}