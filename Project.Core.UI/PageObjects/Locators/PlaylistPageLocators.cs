using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class PlaylistPageLocators
{
    public static readonly By PlaylistSectionBy = By.CssSelector("section[data-testid = 'playlist-page']");
    public static readonly string TrackByNameTemplate = "section[data-testid = 'playlist-page'] div[aria-label *= '{0}']";

    public static readonly By SongTreeDotMenuBy = By.CssSelector("button[data-testid='more-button']");

    public static readonly By RemoveSongMenuItemBy = By.XPath("//button[span[contains(text(), 'Remove from')]]");
}
