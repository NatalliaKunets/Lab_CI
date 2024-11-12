using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;
using Project.Core.UI.PageObjects.Locators;

namespace Project.Core.UI.PageObjects.Pages;

public class RecommendedPage :BasePage
{
    public RecommendedPage(IBrowser driver) : base(driver)
    {
        Driver = driver;
    }

    private IElement FeaturedChartsSection => Driver.FindElement(RecommendedPageLocators.FeaturedChartsSectionBy);

    public override bool IsPageLoaded()
    {
        try
        {
            return WaitForElement(RecommendedPageLocators.FeaturedChartsSectionBy) != null;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void ClickFirstPlaylist()
    {
        try
        {
            IElement? firstPlaylist = FeaturedChartsSection.FindElement(RecommendedPageLocators.FirstPlaylistBy);
            if(firstPlaylist == null)
            {
                Logger.Error("Recommended Page: Failed to find the first playlist.");

                throw new NoSuchElementException();
            }

            firstPlaylist.Click();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Recommended Page: Failed to click the first playlist.");
            throw;
        }
    }
}
