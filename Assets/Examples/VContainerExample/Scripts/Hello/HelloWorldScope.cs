using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Examples.VContainerExample.Hello
{
    public class HelloWorldScope : LifetimeScope
    {
        [SerializeField] private HelloView helloView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HelloWorldService>(Lifetime.Singleton);
            //builder.Register<HelloWorldPresenter>(Lifetime.Singleton);
            builder.RegisterComponent(helloView);
            builder.RegisterEntryPoint<HelloWorldPresenter>();
        }
    }
}