using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;
using Project.Core.UI.PageObjects.Pages;
using System;
using TechTalk.SpecFlow;

namespace Project.Tests.BDD.StepDefinitions
{
    [Binding]
    public class UITestsSteps : BaseBDDTest
    {
        private MainPage mainPage;
        private LoginPage loginPage;

        [Given("User is on Spotify homepage")]
        public void GivenUserIsOnSpotifyHomepage()
        {
            mainPage = new(Driver!);
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
            loginPage = new(Driver!);
            try
            {
                loginPage.IsPageLoaded().Should().BeTrue("Login Page should be loaded.");
            }
            catch (AssertionException ex)
            {
                Logger.Error(ex, "Failed to load Login Page.");
                throw;
            }

            Logger.Information("Login Page should be opened executed.");
        }

        [Then("UserName and Password Inputs should be visible")]
        public void ThenUserNameAndPasswordInputsShouldBeVisible()
        {
            try
            {
                loginPage.IsUserNameInputVisible().Should().BeTrue("UserName Input should be visible.");
            }
            catch (AssertionException ex)
            {
                Logger.Error(ex, "There is no UserName Input on Login Page.");
                throw;
            }

            try
            {
                loginPage.IsPasswordInputVisible().Should().BeTrue("Password Input should be visible.");
            }
            catch (AssertionException ex)
            {
                Logger.Error(ex, "There is no Password Input on Login Page.");
                throw;
            }

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

        [Then(@"User should be successfully logged in")]
        public void ThenUserShouldBeSuccessfullyLoggedIn()
        {
            try
            {
                mainPage.IsLoggedIn().Should().BeTrue("User should be logged in.");
            }
            catch (AssertionException ex)
            {
                Logger.Error(ex, "The user is not logged in as expected.");
                throw;
            }

            Logger.Information("User should be successfully logged in executed.");
        }
    }
}
