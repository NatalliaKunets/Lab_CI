using OpenQA.Selenium;

namespace Project.Core.UI.Browsers;

public class Browser
{
    private readonly IWebDriver driver;

    public Browser(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Quit() => driver.Quit();
}
