using Serilog;

namespace Project.Core.Logging;

public static class Logger
{
	static Logger()
	{
		Log.Logger = new LoggerConfiguration()
			.CreateLogger();
	}

	public static void Error(Exception ex, string message)
	{
		Log.Error(ex, message);
	}
}
