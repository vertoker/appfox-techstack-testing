using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Examples.UniExample
{
    public class OnStartAwaitSomething : MonoBehaviour
    {
        private async void Start()
        {
            Func<UniTask> awaitLambda = async () =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                Debug.Log("Lambda");
            };
            
            await TestAwait();
            await awaitLambda();
            try
            {
                LoopUntilDestroy();
            }
            finally
            {
                Debug.Log("EndOfObject");
            }
        }

        private async UniTask TestAwait()
        {
            var task1 = UniTask.Delay(TimeSpan.FromSeconds(1));
            await task1;
            Debug.Log("Start");
        }
        private async void LoopUntilDestroy()
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: destroyCancellationToken);
                Debug.Log("Loop");
            }
        }
    }
}