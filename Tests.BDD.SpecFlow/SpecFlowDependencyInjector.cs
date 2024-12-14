using BoDi;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.BDD;

public static class SpecFlowDependencyInjector
{
    public static void RegisterTestDependencies(this IObjectContainer diContainer)
    {
        diContainer.RegisterInstanceAs<IBrowser>(BrowserManager.GetBrowser()!, dispose: true);
        diContainer.RegisterInstanceAs<MainPage>(new MainPage(diContainer.Resolve<IBrowser>()), dispose: true);
        diContainer.RegisterInstanceAs<LoginPage>(new LoginPage(diContainer.Resolve<IBrowser>()), dispose: true);
    }
}
