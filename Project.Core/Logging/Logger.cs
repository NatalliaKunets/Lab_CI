using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Project.Core.Logging
{
	public static class Logger
	{
			static Logger()
			{
				Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.WriteTo.Console()
					.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
					.WriteTo.File("Logs/errors.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
					.CreateLogger();
			}

		public static void Information(string message)
		{
			Log.Information(message);
		}

		public static void Warning(string message)
		{
			Log.Warning(message);
		}

		public static void Error(string message)
		{
			Log.Error(message);
		}

		public static void CloseAndFlush()
		{
			Log.CloseAndFlush();
		}
	}
}
