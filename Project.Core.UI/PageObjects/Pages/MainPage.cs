using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class MainPage : BasePage
{
    public MainPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement HomeBtn => Driver.FindElement(MainPageLocators.HomeBtnBy);
    private IElement SearchInput => Driver.FindElement(MainPageLocators.SearchInputBy);
    private IElement CreatePlaylistPlusBtn => Driver.FindElement(MainPageLocators.CreatePlaylistPlusBtnBy);
    private IElement LoginBtn => Driver.FindElement(MainPageLocators.LoginBtnBy);
    private IElement SearchBtn => Driver.FindElement(MainPageLocators.SearchBtnBy);
    private IElement SongPlayBtn => Driver.FindElement(MainPageLocators.SongPlayBtnBy);
    private IElement UserProfileBtn => Driver.FindElement(MainPageLocators.UserProfileBtnBy);
    private IElement LogoutBtn => Driver.FindElement(MainPageLocators.LogOutBtnBy);

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(MainPageLocators.HomeBtnBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void ClickHomeButton()
    {
        try
        {
            HomeBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Home button.");
            throw;
        }
    }

    public void ClickLoginButton()
    {
        try
        {
            LoginBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Login button.");
            throw;
        }
    }

    public void ClickCreatePlaylistPlusBtn()
    {
        try
        {
            CreatePlaylistPlusBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Create Playlist button.");
            throw;
        }
    }

    public void ClickCreatePlaylistMenuItem()
    {
        var CreatePlaylistMenuItem = WaitForElement(MainPageLocators.CreateNewPlaylistMenuItemBy);

        try
        {
            CreatePlaylistMenuItem.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Create Playlist Menu Item");
            throw;
        }
    }

    public void ClickSearchButton()
    {
        try
        {
            SearchBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Search button.");
            throw;
        }
    }

    public void ClickSongPlayButton()
    {
        try
        {
            SongPlayBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the Song Play button.");
            throw;
        }
    }

    public void ClickUserProfileButton()
    {
        try
        {
            WaitForElement(MainPageLocators.UserProfileBtnBy);
            UserProfileBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click the User Profile button.");
            throw;
        }
    }


    public void ClickLogoutButton()
    {
        try
        {
            WaitForElement(MainPageLocators.LogOutBtnBy);
            LogoutBtn.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Main Page: Failed to click logout button.");
            throw;
        }
    }

    public bool IsLoggedIn()
    {
        try
        {
            return WaitForElement(MainPageLocators.UserProfileBtnBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsLoggedOut()
    {
        try
        {
            return WaitForElement(MainPageLocators.LoginBtnBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public string? GetPlaylistTitle()
    {
        var NewPlaylistTitle = WaitForElement(MainPageLocators.NewPlaylistTitleBy);
        return NewPlaylistTitle?.Text;
    }

    public bool IsCreatePlaylistTooltipVisible()
    {
        try
        {
            return WaitForElement(MainPageLocators.CreatePlaylistTooltipBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
