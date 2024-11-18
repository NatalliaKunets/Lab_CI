using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class SearchEngine : BaseUITest
{
    [TestCase("Running Up That Hill"), Retry(2)]
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

    [Test, Retry(2)]
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

    [TestCase("National Anthem"), Retry(2)]
    public void CanAddSongToPlaylist_FromSearchResults(string searchTerm)
    {
        Logger.Information("Starting Test Can Add Song To Playlist From Search Results");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);
        SearchResultPage searchResultPage = new(Driver!);

        RetrieveSearchResults(mainPage, loginPage, searchResultPage, searchTerm);

        searchResultPage.MoveToFirstSongsSearchResult();
        searchResultPage.ClickSongTreeDotMenu();
        searchResultPage.ClickAddToPlaylistMenuItem();
        searchResultPage.ClickNewPlaylistMenuItem();
        
        Logger.Information("Successfully added Song to new playlist'.");


        LibraryPage libraryPage = new(Driver!);
        libraryPage.ClickPlaylistByName(searchTerm);

        Logger.Information("Select the new playlist to find added Song in it'.");

        PlaylistPage playlistPage = new(Driver!);
        if (!playlistPage.IsPageLoaded())
        {
            Logger.Error($"Failed to open playlist Page for Playlist '{searchTerm}'");
            Assert.Fail($"Failed to open playlist Page for Playlist '{searchTerm}'");
            return;
        }

        var trackFoundElement = playlistPage.FindTrackByName(searchTerm);

        Assert.That(trackFoundElement, Is.Not.Null, $"The track '{searchTerm}' was not found in the playlist '{searchTerm}'.");
        
        Logger.Information("Test Can Add Song To Playlist From Search Results executed.");
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

    [TestCase("You are Welcome"), Retry(2)]
    public void FilterResults_BySongsCategory(string searchTerm)
    {
        Logger.Information("Starting Test Check Filter Results By Songs Category");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);
        SearchResultPage searchResultPage = new(Driver!);

        RetrieveSearchResults(mainPage, loginPage, searchResultPage, searchTerm);

        searchResultPage.ClickFilterBySongsBtn();

        Assert.That(searchResultPage.IsFilteredBySongsCategory(), Is.True, "The Search Results was not Filtered By Songs Category");

        Logger.Information("Test Check Filter Results By Songs Category executed.");
    }
}
