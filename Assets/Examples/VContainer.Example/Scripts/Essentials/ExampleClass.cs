using UnityEngine;

namespace Examples.VContainer.Example.Essentials
{
    public class ExampleClass : IExample
    {
        public ExampleClass(GenericType<int> genericType)
        {
            genericType.Print();
        }

        public void Example()
        {
            Debug.Log("Example");
        }
    }
}