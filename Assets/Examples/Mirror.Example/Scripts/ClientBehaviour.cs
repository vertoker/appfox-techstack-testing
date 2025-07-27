using Mirror;
using UnityEngine;

namespace Examples.Mirror.Example
{
    public class ClientBehaviour : NetworkBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        
        public override void OnStartLocalPlayer()
        {
            Debug.Log(isClient);
            CmdSpawnPlayer();
        }

        [Command]
        private void CmdSpawnPlayer()
        {
            Debug.Log(nameof(CmdSpawnPlayer));
            var playerObj = Instantiate(playerPrefab, transform);
            NetworkServer.Spawn(playerObj, netIdentity.connectionToClient);
        }
        
        [ContextMenu(nameof(Ready))]
        public void Ready()
        {
            NetworkClient.Ready();
        }
    }
}
