
namespace Server
{
    internal class Program 
    {
        static Common.Network.ServerMultiplayerAPI? Multiplayer;
        static World? World;

        const int PORT = 7856;

        static void Main(string[] args)
        {
            Multiplayer = new();
            World = new();

            World.Initialize(Multiplayer);

            Multiplayer.CreateServer(PORT);

            var loop = new Common.Core.Loop(Loop);
            loop.Start();
        }

        static void Loop(double delta)
        {
            World!.Tick(delta);
        }

    }
}
