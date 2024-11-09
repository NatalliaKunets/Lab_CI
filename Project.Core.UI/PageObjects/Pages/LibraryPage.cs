using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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


	public bool isPlaylistCreated()
	{
		if (LibraryList != null && LibraryListItems.Count > 0)
		{
			return true;
		}
		return false;
	}



	public void EditPlaylistDetails()
	{
		try
		{
			WaitForElement(LibraryPageLocators.LibraryThreeDotsBtnBy).Click();
			WaitForElement(LibraryPageLocators.EditDetailsBtnBy).Click();
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "Library Page: Failed to click on Three Dots Button");
		}
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

	public void ChoosePlaylist(string playlist)
	{
		FindPlaylistByName(playlist).Click();
	}

	public void RenamePlaylist(string name)
	{
		try
		{
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
}