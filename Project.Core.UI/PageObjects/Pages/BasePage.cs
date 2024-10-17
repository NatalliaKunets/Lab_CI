using OpenQA.Selenium;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements.Elements;
using System.Globalization;

namespace Project.Core.UI.PageObjects.Pages;

public abstract class BasePage
{
    protected IBrowser Driver { get; set; }

    protected BasePage(IBrowser driver)
    {
        Driver = driver;
        Driver.WindowMaximize();
    }

    public abstract bool IsPageLoaded();

    public string Title
    {
        get { return Driver.Title.ToString(CultureInfo.InvariantCulture); }
    }

    protected IElement? WaitForElement(By locator)
    {
        return Driver.Wait.Until(Driver => {
            try
            {
                var element = Driver.FindElement(locator);
                return element.Displayed ? new Element(element) : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null; 
            }
        });
    }
}
