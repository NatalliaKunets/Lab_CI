using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Core.UI.Browsers;

public static class BrowserManager
{
    private static IBrowser? driver;

    public static IBrowser GetBrowser()
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
                throw;
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
