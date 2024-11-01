using Project.Core.UI.Browsers;
using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Tests.UI;

public class BaseTest
{
    protected IBrowser? Driver;

    [SetUp]
    public void SetUp()
    {
        Logger.Information("Starting SetUp");
        Driver = BrowserManager.GetBrowser();
        if (Driver == null)
        {
            throw new InvalidOperationException("Browser driver initialization failed.");
        }
        var baseUrl = ConfigurationManager.GetBrowserSettings().BaseURL;
        Driver.Navigate(baseUrl);
        Logger.Information($"Navigating to base URL: {baseUrl}");
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        BrowserManager.CloseBrowser();
        Logger.Information("TearDown executed");
    }
}
