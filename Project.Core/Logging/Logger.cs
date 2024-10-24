using Project.Core.Settings;
using Serilog;

namespace Project.Core.Logging;

public static class Logger
{
	static Logger()
	{
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(ConfigurationManager.configuration) 
            .CreateLogger();
    }

	public static void Error(Exception ex, string message)
	{
		Log.Error(ex, message);
	}

    public static void Information(string message)
    {
        Log.Information(message);
    }
    
}
