using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Project.Core.Settings
{
	public class WebDriverManager
	{
        public IWebDriver? Driver { get; set; }

		public IWebDriver InitializeDriver(string browser)
		{
			switch (browser.ToLower())
			{
				case "chrome":
					Driver = new ChromeDriver();
					break;
				case "firefox":
					Driver = new FirefoxDriver();
					break;
				default:
					throw new ArgumentException($"Browser {browser} is not supported");
			}

			Driver.Manage().Window.Maximize();
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			return Driver;
		}

		public void QuitDriver()
		{
			Driver?.Quit();
		}
	}
}
