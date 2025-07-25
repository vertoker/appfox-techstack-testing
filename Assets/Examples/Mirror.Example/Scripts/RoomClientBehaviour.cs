using Mirror;
using UnityEngine;

namespace Examples.Mirror.Example
{
    public class RoomClientBehaviour : NetworkRoomPlayer
    {
        [SerializeField] private GameObject playerPrefab;
        
        public override void OnStartAuthority()
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
    }
}