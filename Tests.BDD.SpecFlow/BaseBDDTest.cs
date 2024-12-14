using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.BDD;

[Binding]
public class BaseBDDTest
{
    protected IBrowser? Driver;
    protected MainPage mainPage;
    protected LoginPage loginPage;

    public BaseBDDTest(IBrowser? Driver, MainPage mainPage, LoginPage loginPage)
    {
        this.Driver = Driver;
        if (Driver == null)
        {
            throw new InvalidOperationException("Browser driver initialization failed.");
        }

        this.mainPage = mainPage;
        this.loginPage = loginPage;

        Logger.Information("BaseBDDTest constructor executed");
    }
}
