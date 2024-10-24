using Project.Core.UI.Browsers;
using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;

namespace Project.Tests.UI;

public class BaseTest
{
    protected IBrowser Driver;

    [SetUp]
    public void SetUp()
    {
        Logger.Information("Entering SetUp");
        Driver = BrowserManager.GetBrowser();
        Driver.Navigate(ConfigurationManager.GetBrowserSettings().URL);
    }

    [TearDown]
    public void TearDown()
    {
        BrowserManager.CloseBrowser();
        Logger.Information("TearDown executed");
    }
}
