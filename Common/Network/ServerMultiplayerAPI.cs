using Common.Core;
using LiteNetLib;

namespace Common.Network
{
    public class ServerMultiplayerAPI : MultiplayerAPI
    {

        public void CreateServer(int port)
        {
            bool status = _netManager!.Start(port);
            if (status)
                Logger.Print("Server Listening on port ", port);
        }

        public void SendTo()
        {

        }
    }
}
