using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Project.Core.Enums;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Project.Core.UI.Browsers;
public static class DriverFactory
{
    public static Browser InitializeDriver(BrowserType browserType)
    {
        IWebDriver driver;

        switch (browserType)
        {
            case BrowserType.Chrome:
                new DriverManager().SetUpDriver(new ChromeConfig());

                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--headless");
                chromeOptions.AddArgument("--disable-gpu");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-dev-shm-usage");

                driver = new ChromeDriver(chromeOptions);
                break;
            case BrowserType.Edge:
                new DriverManager().SetUpDriver(new EdgeConfig());

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

