using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators;

public static class LibraryPageLocators
{
    public static readonly By LibraryListBy = By.CssSelector("ul[aria-label='Your Library']");
    public static readonly By LibraryListItemsBy = By.CssSelector("li[role='listitem']");
    public static readonly By LibraryThreeDotsBtnBy = By.CssSelector(".Button-sc-1dqy6lx-0.dbhFGF");
    public static readonly By EditDetailsBtnBy = By.XPath("//button[@role='menuitem' and .//span[text()='Edit details']]");
    public static readonly By PlaylistNameInputBy = By.CssSelector("input[data-testid='playlist-edit-details-name-input']");
    public static readonly By SavePlaylistNameBy = By.CssSelector("button[data-testid='playlist-edit-details-save-button']");

    public static readonly string PlaylistByNameTemplate = "//ul[@aria-label='Your Library']//li[.//span[contains(text(), '{0}')]]";

    public static readonly By DeletePlaylistMenuItemBy = By.XPath("//button[@role = 'menuitem' and span[text() = 'Delete']]");
    public static readonly By DeleteBtnBy = By.XPath("//button[@data-encore-id ='buttonPrimary' and span[text() = 'Delete']]");
}
