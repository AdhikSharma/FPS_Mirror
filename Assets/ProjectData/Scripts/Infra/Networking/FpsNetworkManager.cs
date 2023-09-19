using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Adhik.Infra.Networking
{
    public class FpsNetworkManager : NetworkManager
    {
        public override void OnStartClient()
        {
            base.OnStartClient();
        }

        public override void OnStartHost()
        {
            base.OnStartHost();
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
        }

        public override void OnStopHost()
        {
            base.OnStopHost();
        }

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);
        }

        private void SpawnPlayerOnServer()
        {

        }
    }
}