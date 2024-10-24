﻿using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
public class UserAuthentication : BaseTest
{
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "AT_Lab2024")]
    public void LoginWithValidCredentials(string userName, string password)
    {
        Logger.Information("Entering Test Log In With Valid Credentials");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        mainPage.ClickLoginButton();

        if (loginPage.IsPageLoaded())
        {
            loginPage.EnterUserName(userName);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();
        }
        else
        {
            var ex =  new Exception("Login Page is not loaded");
            Logger.Error(ex, "Failed to load Login Page");
            throw ex;
        }

        Assert.That(mainPage.IsLoggedIn());

        Logger.Information("Test Log In With Valid Credentials executed.");
    }


    [TestCase("random_user", "pwd123")]
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "123")]
    [TestCase("user", "AT_Lab2024")]
    public void LoginWithInvalidCredentials()
    {
    }

}
