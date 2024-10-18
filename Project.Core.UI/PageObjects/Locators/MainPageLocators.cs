using OpenQA.Selenium;

namespace Project.Core.UI.PageObjects.Locators
{
	public static class MainPageLocators
	{
		public static readonly By HomeBtnBy = By.CssSelector(".Button-sc-1dqy6lx-0.bksmLQ");
		public static readonly By SearchInputBy = By.CssSelector(".Input-sc-1gbx9xe-0");
		public static readonly By CreatePlaylistBtnBy = By.XPath("//button[contains(., 'Create playlist')]");
		public static readonly By LoginBtnBy = By.CssSelector("button[data-testid='login-button']");
		public static readonly By SearchBtnBy = By.CssSelector("svg[data-testid='search-icon']");
		public static readonly By SongPlayBtnBy = By.CssSelector("svg[data-testid='search-icon']");
	}
}
