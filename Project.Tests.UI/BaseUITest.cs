using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

public class BaseUITest
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
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Driver?.TakeScreenshot();
        }

        BrowserManager.CloseBrowser();
        Logger.Information("TearDown executed");
    }

    protected static bool Login(MainPage mainPage, LoginPage loginPage)
    {
        var userCredentials = ConfigurationManager.GetUserCredentials();

        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            return false;
        }

        loginPage.EnterUserName(userCredentials.Username);
        loginPage.EnterPassword(userCredentials.Password);
        loginPage.ClickLoginButton();

        return mainPage.IsLoggedIn();
    }

}
