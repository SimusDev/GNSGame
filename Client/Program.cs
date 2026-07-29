
namespace Client
{
    internal class Program
    {
        static Common.Network.ClientMultiplayerAPI? Multiplayer;
        static Common.Core.Scene.World? World;

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
            Multiplayer!.Poll();
            World!.Tick(delta);
        }

    }
}
