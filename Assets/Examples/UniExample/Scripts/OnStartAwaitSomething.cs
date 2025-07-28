using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Examples.UniExample
{
    public class OnStartAwaitSomething : MonoBehaviour
    {
        private async void Start()
        {
            await TestAwait();
        }

        private async UniTask TestAwait()
        {
            var task1 = UniTask.Delay(TimeSpan.FromSeconds(1));
            await task1;
            Debug.Log("Start");
        }
    }
}