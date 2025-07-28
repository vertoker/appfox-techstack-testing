using UnityEngine;

namespace Examples.VContainerExample.Hello
{
    public class HelloWorldService
    {
        public void Hello(string helloText)
        {
            Debug.Log($"Hello {helloText}");
        }
    }
}