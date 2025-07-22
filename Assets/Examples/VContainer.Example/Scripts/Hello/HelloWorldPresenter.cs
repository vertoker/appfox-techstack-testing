using System;
using VContainer.Unity;

namespace Examples.VContainer.Example.Hello
{
    public class HelloWorldPresenter : IStartable, IDisposable
    {
        private readonly HelloWorldService helloWorldService;
        private readonly HelloView helloView;

        public HelloWorldPresenter(HelloWorldService helloWorldService, 
            HelloView helloView)
        {
            this.helloWorldService = helloWorldService;
            this.helloView = helloView;
        }

        public void Start()
        {
            helloView.btn.onClick.AddListener(() => helloWorldService.Hello("Btn"));
            helloWorldService.Hello("Start");
        }
        public void Dispose()
        {
            helloWorldService.Hello("Dispose");
        }
    }
}