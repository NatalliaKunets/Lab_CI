using OpenQA.Selenium;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement UserNameInput => Driver.FindElement(LoginPageLocators.userNameInputBy);
    private IElement PasswordInput => Driver.FindElement(LoginPageLocators.passwordInputBy);
    private IElement LoginButton => Driver.FindElement(LoginPageLocators.loginButtonBy);


    public void EnterUserName(string userName)
    {
        UserNameInput.Clear();
        UserNameInput.SendKeys(userName);
    }

    public void EnterPassword(string password)
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys(password);
    }

    public void PressLoginButton() => LoginButton.Click();

    public string? GetUserNameError() => WaitForElement(LoginPageLocators.errorUserNameElementBy)?.Text;
 
    public string? GetErrorMessage() => WaitForElement(LoginPageLocators.errorMessageBy)?.Text;
       
    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(LoginPageLocators.loginButtonBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false; 
        }
    }
}
