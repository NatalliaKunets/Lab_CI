using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class UserLibrary : BaseUITest
{
    [Test]
    [Ignore("Skip for CI check")]

    public void CreateNewPlaylist()
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

        mainPage.ClickCreatePlaylistPlusBtn();
        mainPage.ClickCreatePlaylistMenuItem();

        string playlistTitle = mainPage.GetPlaylistTitle() ?? string.Empty;
        Logger.Information($"Retrieved Playlist Title: {playlistTitle}");
        Assert.That(playlistTitle, Does.Match(@"^My Playlist #\d+$"), "The playlist was not created successfully.");

        Logger.Information("Test Create a New Playlist executed.");

    }

    [Test]
    public void CannotCreatePlaylist_IfUserNotLoggedIn()
    {
        Logger.Information("Starting Test Verify that User Cannot Create a Playlist If Not LoggedIn");

        MainPage mainPage = new(Driver!);

        mainPage.ClickCreatePlaylistPlusBtn();
        mainPage.ClickCreatePlaylistMenuItem();

        Assert.That(mainPage.IsCreatePlaylistTooltipVisible, "The error message was not displayed as expected.");

        Logger.Information("Test Verify that User Cannot Create a Playlist If Not LoggedIn executed.");
    }



	[TestCase("My Playlist #7", "New Playlist")]
    [Ignore("Skip for CI check")]

    public void RenamePlaylist(string playlistName, string newPlaylistName)
	{
		MainPage mainPage = new(Driver!);
		LibraryPage libPage = new(Driver!);
		LoginPage loginPage = new(Driver!);
		Login(mainPage, loginPage);
		if (!mainPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Main Page");
		}
		libPage.ClickPlaylistByName(playlistName);
		libPage.RenamePlaylist(newPlaylistName);
	}


	[TestCase("New Playlist")]
    [Ignore("Skip for CI check")]

    public void DeletePlaylist(string playlistName)
	{
		MainPage mainPage = new(Driver!);
		LibraryPage libPage = new(Driver!);
		LoginPage loginPage = new(Driver!);
		Login(mainPage, loginPage);
		if (!mainPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Main Page");
		}
		libPage.ClickPlaylistByName(playlistName);
		libPage.EditPlaylistDetails();
        libPage.ClickDeletePlaylistMenuItem();
        libPage.ClickDeleteButton();
	}
}
