using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Examples.UniExample
{
    public class RxStuff : MonoBehaviour
    {
        private void Start()
        {
            var onUpdateStream = Observable.EveryUpdate();
            onUpdateStream.Subscribe(OnUpdate);
            
            var clickStream = onUpdateStream.Where(_ => Input.GetMouseButtonDown(0));
            var mousePressedStream = onUpdateStream.Where(_ => Input.GetMouseButton(0));
            var mergeStream = clickStream.Buffer(clickStream.Throttle(TimeSpan.FromSeconds(1)));
            using var toDispose = clickStream.Subscribe(OnClick); // unsubscribe by end of Start
            mergeStream.Subscribe(OnClickBuffer);
        }
        private void OnUpdate(long frame)
        {
            if (frame % 1000 == 0)
                Debug.Log($"Frame {frame}");
        }
        private void OnClick(long frame)
        {
            Debug.Log($"Click {frame}");
        }
        private void OnClickBuffer(IList<long> clicks)
        {
            Debug.Log($"Clicks count {clicks.Count}");
        }
    }
}