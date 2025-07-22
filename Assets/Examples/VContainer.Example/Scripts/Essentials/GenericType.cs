using UnityEngine;

namespace Examples.VContainer.Example.Essentials
{
    public class GenericType<T>
    {
        public GenericType()
        {
            
        }

        public void Print() => Debug.Log($"My type is {typeof(T).Name}");
    }
}