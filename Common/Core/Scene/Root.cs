
using Common.Network;

namespace Common.Core.Scene
{
    public class Root : Entity
    {
        public Root(MultiplayerAPI multiplayer)
        {
            _multiplayer = multiplayer;
            Name = "*root*";
        }
    }
}
