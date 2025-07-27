using Mirror;
using UnityEngine;

namespace Examples.Mirror.Example
{
    public class RoomClientBehaviour : NetworkRoomPlayer
    {
        [SerializeField] private GameObject playerPrefab;

        public override void OnStartLocalPlayer()
        {
            //Debug.Log(isClient);
            //Ready();
            //CmdSpawnPlayer();
        }

        [Command]
        private void CmdSpawnPlayer()
        {
            Debug.Log(nameof(CmdSpawnPlayer));
            var playerObj = Instantiate(playerPrefab);
            NetworkServer.Spawn(playerObj, netIdentity.connectionToClient);
        }

        [ContextMenu(nameof(Ready))]
        public void Ready()
        {
            if (!NetworkClient.ready)
                NetworkClient.Ready();
        }
        [ContextMenu(nameof(RoomReady))]
        public void RoomReady()
        {
            CmdChangeReadyState(true);
        }
    }
}