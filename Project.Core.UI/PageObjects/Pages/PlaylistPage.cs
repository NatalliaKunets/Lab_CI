using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class PlaylistPage : BasePage
{
    public PlaylistPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement RemoveSongMenuItem => Driver.FindElement(PlaylistPageLocators.RemoveSongMenuItemBy);

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(PlaylistPageLocators.PlaylistSectionBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public IElement? FindTrackByName(string trackName)
    {
        By TrackByNameBy = By.XPath(string.Format(PlaylistPageLocators.TrackByNameTemplate, trackName));

        try
        {
            return WaitForElement(TrackByNameBy);
        }
        catch (WebDriverTimeoutException)
        {
            return null;
        }
    }

    public void MoveToSong(IElement songElement, string songName)
    {
        try
        {
            MoveToElement(songElement);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"Playlist Page: Failed to Move to Song {songName}.");
            throw;
        }
    }

    public static void ClickSongTreeDotMenu(IElement songElement)
    {
        IElement? songTreeDotMenu;
        try
        {
            songTreeDotMenu = songElement.FindElement(PlaylistPageLocators.SongTreeDotMenuBy);
            
            if (songTreeDotMenu == null)
            {
                throw new WebDriverTimeoutException();
            }

        }
        catch (WebDriverTimeoutException ex)
        {
            Logger.Error(ex, "Playlist Page: Failed to found the Song Tree Dot Menu.");
            throw;
        }

        try
        {
            songTreeDotMenu.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Playlist Page: Failed to click the Song Tree Dot Menu.");
            throw;
        }
    }

    public void ClickRemoveSongMenuItem()
    {
        try
        {
            RemoveSongMenuItem.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Playlist Page: Failed to click the Remove Song Menu Item.");
            throw;
        }
    }

    public void RefreashPage()
    {
        Driver.RefreshPage();
    }
}
