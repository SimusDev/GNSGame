
using Common.Core.Scene;

namespace Server
{
    public class World : Common.Core.Scene.World
    {
        protected override void Start()
        {
            var player = new Entity();
            Root.AddChild(player);

            
        }
    }
}
