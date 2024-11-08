using OpenQA.Selenium;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class PlaylistPage : BasePage
{
    public PlaylistPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(PlaylistPageLocators.PlaylistSectionBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public IElement? FindTrackByName(string trackName)
    {
        By TrackByNameBy = By.CssSelector(string.Format(PlaylistPageLocators.TrackByNameTemplate, trackName));

        try
        {
            return WaitForElement(TrackByNameBy);
        }
        catch (WebDriverTimeoutException)
        {
            return null;
        }
    }

}
