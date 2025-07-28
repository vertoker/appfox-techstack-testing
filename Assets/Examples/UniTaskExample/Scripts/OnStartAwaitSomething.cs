using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Examples.UniTaskExample
{
    public class OnStartAwaitSomething : MonoBehaviour
    {
        private async void Start()
        {
            var task1 = UniTask.Delay(TimeSpan.FromSeconds(1));
            await task1;
            await task1;
        }
    }
}