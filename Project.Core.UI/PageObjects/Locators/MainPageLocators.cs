﻿using OpenQA.Selenium;

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
	public static readonly By SongPlayBtnBy = By.CssSelector("svg[data-testid='search-icon']");
	public static readonly By UserProfileBtn = By.CssSelector("button[data-testid='user-widget-link']");
	public static readonly By LogOutBtn = By.CssSelector("button[data-testid=user-widget-dropdown-logout]");
}
