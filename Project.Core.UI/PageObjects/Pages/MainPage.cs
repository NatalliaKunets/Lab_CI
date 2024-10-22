using OpenQA.Selenium;
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
}
