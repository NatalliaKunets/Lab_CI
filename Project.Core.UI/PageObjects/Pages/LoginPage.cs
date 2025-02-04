﻿using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class LoginPage(IBrowser driver) : BasePage(driver)
{
    private IElement UserNameInput => Driver.FindElement(LoginPageLocators.userNameInputBy);
    private IElement PasswordInput => Driver.FindElement(LoginPageLocators.passwordInputBy);
    private IElement LoginButton => Driver.FindElement(LoginPageLocators.loginButtonBy);
    private IElement ContinueButton => Driver.FindElement(LoginPageLocators.continueButtonBy);

    public void EnterUserName(string userName)
    {
        UserNameInput.Clear();
        UserNameInput.SendKeys(userName);
        Logger.Information($"Enter username: {userName}");
    }

    public void EnterPassword(string password)
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys(password);
        Logger.Information($"Enter password: {password}");
    }

    public void ClickLoginButton()
    {
        try
        {
            LoginButton.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Login Page: Failed to click the Login button.");
            throw;
        }
    }


    public string? GetUserNameError() => WaitForElement(LoginPageLocators.errorUserNameElementBy)?.Text;

    public string? GetErrorMessage() => WaitForElement(LoginPageLocators.errorMessageBy)?.Text;

    public override bool IsPageLoaded()
    {
        bool isLoaded = WaitForElement(LoginPageLocators.loginButtonBy) != null;
        Logger.Information($"Login page loaded: {isLoaded}");
        return isLoaded;
    }

    public void ClickContinueButton()
    {
        try
        {
            ContinueButton.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Login Page: Failed to click the Continue button.");
            throw;
        }
    }

    public void ClickLoginWithPasswordButton()
    {
        try
        {
            var loginWithPasswordButton = WaitForElement(LoginPageLocators.loginWithPasswordButtonBy);
            loginWithPasswordButton!.Click();
            WaitForElement(LoginPageLocators.passwordInputBy);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Login Page: Failed to click the Login With Password button.");
            throw;
        }
    }

    public bool IsUserNameInputVisible()
    {
        return UserNameInput.Displayed;
    }

    public bool IsPasswordInputVisible()
    {
        return PasswordInput.Displayed;
    }
}
