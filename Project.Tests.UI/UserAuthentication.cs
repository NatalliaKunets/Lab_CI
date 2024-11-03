﻿using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.Settings;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
public class UserAuthentication : BaseTest
{
    [Test]
    public void LoginWithValidCredentials()
    {
        Logger.Information("Entering Test LogIn With Valid Credentials");

        var userCredentials = ConfigurationManager.GetUserCredentials();

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            Assert.Fail("Login Page is not loaded");
        }

        loginPage.EnterUserName(userCredentials.Username);
        loginPage.EnterPassword(userCredentials.Password);
        loginPage.ClickLoginButton();

        Assert.That(mainPage.IsLoggedIn(), "The user is not logged in as expected.");

        Logger.Information("Test Log In With Valid Credentials executed.");
    }


    [TestCase("random_user", "pwd123")]
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "123")]
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


    [Test]
    public void LogOutTest()
    {
        Logger.Information("Starting Logout Test");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
        }

        mainPage.ClickUserProfileButton();
        mainPage.ClickLogoutButton();

        bool isLoggedOut = mainPage.IsLoggedOut();
        Assert.That(isLoggedOut, Is.True, "The user is not logged out as expected");
        Logger.Information("Logout Test executed");
    }
}
