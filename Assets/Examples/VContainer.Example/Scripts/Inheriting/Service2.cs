using System;
using UnityEngine;
using VContainer.Unity;

namespace Examples.VContainer.Example.Inheriting
{
    public class Service2 : IStartable, IDisposable
    {
        private readonly Service1 service1;

        public Service2(Service1 service1)
        {
            this.service1 = service1;
        }

        public void Start()
        {
            Debug.Log("Scene Start");
            Hello();
        }
        public void Hello()
        {
            service1.Hello();
            Debug.Log("Hello 2");
        }
        public void Dispose()
        {
            Debug.Log("Scene Dispose");
        }
    }
}