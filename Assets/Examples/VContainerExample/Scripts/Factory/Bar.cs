using UnityEngine;

namespace Examples.VContainerExample.Factory
{
    public class Bar
    {
        private readonly int number;

        public Bar(int number)
        {
            this.number = number;
        }

        public void Show() => Debug.Log(number);
    }
}