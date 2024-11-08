using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Project.Core.Logging;
using Project.Core.UI.Elements;
using System.Collections.ObjectModel;

namespace Project.Core.UI.Browsers;

public class Browser : IBrowser
{
    private readonly IWebDriver driver;

    public Browser(IWebDriver driver)
    {
        this.driver = driver;
    }

    public WebDriverWait Wait => new (driver, TimeSpan.FromSeconds(10)); 

    public Actions Actions => new (driver);
    public string Url { get => driver.Url; set => driver.Url = value; }

    public string Title => driver.Title;

    public string CurrentWindowHandle => driver.CurrentWindowHandle;

    public ReadOnlyCollection<string> WindowHandles => driver.WindowHandles;

    public IOptions Manage() => driver.Manage();

    public void Navigate(string url) => driver.Navigate().GoToUrl(url);

    public ITargetLocator SwitchTo() => driver.SwitchTo();

    public void Quit() => driver.Quit();

    public void Close() => driver.Close();

    public IElement FindElement(By by)
    {
        try
        {
            return new Element(driver.FindElement(by));
        }
        catch (Exception ex)
        {
            Logger.Error(ex, $"Failed to find WebElement by {by}");
            throw;
        }
    }

    public ReadOnlyCollection<IElement> FindElements(By by)
    {
        try
        {
            //return driver.FindElements(by);

            var elements = driver.FindElements(by)
                .Select(e => e as IElement)
                .Where(e => e != null)
                .ToList()
                .AsReadOnly();

            return elements;
        }
        catch (NoSuchElementException e)
        {
            throw new NoSuchElementException($"No elements found with locator: {by}", e);
        }
    }


    public void RefreshPage()
    {
        driver.Navigate().Refresh();
    }

    public void WindowMaximize()
    {
        driver.Manage().Window.Maximize();
    }
}

