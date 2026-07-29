using Common.Core.Debug;
using Common.Core.Scene;
using Common.Network;

namespace Client
{
    public class World: Common.Core.Scene.World
    {
        protected override ClientMultiplayerAPI Multiplayer => (ClientMultiplayerAPI)_multiplayer;

        protected override void Start()
        {
            RegisterCommand("connect", CmdEnter);

            while (!Console.KeyAvailable)
            {
                ParseConsoleArgLine(Console.ReadLine());
            }
        }

        private void CmdEnter(string cmd, string[] args)
        {
            switch (cmd)
            {
                case "connect":
                    if (args.Length != 2)
                    {
                        Logger.Print("connect <ip> <port>");
                        break;
                    }

                    Multiplayer.ConnectToServer(args[0], Convert.ToInt32(args[1]));
                    break;
            }
        }

        public override void Tick(float delta)
        {

        }
        
    }
}
