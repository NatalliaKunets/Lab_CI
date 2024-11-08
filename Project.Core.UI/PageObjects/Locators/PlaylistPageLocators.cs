using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class PlaylistPageLocators
{
    public static readonly By PlaylistSectionBy = By.CssSelector("section[data-testid = 'playlist-page']");
    public static readonly string TrackByNameTemplate = "section[data-testid = 'playlist-page'] div[aria-label *= '{0}']";
}
