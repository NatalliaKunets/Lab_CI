﻿using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class UserAuthentication : BaseUITest
{
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "AT-Lab2024")]
    public void LoginWithValidCredentials(string userName, string password)
    {
        Logger.Information("Entering Test LogIn With Valid Credentials");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            Assert.Fail("Login Page is not loaded");
        }

        loginPage.EnterUserName(userName);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();

        Assert.That(mainPage.IsLoggedIn(), "The user is not logged in as expected.");

        Logger.Information("Test Log In With Valid Credentials executed.");
    }


    [TestCase("random_user", "pwd123")]
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "123")]
    [TestCase("user", "AT-Lab2024")]
    public void LoginWithInvalidCredentials(string userName, string password)
    {
        Logger.Information("Entering Test LogIn With Invalid Credentials");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            Assert.Fail("Login Page is not loaded");
        }

        loginPage.EnterUserName(userName);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();

        Assert.That(string.Equals(loginPage.GetErrorMessage(), "Incorrect username or password.", StringComparison.InvariantCulture),
            "The error message does not match the expected: 'Incorrect username or password.'");

        Logger.Information("Test Log In With Invalid Credentials executed.");
    }

    [TestCase("", "")]
    public void LoginWithEmptyFields(string userName, string password)
    {
        Logger.Information("Entering Test Login with Empty Fields");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            Assert.Fail("Login Page is not loaded");
        }

        loginPage.EnterUserName(userName);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();

        Assert.That(string.Equals(loginPage.GetErrorMessage(), "Incorrect username or password.", StringComparison.InvariantCulture),
            "The error message does not match the expected: 'Incorrect username or password.'");
        Logger.Information("Test Login with empty fields executed");
    }


    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "AT-Lab2024")]
    public void LogOutTest(string userName, string password)
    {
        Logger.Information("Starting Logout Test");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);
        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            Assert.Fail("Login Page is not loaded");
        }

        loginPage.EnterUserName(userName);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();
		if (!mainPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Main Page");
			Assert.Fail("Main Page is not loaded");
		}
		mainPage.ClickUserProfileButton();
        mainPage.ClickLogoutButton();

        bool isLoggedOut = mainPage.IsLoggedOut();
        Assert.That(isLoggedOut, Is.True, "The user is not logged out as expected");
        Logger.Information("Logout Test executed");

    }

}
