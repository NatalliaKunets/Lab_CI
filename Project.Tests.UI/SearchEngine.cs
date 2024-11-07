using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class SearchEngine : BaseUITest
{
    [TestCase("Running Up That Hill")]
    public void SearchEngineWithValidTerm(string searchTerm)
    {
        Logger.Information("Starting Test Search Engine With Valid Term");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        mainPage.EnterSearchTerm(searchTerm);
        mainPage.ClickSearchButton();
        
        Assert.That(mainPage.GetSearchTopResultTitle(), Does.Contain(searchTerm).IgnoreCase, $"The Search Top Result Title does not contain the expected: {searchTerm}.");

        Logger.Information("Test Search Engine With Valid Term executed.");
    }

    [Test]
    public void NoActions_WhenQueryIsEmpty()
    {
        Logger.Information("Starting Test No Actions When Query Is Empty");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        mainPage.EnterSearchTerm(string.Empty);
        mainPage.ClickSearchButton();

        var SearchTopResultTitle = mainPage.GetSearchTopResultTitle();
        Assert.That(SearchTopResultTitle, Is.Empty, $"Unexpected action by Search Engine: Top result found = '{SearchTopResultTitle}'.");

        Logger.Information("Test No Actions When Query Is Empty executed.");
    }
}
