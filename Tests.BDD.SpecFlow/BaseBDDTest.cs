using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.BDD;

[Binding]
public class BaseBDDTest
{
    protected MainPage mainPage;
    protected LoginPage loginPage;

    public BaseBDDTest(MainPage mainPage, LoginPage loginPage)
    {
        this.mainPage = mainPage;
        this.loginPage = loginPage;

        Logger.Information("BaseBDDTest constructor executed");
    }
}
