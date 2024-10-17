using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class LoginPageLocators
{
    public static readonly By userNameInputBy = By.CssSelector("input#login-username");
    public static readonly By passwordInputBy = By.CssSelector("input#login-password");
    public static readonly By loginButtonBy = By.CssSelector("button#login-button");
    public static readonly By errorUserNameElementBy = By.CssSelector("div[data-encore-id='banner'] span[class*='Message']");
    public static readonly By errorMessageBy = By.CssSelector("div[data-testid='username-error'] p[class*='sc']");
}
