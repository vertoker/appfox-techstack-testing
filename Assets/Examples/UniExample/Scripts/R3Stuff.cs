using System;
using R3;
using UnityEngine;

namespace Examples.UniExample
{
    public class R3Stuff : MonoBehaviour
    {
        private readonly CompositeDisposable disposables = new();
        private readonly Subject<long> updated = new();
        private readonly CompositeDisposable tempDisposable = new();

        // Event, which sended all history to new observer
        private readonly ReplaySubject<long> replayUpdated;
        
        // Classic Reactive Property (also subject)
        private readonly ReactiveProperty<long> frameCounter = new();

        public ReadOnlyReactiveProperty<int> FrameCounter;
        
        
        private void Start()
        {
            // Chapter 1
            
            updated.Where(i => i % 1000 == 0).Subscribe(UpdateFrame).AddTo(disposables);

            // Chapter 2
            
            Observable.Timer(TimeSpan.FromSeconds(2))
                .Subscribe(_ => Debug.Log("Timer after 2 seconds")).AddTo(disposables); // no but ok
            
            Observable.Interval(TimeSpan.FromSeconds(4))
                .Subscribe(_ => Debug.Log("Interval every 4 seconds")).AddTo(disposables); // ok
            
            //Observable.EveryUpdate().Subscribe(_ => Debug.Log("EveryUpdate")).AddTo(disposables); // no
            
            Observable.Interval(TimeSpan.FromSeconds(6))
                .Subscribe(_ =>
                {
                    Debug.Log("Interval (self-disposed) every 6 seconds");
                    tempDisposable.Dispose();
                }).AddTo(tempDisposable); // ok
            
            // Chapter 3
            
            updated.ThrottleFirstFrame(5).Subscribe(_ => Debug.Log("Throttle on 5'th frame")).AddTo(disposables);
            
            updated.ThrottleFirst(TimeSpan.FromSeconds(4)) // limiter
                .Subscribe(_ => Debug.Log("Updated, but ThrottleFirst only once every 4 seconds")).AddTo(disposables);

            updated.Take(5).Subscribe(_ => Debug.Log("Take: first 5 frames")).AddTo(disposables);
            updated.Skip(5).Take(8).Subscribe(_ => 
                Debug.Log("Skip(5) + Take(8): skip first 5 frames, takes next 8 frames")).AddTo(disposables);
            
            //updated.Prepend(10) // UniRX - StartWith
            //    .Subscribe(value => Debug.Log($"Prepend value {value}")).AddTo(disposables);

            //updated.Select();
            
            // Chapter 4

            updated.Chunk(1000).Subscribe(chunk =>
                Debug.Log($"Chunk: Received chunked array with {chunk.Length}")).AddTo(disposables);

            FrameCounter = frameCounter.Select(x => (int)x).ToReadOnlyReactiveProperty();
        }
        private void Update()
        {
            updated.OnNext(frameCounter.Value);
            frameCounter.Value++;
        }
        private void OnDestroy()
        {
            disposables.Dispose();
        }

        private void UpdateFrame(long frame)
        {
            Debug.Log($"Frame Updated: {frame}");
        }
    }
}