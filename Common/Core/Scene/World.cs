using Common.Core.Debug;
using Friflo.Json.Fliox.Schema.GraphQL;

namespace Common.Core.Scene
{
    public class World
    {

        protected Network.MultiplayerAPI _multiplayer;
        protected virtual Network.MultiplayerAPI Multiplayer => _multiplayer;

        private Dictionary<string, Action<string, string[]>> _commands = new();

        public void Initialize(Network.MultiplayerAPI multiplayer)
        {
            _multiplayer = multiplayer;
            Start();
        }

        public void RegisterCommand(string command, Action<string, string[]> bind)
        {
            _commands[command] = bind;
        }

        public void ParseConsoleArgLine(string arg)
        {
            if (arg[0] == '/')
            {
                ParseCommand(arg.Remove(0, 1));
            }
        }

        public void ParseCommand(string line)
        {
            string cmd = line.Split(' ')[0];
            string withoutCommand = line.Remove(0, cmd.Length);
            if (withoutCommand.Length > 0 && withoutCommand[0] == ' ')
                withoutCommand = withoutCommand.Remove(0, 1);

            if (_commands.TryGetValue(cmd, out var action))
            {
                string[] args = withoutCommand.Split(' ');
                action(cmd, args);
            }
            else
            {
                Logger.Print("Unknown command.");
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
