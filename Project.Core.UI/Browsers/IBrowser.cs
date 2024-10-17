using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Project.Core.UI.Browsers;

public interface IBrowser
{
    string Url { get; set; }

    string Title { get; }

    WebDriverWait Wait { get; }

    string CurrentWindowHandle { get; }

    ReadOnlyCollection<string> WindowHandles { get; }

    IOptions Manage();

    void Navigate(string url);

    ITargetLocator SwitchTo();

    void Close();

    void Quit();

    IWebElement FindElement(By by);

    void RefreshPage();

    void WindowMaximize();
}

