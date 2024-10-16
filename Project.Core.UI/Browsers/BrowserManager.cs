using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Core.UI.Browsers;

public static class BrowserManager
{
    private static Browser? driver;

    public static Browser GetBrowser()
    {
        if (driver == null)
        {
            BrowserSettings browserSettings = ConfigurationManager.GetBrowserSettings();
            try
            {
                driver = DriverFactory.InitializeDriver(browserSettings.browserType);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to initialize WebDriver with browser type: {browserSettings.browserType}");
            }
            finally
            {
                driver = null;
            }
        }

        return driver;
    }

    public static void CloseBrowser()
    {
        driver?.Quit();
        driver = null;
    }
}
