
namespace Server
{
    internal class Program 
    {
        static Common.Network.ServerMultiplayerAPI? Multiplayer;
        static World? World;

        static void Main(string[] args)
        {
            Multiplayer = new();
            World = new();

            World.Initialize(Multiplayer);

            var loop = new Common.Core.Loop(Loop);
            loop.Start();
        }

        static void Loop(float delta)
        {
            Multiplayer!.Poll();
            World!.Tick(delta);
        }

    }
}
