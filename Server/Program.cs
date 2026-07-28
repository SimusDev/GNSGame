
namespace Server
{
    internal class Program 
    {
        static Common.Network.MultiplayerAPI Multiplayer;
        static World World;

        static void Main(string[] args)
        {
            Multiplayer = new();
            World = new();

            World.Initialize(Multiplayer);

            var loop = new Common.Core.Loop(Loop);
            loop.Start();
        }

        static void Loop(double delta)
        {
            World.Tick(delta);
        }

    }
}
