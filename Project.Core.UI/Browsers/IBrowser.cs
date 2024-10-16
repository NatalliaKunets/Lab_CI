using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Project.Core.UI.Browsers;

public interface IBrowser
{
    string Url { get; set; }

    string Title { get;}

    string CurrentWindowHandle { get; }

    ReadOnlyCollection<string> WindowHandles { get; }
    
    IOptions Manage();
    
    INavigation Navigate(string url);
    
    ITargetLocator SwitchTo();
    
    void Close();

    void Quit();

    IWebElement FindElement(By by);

    void RefreshPage();

    void WindowMaximize();
}
