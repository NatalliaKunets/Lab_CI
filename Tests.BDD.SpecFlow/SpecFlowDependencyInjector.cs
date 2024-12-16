using BoDi;
using Project.Core.API.Managers;
using Project.Core.API.Services;
using Project.Core.Settings;
using Project.Core.UI.Browsers;
using Project.Core.UI.PageObjects.Pages;
using RestSharp;

namespace Project.Tests.BDD;

public static class SpecFlowDependencyInjector
{
    public static void RegisterUITestDependencies(this IObjectContainer diContainer)
    {
        diContainer.RegisterInstanceAs<IBrowser>(BrowserManager.GetBrowser(), dispose: true);
        diContainer.RegisterInstanceAs<MainPage>(new MainPage(diContainer.Resolve<IBrowser>()), dispose: true);
        diContainer.RegisterInstanceAs<LoginPage>(new LoginPage(diContainer.Resolve<IBrowser>()), dispose: true);
    }

    public static void RegisterAPITestDependencies(this IObjectContainer diContainer)
    {
        diContainer.RegisterTypeAs<SessionManager, ISessionManager>();
        diContainer.RegisterInstanceAs<SessionManager>(new SessionManager(ConfigurationManager.GetApiSettings()), dispose: true);
        diContainer.RegisterInstanceAs<AuthenticationService>(new AuthenticationService(diContainer.Resolve<ISessionManager>()), dispose: true);
    }
}
