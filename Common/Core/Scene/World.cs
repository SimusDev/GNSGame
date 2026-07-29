namespace Common.Core.Scene
{
    public class World
    {

        protected Network.MultiplayerAPI _multiplayer;
        protected virtual Network.MultiplayerAPI Multiplayer => _multiplayer;

        public void Initialize(Network.MultiplayerAPI multiplayer)
        {
            _multiplayer = multiplayer;
            Start();
        }

        protected virtual void Start()
        {
            
        }

        public void Tick(double delta)
        {

        }
    }
}
