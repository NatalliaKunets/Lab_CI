using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.Target;
using OpenQA.Selenium.Edge;
using Project.Core.Enums;

namespace Project.Core.UI.Browsers
{
	public static class DriverFactory
	{
		public static IWebDriver GetDriver(BrowserSettings browserSettings)
		{
			IWebDriver driver;

			switch (browserSettings.Browser)
			{
				case BrowserType.Chrome:
					var chromeOptions = new ChromeOptions();
					chromeOptions.AddArgument("--headless");
					chromeOptions.AddArgument("--no-sandbox");
					chromeOptions.AddArgument("--disable-dev-shm-usage");
					driver = new ChromeDriver(chromeOptions);
					break;
				case BrowserType.Edge:
					var edgeOptions = new EdgeOptions();
					driver = new EdgeDriver(edgeOptions);
					break;
				default:
					throw new PlatformNotSupportedException($"{browserSettings.Browser} is not currently supported");
			}
			return driver;
		}
	}
}
