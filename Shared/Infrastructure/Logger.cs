using Serilog;

namespace Infrastructure
{
    public static class Logger
    {
        public static void Init()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
