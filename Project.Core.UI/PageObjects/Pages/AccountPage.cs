using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class AccountPage : BasePage
{
    public AccountPage(IBrowser driver) : base(driver) { }

    public override bool IsPageLoaded()
    {
        bool isLoaded = WaitForElement(AccountPageLocators.accountMenu) != null;
        Logger.Information($"Login page loaded: {isLoaded}");
        return isLoaded;
    }
}
