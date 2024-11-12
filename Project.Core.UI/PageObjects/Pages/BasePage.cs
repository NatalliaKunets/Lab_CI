using OpenQA.Selenium;
using Project.Core.Logging;
using Project.Core.UI.Browsers;
using Project.Core.UI.Elements;

namespace Project.Core.UI.PageObjects.Pages;

public abstract class BasePage
{
    protected IBrowser Driver { get; set; }

    protected BasePage(IBrowser driver)
    {
        Driver = driver;
    }

    public abstract bool IsPageLoaded();

    public string Title => Driver.Title; 

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

    //protected IElement? WaitForElement(By locator, IElement ancestorElement)
    //{
    //    return Driver.Wait.Until(_ => {
    //        try
    //        {
    //            var element = ancestorElement.FindElement(locator);
    //            return element.Displayed ? element : null;
    //        }
    //        catch (NoSuchElementException)
    //        {
    //            return null;
    //        }
    //        catch (StaleElementReferenceException)
    //        {
    //            return null;
    //        }
    //    });
    //}

    protected void MoveToElement(IElement element)
    {
        try
        {
            Driver.Actions.MoveToElement(element.WebElement).Perform();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Failed to hover over the specified element.");
            throw;
        }
    }

    protected void RightClickElement(IElement element)
    {
        try
        {
            Driver.Actions.ContextClick(element.WebElement).Perform();   
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Failed to right click the specified element.");
            throw;
        }
    }
}
