
using Common.Core.Scene;
using Common.Network;
namespace Server
{
    public class World : Common.Core.Scene.World
    {
        protected override ServerMultiplayerAPI Multiplayer => (ServerMultiplayerAPI)_multiplayer;

        protected override void Start()
        {
            RegisterCommand("start", CmdEnter);
            
            while (!Console.KeyAvailable)
            {
                ParseConsoleArgLine(Console.ReadLine());
            }
        }

        private void CmdEnter(string cmd, string[] args)
        {
            switch(cmd)
            {
                case "start":
                    Multiplayer.CreateServer(7856);
                    break;
            }
        }

        public override void Tick(double delta)
        {

        }



    }
}
