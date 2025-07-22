using UnityEngine;

namespace Examples.VContainer.Example.Hello
{
    public class HelloWorldService
    {
        public void Hello(string helloText)
        {
            Debug.Log($"Hello {helloText}");
        }
    }
}