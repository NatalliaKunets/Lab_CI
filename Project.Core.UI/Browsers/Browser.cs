using OpenQA.Selenium;
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

    public WebDriverWait Wait { get => new WebDriverWait(driver, TimeSpan.FromSeconds(10)); }

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

    public void RefreshPage()
    {
        driver.Navigate().Refresh();
    }

    public void WindowMaximize()
    {
        driver.Manage().Window.Maximize();
    }
}

