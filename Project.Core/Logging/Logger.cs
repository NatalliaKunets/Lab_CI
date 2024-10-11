using Serilog;

namespace Project.Core.Logging
{
	public static class Logger
	{
		static Logger()
		{
			Log.Logger = new LoggerConfiguration()
				.CreateLogger();
		}
	}
}
