using VContainer;
using VContainer.Unity;

namespace Examples.VContainer.Example.Factory
{
    public class FactoryScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<Class1>(Lifetime.Singleton);

            builder.RegisterFactory<Class1, Class2>(container =>
            {
                //var c1 = container.Resolve();
                return c1 => new Class2(c1);
            }, Lifetime.Scoped);
            
            builder.Register<BarFactory>(Lifetime.Singleton);
            builder.RegisterFactory<int, Bar>(container => 
                container.Resolve<BarFactory>().Create, Lifetime.Singleton);

            builder.RegisterEntryPoint<FactoryEntryPoint>();
        }
    }
}