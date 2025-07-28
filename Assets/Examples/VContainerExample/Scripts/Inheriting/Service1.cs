using System;
using UnityEngine;
using VContainer.Unity;

namespace Examples.VContainerExample.Inheriting
{
    public class Service1 : IStartable, IDisposable
    {
        public void Start()
        {
            Debug.Log("Project Start");
        }
        public void Hello()
        {
            Debug.Log("Hello 1");
        }
        public void Dispose()
        {
            Debug.Log("Project Dispose");
        }
    }
}