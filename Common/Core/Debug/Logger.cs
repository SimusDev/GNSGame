namespace Common.Core.Debug
{
    public static class Logger
    {
        public static event Action<string>? PrintOutput;

        public static void Print(params object[] args)
        {
            string result = "";
            for (int i = 0; i < args.Length; i++)
                result  += args[i].ToString();

            Console.WriteLine(result);
            PrintOutput?.Invoke(result);

        }



    }
}
