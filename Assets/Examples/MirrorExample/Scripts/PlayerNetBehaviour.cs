using System.Collections;
using Mirror;
using UnityEngine;

namespace Examples.MirrorExample
{
    public class PlayerNetBehaviour : NetworkBehaviour
    {
        [SerializeField] private Vector2 velocity = new(0.1f, 0.1f);
        
        private CoroutineWrapper wrapper;

        private void Awake()
        {
            wrapper = new CoroutineWrapper(this);
        }
        
        public override void OnStartAuthority()
        {
            wrapper.Start(Loop());
        }
        public override void OnStopAuthority()
        {
            wrapper.Stop();
        }
        public override void OnStopClient()
        {
            wrapper.Stop();
        }

        private IEnumerator Loop()
        {
            while (true)
            {
                var move = Vector3.zero;
                if (Input.GetKey(KeyCode.W)) move.z += velocity.y;
                if (Input.GetKey(KeyCode.S)) move.z -= velocity.y;
                if (Input.GetKey(KeyCode.D)) move.x += velocity.x;
                if (Input.GetKey(KeyCode.A)) move.x -= velocity.x;
                transform.position += move;
                
                yield return new WaitForSeconds(1f / 60f);
            }
        }
    }
}