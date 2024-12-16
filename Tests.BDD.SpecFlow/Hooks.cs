using BoDi;
using Project.Core.Logging;
using Project.Core.UI.Browsers;

namespace Project.Tests.BDD;

[Binding]
public static class Hooks
{
    [BeforeScenario]
    public static void BeforeScenario(FeatureContext featureContext, IObjectContainer diContainer) 
    {
        if (featureContext.FeatureInfo.Title == "UITests")
        {
            diContainer.RegisterUITestDependencies();
        }
        else if (featureContext.FeatureInfo.Title == "APITests")
        {
            diContainer.RegisterAPITestDependencies();
        }

        Logger.Information("Before Scenario executed");
    }

    [AfterScenario]
    public static void AfterScenario(FeatureContext featureContext)
    {
        if (featureContext.FeatureInfo.Title == "UITests")
        {
            BrowserManager.CloseBrowser();
        }
        Logger.Information("After Scenario executed");
    }
}
