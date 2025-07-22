using UnityEngine;

namespace Examples.VContainer.Example.Essentials
{
    public class Example2 : IExample
    {
        private readonly GenericType<ExampleClass> genericType;

        public Example2(GenericType<ExampleClass> genericType, string url)
        {
            this.genericType = genericType;
            Debug.Log(url);
        }

        public void Example()
        {
            genericType.Print();
        }
    }
}