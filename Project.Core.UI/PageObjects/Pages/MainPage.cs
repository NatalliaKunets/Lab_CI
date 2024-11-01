﻿using OpenQA.Selenium;
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
	private IElement CreatePlaylistBtn => Driver.FindElement(MainPageLocators.CreatePlaylistBtnBy);
	private IElement LoginBtn => Driver.FindElement(MainPageLocators.LoginBtnBy);
	private IElement SearchBtn => Driver.FindElement(MainPageLocators.SearchBtnBy);
	private IElement SongPlayBtn => Driver.FindElement(MainPageLocators.SongPlayBtnBy);
	private IElement UserProfileBtn => Driver.FindElement(MainPageLocators.UserProfileBtn);
	private IElement LogoutBtn => Driver.FindElement(MainPageLocators.LogOutBtn);

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

	public void ClickCreatePlaylistButton()
	{
		try
		{
			WaitForElement(MainPageLocators.CreatePlaylistBtnBy);
			CreatePlaylistBtn.Click();
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "Main Page: Failed to click the Create Playlist button.");
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
			WaitForElement(MainPageLocators.UserProfileBtn);
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
			WaitForElement(MainPageLocators.LogOutBtn);
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
			return WaitForElement(MainPageLocators.UserProfileBtn) != null;
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
}
