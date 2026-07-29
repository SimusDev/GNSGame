using Common.Core;
using Common.Core.Debug;
using LiteNetLib;

namespace Common.Network
{
    public class ClientMultiplayerAPI : MultiplayerAPI
    {
        public void Send(byte[] data, byte channel, SendMode mode)
        {

        }

        public void ConnectToServer(string address, int port)
        {
            NetPeer peer = _netManager!.Connect(address, port, GetConnectionKey());
            if (peer != null)
                Logger.Print($"Starting connection to {address}:{port}...");
        }

    }
}
