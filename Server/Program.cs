namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Valve.Sockets.Library.Initialize();

            Valve.Sockets.Library.Deinitialize();
        }
    }
}
