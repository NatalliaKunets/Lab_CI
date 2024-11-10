using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class SearchResultPageLocators
{
    public static readonly By SongsSearchResultsBy = By.CssSelector("div[aria-label = 'Songs search results']");
    public static readonly By FirstSongsSearchResultBy = By.CssSelector("div[aria-rowindex='1']");
    public static readonly By SongTreeDotMenuBy = By.CssSelector("button[data-testid='more-button']");

    public static readonly By AddToPlaylistMenuItemBy = By.XPath("//button[div[span[text() ='Add to playlist']]]");
    
    public static readonly By NewPlaylistMenuItemBy = By.XPath("//button[span[text() = 'New playlist']]");

    public static readonly By AddToLikedSongsBtnBy = By.CssSelector("button[aria-label = 'Add to Liked Songs']");
}
