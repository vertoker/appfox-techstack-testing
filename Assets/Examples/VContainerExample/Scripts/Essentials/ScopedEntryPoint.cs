using VContainer.Unity;

namespace Examples.VContainerExample.Essentials
{
    public class ScopedEntryPoint : IStartable
    {
        private readonly IExample example;
        private readonly Example2 example2;

        public ScopedEntryPoint(IExample example, Example2 example2)
        {
            this.example = example;
            this.example2 = example2;
        }

        public void Start()
        {
            example.Example();
            example2.Example();
        }
    }
}