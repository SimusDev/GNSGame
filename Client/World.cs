using Common.Core.Scene;
using Common.Network;

namespace Client
{
    public class World: Common.Core.Scene.World
    {
        protected override ClientMultiplayerAPI Multiplayer => (ClientMultiplayerAPI)_multiplayer;

        protected override void Start()
        {

        }
    }
}
