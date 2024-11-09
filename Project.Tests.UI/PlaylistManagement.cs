using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class PlaylistManagement : BaseUITest
{
    [TestCase("Running Up That Hill")]
    public void CanDeleteSongFromPlaylist(string songName)
    {
        Logger.Information("Starting Test Can Delete Song From Playlist");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        mainPage.EnterSearchTerm(songName);
        mainPage.ClickSearchButton();

        SearchResultPage searchResultPage = new(Driver!);

        if (!searchResultPage.IsPageLoaded())
        {
            Logger.Error($"Failed to get Search Results for '{songName}'");
            Assert.Fail($"Failed to get Search Results for '{songName}'");
            return;
        }
        Logger.Information($"Successfully retrieved Search Results for '{songName}'.");

        searchResultPage.MoveToFirstSongsSearchResult();
        searchResultPage.ClickSongTreeDotMenu();
        searchResultPage.ClickAddToPlaylistMenuItem();
        searchResultPage.ClickNewPlaylistMenuItem();

        Logger.Information("Successfully added Song to new playlist'.");

        LibraryPage libraryPage = new(Driver!);
        libraryPage.ClickPlaylistByName(songName);

        Logger.Information("Select the new playlist to find added Song in it'.");

        PlaylistPage playlistPage = new(Driver!);
        if (!playlistPage.IsPageLoaded())
        {
            Logger.Error($"Failed to open playlist Page for Playlist '{songName}'");
            Assert.Fail($"Failed to open playlist Page for Playlist '{songName}'");
            return;
        }

        Logger.Information("The playlist is selected'.");

        IElement songElement = playlistPage.FindTrackByName(songName);
        playlistPage.MoveToSong(songElement, songName);
        playlistPage.ClickSongTreeDotMenu(songElement, songName);
        playlistPage.ClickRemoveSongMenuItem();
        playlistPage.RefreashPage();

        Logger.Information($"The song {songName} was deleted from the playlist'.");

        Assert.That(playlistPage.FindTrackByName(songName), Is.Null, $"The track '{songName}' was not deleted from the playlist as expected.");

        Logger.Information("Test Can Delete Song From Playlist executed.");
    }
}
