using OpenQA.Selenium;
using System.Drawing;

namespace Project.Core.UI.Elements;

public interface IElement
{
    //IWebElement _webElement;

    string TagName { get; }
    string Text { get; }
    Point Location { get; }
    Size Size { get; }

    bool Enabled { get; }
    bool Selected { get; }
    bool Displayed { get; }

    IElement FindElement(By by);

    //void Clear(string wevElementName);
    void Clear();

    void Click();
    void SendKeys(string text);
    void Submit();
    
    string GetAttribute(string attributeName);
    string GetCssValue(string propertyName);
}