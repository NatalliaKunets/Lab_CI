using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Project.Core.Enums;

namespace Project.Core.UI.Browsers;
public static class DriverFactory
{
    public static Browser InitializeDriver(BrowserType browserType)
    {
        IWebDriver driver;

        switch (browserType)
        {
            case BrowserType.Chrome:
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--headless");

                driver = new ChromeDriver(chromeOptions);
                break;
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("--no-sandbox");
                edgeOptions.AddArgument("--disable-dev-shm-usage");
                edgeOptions.AddArgument("--headless");

                driver = new EdgeDriver(edgeOptions);
                break;
            default:
                throw new ArgumentException($"{browserType} is not supported");
        }
        return new Browser(driver);
    }
}

