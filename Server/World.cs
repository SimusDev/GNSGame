
using Common.Core.Scene;
using Common.Network;

namespace Server
{
    public class World : Common.Core.Scene.World
    {
        protected override ServerMultiplayerAPI Multiplayer => (ServerMultiplayerAPI)_multiplayer;

        protected override void Start()
        {
            while (!Console.KeyAvailable)
            {
                ParseConsoleLine(Console.ReadLine());
            }
        }

        public override void Tick(double delta)
        {

        }

        public void ParseConsoleLine(string command)
        {

        }

    }
}
