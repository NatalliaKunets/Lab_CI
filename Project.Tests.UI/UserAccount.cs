using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class UserAccount : BaseUITest
{
    [Test]
    public void SelectingUserAccountOption_RedirectsToUserAccountPage()
    {
        Logger.Information("Starting Test Selecting User Account option redirects to User Account page");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        mainPage.ClickUserProfileButton();
        mainPage.ClickAccountMenuItem();

        try
        {
            Driver?.SwitchTo().Window(Driver.WindowHandles[1]);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Failed to open Account page");
            Assert.Fail("Failed to open Account page");
            return;
        }

        var accountPage = new AccountPage(Driver!);
        
        Assert.That(accountPage.IsPageLoaded(), "User Account page is not oppened as expected.");

        Logger.Information("Test Selecting User Account option redirects to User Account page executed.");
    }
}
