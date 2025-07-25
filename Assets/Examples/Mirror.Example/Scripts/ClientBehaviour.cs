using Mirror;
using UnityEngine;

namespace Examples.Mirror.Example
{
    public class ClientBehaviour : NetworkBehaviour
    {
        public override void OnStartServer()
        {
            Debug.Log(nameof(OnStartServer), gameObject);
        }
        public override void OnStopServer()
        {
            Debug.Log(nameof(OnStopServer), gameObject);
        }
    
        public override void OnStartClient()
        {
            Debug.Log(nameof(OnStartClient), gameObject);
        }
        public override void OnStopClient()
        {
            Debug.Log(nameof(OnStopClient), gameObject);
        }

        public override void OnStartAuthority()
        {
            Debug.Log(nameof(OnStartAuthority), gameObject);
        }
        public override void OnStopAuthority()
        {
            Debug.Log(nameof(OnStopAuthority), gameObject);
        }
    }
}
