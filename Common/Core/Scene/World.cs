namespace Common.Core.Scene
{
    public class World
    {

        protected Network.MultiplayerAPI _multiplayer;
        protected virtual Network.MultiplayerAPI Multiplayer => _multiplayer;

        private Dictionary<string, Action<string[]>> _commands = new();

        public void Initialize(Network.MultiplayerAPI multiplayer)
        {
            _multiplayer = multiplayer;
            Start();
        }

        public void RegisterCommand(string command, Action<string[]> bind)
        {
            _commands[command] = bind;
        }

        public void ParseConsoleArgLine(string arg)
        {
            if (arg[0] == '/')
            {
                ParseCommand(arg.Remove(0));
            }
        }

        public void ParseCommand(string cmd)
        {
            switch(cmd)
            {
                case "":
                    break;
            }
        }


        protected virtual void Start()
        {
            
        }

        public virtual void Tick(double delta)
        {

        }
    }
}
