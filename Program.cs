using Serilog;
using Serilog.Events;

namespace LetsBrew.BrewBot;
public static class Program
{

    private static readonly ILogger Logger = new LoggerConfiguration()
                                            .WriteTo.Console()
                                            .WriteTo.File("discordBot.log", rollingInterval: RollingInterval.Day)
#if DEBUG
                                            .MinimumLevel.Debug()
#endif
                                            .CreateLogger();

    public static void Main(string[] args)
    {

    }

    public static void Log(LogEventLevel level, string message)
    {
        switch(level)
        {
            case LogEventLevel.Information:
                Logger.Information(message);
                break;
            case LogEventLevel.Warning:
                Logger.Warning(message);
                break;
            case LogEventLevel.Error:
                Logger.Error(message);
                break;
            case LogEventLevel.Fatal:
                Logger.Fatal(message);
                break;
            default:
                Logger.Verbose(message);
                break;
        }
    }
}