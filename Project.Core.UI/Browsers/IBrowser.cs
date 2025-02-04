﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Project.Core.UI.Elements;
using System.Collections.ObjectModel;

namespace Project.Core.UI.Browsers;

public interface IBrowser
{
    string Url { get; set; }

    string Title { get; }

    WebDriverWait Wait { get; }

    Actions Actions { get; }

    string CurrentWindowHandle { get; }

    ReadOnlyCollection<string> WindowHandles { get; }

    IOptions Manage();

    void Navigate(string url);

    ITargetLocator SwitchTo();

    void Close();

    void Quit();

    IElement FindElement(By by);

    ReadOnlyCollection<IElement> FindElements(By by);

    void RefreshPage();

    void WindowMaximize();

    void TakeScreenshot(string testName);
}

