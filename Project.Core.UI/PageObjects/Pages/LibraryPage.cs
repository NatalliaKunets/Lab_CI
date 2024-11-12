using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class LibraryPage : BasePage
{
    public LibraryPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement LibraryList => Driver.FindElement(LibraryPageLocators.LibraryListBy);
    private IReadOnlyCollection<IElement> LibraryListItems => Driver.FindElements(LibraryPageLocators.LibraryListItemsBy);
    private IElement LibraryThreeDotsBtn => Driver.FindElement(LibraryPageLocators.LibraryThreeDotsBtnBy);
    private IElement PlaylistNameInput => Driver.FindElement(LibraryPageLocators.PlaylistNameInputBy);
    private IElement SavePlaylistName => Driver.FindElement(LibraryPageLocators.SavePlaylistNameBy);

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(LibraryPageLocators.LibraryListBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsPlaylistCreated()
    {
        if (LibraryList != null && LibraryListItems.Count > 0)
        {
            return true;
        }
        return false;
    }

    public IElement? FindPlaylistByName(string playlistName)
    {
        By PlaylistByNameBy = By.XPath(string.Format(LibraryPageLocators.PlaylistByNameTemplate, playlistName));

        try
        {
            return WaitForElement(PlaylistByNameBy);
        }
        catch (WebDriverTimeoutException)
        {
            return null;
        }
    }

    public void ClickPlaylistByName(string playlistName, bool isRightClick = false)
    {
        try
        {
            var playlistElement = FindPlaylistByName(playlistName);

            if (playlistElement == null)
            {
                Logger.Error($"Library Page: Playlist '{playlistName}' not found.");
                throw new NoSuchElementException($"Playlist '{playlistName}' not found.");
            }

            if (isRightClick)
            {
                RightClickElement(playlistElement);
            }
            else
            {
                playlistElement.Click();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"Library Page: Failed to click playlist '{playlistName}'.");
            throw;
        }
    }

    public void EditPlaylistDetails()
    {
        try
        {
            WaitForElement(LibraryPageLocators.LibraryThreeDotsBtnBy).Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Library Page: Failed to click on Three Dots Button");
        }
    }

    public void RenamePlaylist(string name)
    {
        try
        {
			WaitForElement(LibraryPageLocators.LibraryThreeDotsBtnBy).Click();
			WaitForElement(LibraryPageLocators.EditDetailsBtnBy).Click();
			WaitForElement(LibraryPageLocators.PlaylistNameInputBy);
            WaitForElement(LibraryPageLocators.SavePlaylistNameBy);
            PlaylistNameInput.Clear();
            PlaylistNameInput.SendKeys(name);
            SavePlaylistName.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Library Page: Failed to rename the playlist");
        }
    }

    public void ClickDeletePlaylistMenuItem()
    {
        try
        {
            WaitForElement(LibraryPageLocators.DeletePlaylistMenuItemBy)?.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Libraryt Page: Failed to click the Delete Playlist Menu Item.");
            throw;
        }
    }

    public void ClickDeleteButton()
    {
        try
        {
            WaitForElement(LibraryPageLocators.DeleteBtnBy)?.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Library Page: Failed to click the Delete Playlist button.");
            throw;
        }
    }
}