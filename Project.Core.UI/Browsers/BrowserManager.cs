using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Core.UI.Browsers;

public static class BrowserManager
{
    private static readonly ThreadLocal<IBrowser> driver = new();

    public static IBrowser? GetBrowser()
    {
        if (driver.Value == null)
        {
            BrowserSettings browserSettings = ConfigurationManager.GetBrowserSettings();
            try
            {
                driver.Value = DriverFactory.InitializeDriver(browserSettings.BrowserType);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to initialize WebDriver with browser type: {browserSettings.BrowserType}");
            }
        }

        return driver.Value;
    }

    public static void CloseBrowser()
    {
        driver.Value?.Quit();
        driver.Value = null;
    }

}
