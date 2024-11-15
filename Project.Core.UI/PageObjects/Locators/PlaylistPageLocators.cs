using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class PlaylistPageLocators
{
    public static readonly By PlaylistSectionBy = By.CssSelector("section[data-testid = 'playlist-page']");

    // workaround for Liked Songs Playlist - div has data-testid = 'track-list'
    public static readonly string TrackByNameTemplate = 
        "//div[(@data-testid='playlist-tracklist' or @data-testid='track-list') and .//div[contains(text(), '{0}')]]";

    public static readonly By SongTreeDotMenuBy = By.CssSelector("button[data-testid='more-button']");

    public static readonly By RemoveSongMenuItemBy = By.XPath("//button[span[contains(text(), 'Remove from')]]");
}
