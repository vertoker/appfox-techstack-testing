using System;
using VContainer.Unity;

namespace Examples.VContainer.Example.Factory
{
    public class FactoryEntryPoint : IStartable
    {
        private readonly Func<Class1, Class2> factory;
        private readonly Func<int, Bar> factory2;

        public FactoryEntryPoint(Func<Class1, Class2> factory, Func<int, Bar> factory2)
        {
            this.factory = factory;
            this.factory2 = factory2;
        }
        
        public void Start()
        {
            var c2 = factory.Invoke(new Class1());
            c2.Hi();
            var bar = factory2.Invoke(1);
            bar.Show();
        }
    }
}