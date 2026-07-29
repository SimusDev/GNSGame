
using Common.Core.Scene;
using Common.Network;

namespace Server
{
    public class World : Common.Core.Scene.World
    {
        protected override ServerMultiplayerAPI Multiplayer => (ServerMultiplayerAPI)_multiplayer;

        protected override void Start()
        {
            var player = new Entity();
            Root.AddChild(player);
        }
    }
}
