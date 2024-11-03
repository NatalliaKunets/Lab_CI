using System.Collections.ObjectModel;
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
	private static readonly string _playlistXPathTemplate = "//span[contains(text(), '{0}')]";


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


	public IElement FindPlaylistByName(IBrowser driver, string playlistName)
	{
		string xpath = string.Format(_playlistXPathTemplate, playlistName);
		var elem = driver.FindElement(By.XPath(xpath));
		return elem;
	}

	public void ChoosePlaylist(string playlistName)
	{
		var elem = FindPlaylistByName(Driver, playlistName);
		if (elem != null)
		{
			elem.Click();
		}
	}

	public void EditPlaylistDetails()
	{
		try
		{
			LibraryThreeDotsBtn.Click();
			WaitForElement(LibraryPageLocators.EditDetailsBtnBy).Click();
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