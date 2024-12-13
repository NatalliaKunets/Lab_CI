using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;
using Project.Core.UI.Browsers;

namespace Project.Tests.BDD;

public class BaseBDDTest
{
    protected IBrowser? Driver;

    [BeforeScenario]
    public void BeforeScenario()
    {
        Logger.Information("Starting Before Scenario");
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

    [AfterScenario]
    public void AfterScenario()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Driver?.TakeScreenshot(TestContext.CurrentContext.Test.Name);
        }

        BrowserManager.CloseBrowser();
        Logger.Information("After Scenario executed");
    }
}
