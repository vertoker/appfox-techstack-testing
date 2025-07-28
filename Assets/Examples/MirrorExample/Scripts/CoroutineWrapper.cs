using System.Collections;
using UnityEngine;

namespace Examples.MirrorExample
{
    public class CoroutineWrapper
    {
        private readonly MonoBehaviour behaviour;
        private Coroutine coroutine = null;

        public CoroutineWrapper(MonoBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public void Start(IEnumerator routine)
        {
            Stop();
            StartImpl(routine);
        }
        public void Stop()
        {
            if (coroutine != null)
                StopImpl();
        }
        public bool IsRunning() => coroutine != null;

        private void StartImpl(IEnumerator routine)
        {
            coroutine = behaviour.StartCoroutine(routine);
        }
        private void StopImpl()
        {
            behaviour.StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}