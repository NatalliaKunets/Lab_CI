using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.BDD;

[Binding]
public class BaseBddUITest
{
    protected MainPage mainPage;
    protected LoginPage loginPage;

    public BaseBddUITest(MainPage mainPage, LoginPage loginPage)
    {
        this.mainPage = mainPage;
        this.loginPage = loginPage;

        Logger.Information("BaseBddUITest constructor executed");
    }
}
