namespace Common.Core.Scene
{
    public class World
    {
        private Entity _root;

        public Entity Root => _root;

        private Network.MultiplayerAPI _multiplayer;
        private Network.MultiplayerAPI Multiplayer => _multiplayer;

        public void Initialize(Network.MultiplayerAPI multiplayer)
        {
            _multiplayer = multiplayer;
            _root = new Root(_multiplayer);
            Start();
        }

        protected virtual void Start()
        {
            
        }

        public void Tick(double delta)
        {
            _root.TickInternal(delta);
        }
    }
}
