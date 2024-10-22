using OpenQA.Selenium;

namespace Project.Core.UI.Elements;

public interface IElement : IWebElement
{
	string TagName { get; }
	void Clear(string element);
	void Click();
	void SendKeys(string text);
	void Submit();
}