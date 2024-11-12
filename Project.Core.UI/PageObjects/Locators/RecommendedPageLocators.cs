using OpenQA.Selenium;
using System.Text;

namespace Project.Core.UI.PageObjects.Locators;

public static class RecommendedPageLocators
{
    public static readonly By FeaturedChartsSectionBy = By.CssSelector("section[aria-label = 'Featured Charts']");
    public static readonly By FirstPlaylistBy = By.CssSelector("div[data-encore-id = 'card'] div[role = 'button']");
    public static readonly By PlayBtnBy = By.CssSelector("div[data-encore-id = 'card'] button[data-testid = 'play-button']");
}
