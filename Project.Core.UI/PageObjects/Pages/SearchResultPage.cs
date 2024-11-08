using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class SearchResultPage : BasePage
{
    public SearchResultPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement SongsSearchResults => Driver.FindElement(SearchResultPageLocators.SongsSearchResultsBy);
    private IElement FirstSongsSearchResult => SongsSearchResults.FindElement(SearchResultPageLocators.FirstSongsSearchResultBy);
    private IElement SongTreeDotMenu => FirstSongsSearchResult.FindElement(SearchResultPageLocators.SongTreeDotMenuBy);
    private IElement AddToPlaylistMenuItem => Driver.FindElement(SearchResultPageLocators.AddToPlaylistMenuItemBy);
    private IElement NewPlaylistMenuItem => Driver.FindElement(SearchResultPageLocators.NewPlaylistMenuItemBy);

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(SearchResultPageLocators.SongsSearchResultsBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void MoveToFirstSongsSearchResult()
    {
        try
        {
            MoveToElement(FirstSongsSearchResult);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Search Result Page: Failed to Move to the First Songs Search Result.");
            throw;
        }
    }

    public void ClickSongTreeDotMenu()
    {
        try
        {
            WaitForElement(SearchResultPageLocators.SongTreeDotMenuBy);
        }
        catch (WebDriverTimeoutException ex)
        {
            Logger.Error(ex, "Search Result Page: Failed to found the Song Tree Dot Menu.");
            throw;
        }

        try
        {
            SongTreeDotMenu.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Search Result Page: Failed to click the Song Tree Dot Menu.");
            throw;
        }
    }

    public void ClickAddToPlaylistMenuItem()
    {
        try
        {
            AddToPlaylistMenuItem.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Search Result Page: Failed to click the Add To Playlist Menu Item.");
            throw;
        }
    }

    public void ClickNewPlaylistMenuItem()
    {
        try
        {
            NewPlaylistMenuItem.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Search Result Page: Failed to click the New Playlist Menu Item.");
            throw;
        }
    }
}
