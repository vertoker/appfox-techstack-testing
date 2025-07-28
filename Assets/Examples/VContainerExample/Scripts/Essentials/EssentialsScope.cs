using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Examples.VContainerExample.Essentials
{
    public class EssentialsScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(typeof(GenericType<>), Lifetime.Singleton); // Experimental
            
            //builder.Register<IExample, ExampleClass>(Lifetime.Singleton);
            builder.Register<ExampleClass>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<Example2>(Lifetime.Singleton)
                .WithParameter("url", "https://example.com");

            builder.Register<IFoo>(container =>
            {
                var foo = new Foo();
                return foo;
            }, Lifetime.Scoped);
            
            builder.RegisterEntryPointExceptionHandler(ex =>
            {
                Debug.LogError("Hahaha");
                Debug.LogException(ex);
            });
            
            builder.UseEntryPoints(ep =>
            {
                ep.Add<ScopedEntryPoint>();
                ep.OnException(ex =>
                {
                    Debug.LogException(ex);
                    Debug.Log("loh");
                });
            });
        }
    }
}