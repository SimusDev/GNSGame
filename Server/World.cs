using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Common.Network;

namespace Server
{
    public class World : Common.Core.Scene.World
    {
        private readonly EntityStore _entityStore = new();
        public EntityStore EntityStore => _entityStore;

        private readonly SystemRoot _systemRoot;
        public SystemRoot SystemRoot => _systemRoot;

        public World()
        {
            _systemRoot = new(_entityStore) {
                new Common.Core.System.Movement(),
            };
        }

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
