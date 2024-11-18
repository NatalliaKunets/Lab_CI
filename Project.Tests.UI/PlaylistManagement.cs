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
        SearchResultPage searchResultPage = new(Driver!);

        RetrieveSearchResults(mainPage, loginPage, searchResultPage, songName);

        searchResultPage.MoveToFirstSongsSearchResult();
        searchResultPage.ClickSongTreeDotMenu();
        searchResultPage.ClickAddToPlaylistMenuItem();
        searchResultPage.ClickNewPlaylistMenuItem();

        Logger.Information("Successfully added Song to new playlist'.");

        LibraryPage libraryPage = new(Driver!);
        libraryPage.ClickPlaylistByName(songName);

        PlaylistPage playlistPage = new(Driver!);
        if (!playlistPage.IsPageLoaded())
        {
            Logger.Error($"Failed to open playlist Page for Playlist '{songName}'");
            Assert.Fail($"Failed to open playlist Page for Playlist '{songName}'");
            return;
        }

        Logger.Information("The new playlist is selected'.");

        IElement? songElement = playlistPage.FindTrackByName(songName);
        if (songElement == null)
        {
            Logger.Error($"Failed to find track '{songName}' in the Playlist");
            Assert.Fail($"Failed to find track '{songName}' in the Playlist");
            return;
        }

        playlistPage.MoveToSong(songElement, songName);
        PlaylistPage.ClickSongTreeDotMenu(songElement);
        playlistPage.ClickRemoveSongMenuItem();
        playlistPage.RefreashPage();

        Logger.Information($"The song {songName} was deleted from the playlist'.");

        Assert.That(playlistPage.FindTrackByName(songName), Is.Null, $"The track '{songName}' was not deleted from the playlist as expected.");

        Logger.Information("Performing postconditions: Delete created empty playlist.");

        libraryPage.ClickPlaylistByName(songName, isRightClick: true);
        libraryPage.ClickDeletePlaylistMenuItem();
        libraryPage.ClickDeleteButton();

        Logger.Information("Empty Playlist was deleted.");

        Logger.Information("Test Can Delete Song From Playlist executed.");
    }

    private static void RetrieveSearchResults(MainPage mainPage, LoginPage loginPage, SearchResultPage searchResultPage, string songName)
    {
        if (!Login(mainPage, loginPage))
        {
            Logger.Error("Failed to log in");
            Assert.Fail("Failed to log in");
            return;
        }

        Logger.Information("Logged In successfully.");

        mainPage.EnterSearchTerm(songName);
        mainPage.ClickSearchButton();

        if (!searchResultPage.IsPageLoaded())
        {
            Logger.Error($"Failed to get Search Results for '{songName}'");
            Assert.Fail($"Failed to get Search Results for '{songName}'");
            return;
        }

        Logger.Information($"Successfully retrieved Search Results for '{songName}'.");
    }

    [TestCase("You're Welcome")]
    public void CreateLikedSongsPlaylist_WhenSongIsAdded(string songName)
    {
        Logger.Information("Starting Test Create Liked Songs Playlist When Song Is Added");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);
        LibraryPage libraryPage = new(Driver!);
        SearchResultPage searchResultPage = new(Driver!);

        RetrieveSearchResults(mainPage, loginPage, searchResultPage, songName);

        if (libraryPage.FindPlaylistByName("Liked Songs") != null)
        {
            Logger.Error("The 'Liked Songs' playlist already exists");
            Assert.Inconclusive("The 'Liked Songs' playlist already exists, so the precondition for the test is not met.");
            return;
        }

        searchResultPage.MoveToFirstSongsSearchResult();
        searchResultPage.ClickAddToLikedSongsBtn();

        Logger.Information($"Song {songName} successfully added to Liked Songs Playlist");

        Assert.That(libraryPage.FindPlaylistByName("Liked Songs"), Is.Not.Null, "The Liked Songs playlist was not created as expected.");

        Logger.Information("Performing postconditions: Delete song from Liked Songs playlist.");

        libraryPage.ClickPlaylistByName("Liked Songs");
        PlaylistPage playlistPage = new(Driver!);
        if (!playlistPage.IsPageLoaded())
        {
            Logger.Error("Failed to open playlist Page for 'Liked Songs' Playlist");
            Assert.Fail("Failed to open playlist Page for 'Liked Songs' Playlist");
            return;
        }

        Logger.Information("The 'Liked Songs' playlist is selected'.");

        IElement? songElement = playlistPage.FindTrackByName(songName);
        if (songElement == null)
        {
            Logger.Error($"Failed to find song '{songName}' in Liked Songs Playlist to remove");
            return;
        }

        playlistPage.MoveToSong(songElement, songName);
        PlaylistPage.ClickSongTreeDotMenu(songElement);
        playlistPage.ClickRemoveSongMenuItem();
        playlistPage.RefreashPage();

        Logger.Information($"The song {songName} was deleted from Liked Songs playlist'.");

        Logger.Information("Test Create Liked Songs Playlist When Song Is Added executed");
    }

    [Test]
    public void SelectedPlaylistPersistsAfterRefresh()
    {
        Logger.Information("Starting Test Selected Playlist Persists After Refresh");

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

        Logger.Information("Selected the first playlist in User Library.");

        PlaylistPage playlistPage = new(Driver!);
        if(!playlistPage.IsPageLoaded())
        {
            Logger.Error("Failed to load the Playlist page");
            Assert.Fail("Failed to load the Playlist page");
            return;
        }

        Logger.Information("The Playlist page is loaded.");

        playlistPage.RefreashPage();

        Assert.That(playlistPage.IsPageLoaded(), Is.True, "The Selected Playlist was not Persist After Refresh as expected.");

        Logger.Information("Test Selected Playlist Persists After Refresh executed");
    }
}
