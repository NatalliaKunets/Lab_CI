using OpenQA.Selenium;
using Project.Core.Settings;

namespace Project.Core.UI.Browsers;

public static class BrowserManager
{
    private static IWebDriver? driver;

    public static IWebDriver GetBrowser()
    {
        if (driver == null)
        {
            BrowserSettings browserSettings = ConfigurationManager.GetBrowserSettings();
            driver = DriverFactory.InitializeDriver(browserSettings.browserType);
        }

        return driver;
    }

    public static void CloseBrowser()
    {
        driver?.Quit();
        driver = null;
    }
}
