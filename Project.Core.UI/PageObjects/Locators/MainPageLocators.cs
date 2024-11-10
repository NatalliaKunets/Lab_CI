using OpenQA.Selenium;
using static System.Collections.Specialized.BitVector32;

namespace Project.Core.UI.PageObjects.Locators;

public static class MainPageLocators
{
	public static readonly By HomeBtnBy = By.CssSelector(".Button-sc-1dqy6lx-0.bksmLQ");
	public static readonly By SearchInputBy = By.CssSelector(".Input-sc-1gbx9xe-0");
	public static readonly By CreatePlaylistPlusBtnBy = By.CssSelector("button[aria-label='Create playlist or folder']");
	public static readonly By CreateNewPlaylistMenuItemBy = By.CssSelector("button[role='menuitem'] span[data-encore-id='type']");
	public static readonly By NewPlaylistTitleBy = By.CssSelector("h1.encore-text-headline-large[data-encore-id='text']");
	public static readonly By LoginBtnBy = By.CssSelector("button[data-testid='login-button']");
	public static readonly By SearchBtnBy = By.CssSelector("svg[data-testid='search-icon']");
	
	public static readonly By LoginBtnBy = By.CssSelector("button[data-testid='login-button']");
	public static readonly By SongPlayBtnBy = By.CssSelector("svg[data-testid='search-icon']");
	public static readonly By UserProfileBtnBy = By.CssSelector("button[data-testid='user-widget-link']");
	public static readonly By LogOutBtnBy = By.CssSelector("button[data-testid=user-widget-dropdown-logout]");

	public static readonly By CreatePlaylistPlusBtnBy = By.CssSelector("button[aria-label='Create playlist or folder']");
    public static readonly By CreateNewPlaylistMenuItemBy = By.CssSelector("button[role='menuitem'] span[data-encore-id='type']");
	public static readonly By NewPlaylistTitleBy = By.CssSelector("h1.encore-text-headline-large[data-encore-id='text']");
	public static readonly By CreatePlaylistTooltipBy = By.CssSelector("div[data-testid='createPlaylist-hook']");

    public static readonly By AccountMenuItemBy = By.XPath("//button[span[text()='Account']]");

	public static readonly By SearchTopResultBy = By.CssSelector("section[aria-label = 'Top result'] a[title]");
}
