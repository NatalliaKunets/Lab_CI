using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class HeaderNavigation : BaseUITest
{
    [Test, Retry(2)] 
    public void CheckHomeButtonFunctionality()
    {
        Logger.Information("Starting Test Create a New Playlist");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        LibraryPage libraryPage = new(Driver!);
        var firstPlaylistName = libraryPage.GetFirstPlaylistName();
        if (string.IsNullOrEmpty(firstPlaylistName))
        {
            Logger.Error("There are no playlists in User Library");
            Assert.Inconclusive("There are no playlists in User Library, so the precondition for the test is not met.");
            return;
        }

        libraryPage.ClickPlaylistByName(firstPlaylistName);

        Logger.Information("Select the first playlist in User Library.");

        mainPage.ClickHomeButton();
        
        Assert.That(mainPage.IsPageLoaded(), Is.True, "The Home button does not redirect to the Main page.");

        Logger.Information("Test Check Home Button Functionality executed.");
    }
}
