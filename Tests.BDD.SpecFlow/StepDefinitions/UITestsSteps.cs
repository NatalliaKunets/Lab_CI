using Project.Core.Logging;
using Project.Core.Settings;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.BDD.StepDefinitions;

[Binding]
public class UITestsSteps(MainPage mainPage, LoginPage loginPage) : BaseBddUITest(mainPage, loginPage)
{
    [Given("User is on Spotify homepage")]
    public void GivenUserIsOnSpotifyHomepage()
    {
        mainPage.NavigateToBaseURL();
        Logger.Information("User is on Spotify homepage executed.");
    }

    [When("User clicks the Log in button in the top-right corner")]
    public void WhenUserClicksTheLogInButtonInTheTop_RightCorner()
    {
        mainPage.ClickLoginButton();
        Logger.Information("User clicks the Log in button in the top-right corner executed.");
    }

    [Then("Login Page should be opened")]
    public void ThenLoginPageShouldBeOpened()
    {
        loginPage.IsPageLoaded().Should().BeTrue("Login Page should be loaded.");
        Logger.Information("Login Page should be opened executed.");
    }

    [Then("UserName and Password Inputs should be visible")]
    public void ThenUserNameAndPasswordInputsShouldBeVisible()
    {
        loginPage.IsUserNameInputVisible().Should().BeTrue("UserName Input should be visible.");
        loginPage.IsPasswordInputVisible().Should().BeTrue("Password Input should be visible.");

        Logger.Information("UserName and Password Inputs should be visible executed.");
    }

    [When("User enters a valid username and password")]
    public void WhenUserEntersAValidUsernameAndPassword()
    {
        var userCredentials = ConfigurationManager.GetUserCredentials();

        loginPage.EnterUserName(userCredentials.Username);
        loginPage.EnterPassword(userCredentials.Password);

        Logger.Information("User enters a valid username and password executed.");
    }

    [When(@"User clicks the Log in button")]
    public void WhenUserClicksTheLogInButton()
    {
        loginPage.ClickLoginButton();
        Logger.Information("User clicks the Log in button executed.");
    }

    [Then("User should be successfully logged in")]
    public void ThenUserShouldBeSuccessfullyLoggedIn()
    {
        mainPage.IsLoggedIn().Should().BeTrue("User should be logged in.");
        Logger.Information("User should be successfully logged in executed.");
    }
}
