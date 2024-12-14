using BoDi;
using Project.Core.Logging;
using Project.Core.UI.Browsers;

namespace Project.Tests.BDD;

[Binding]
public static class Hooks
{
    [BeforeScenario]
    public static void BeforeScenario(IObjectContainer diContainer) 
    {
        diContainer.RegisterTestDependencies();
        Logger.Information("Before Scenario executed");
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        BrowserManager.CloseBrowser();
        Logger.Information("After Scenario executed");
    }
}
