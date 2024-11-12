using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Project.Core.UI.Elements;

public class Element : IElement
{
	private readonly IWebElement _webElement;

    public Element(IWebElement webElement)
	{
		_webElement = webElement ?? throw new ArgumentNullException(nameof(webElement), "WebElement cannot be null.");
	}

    public IWebElement WebElement => _webElement;

	public string TagName => _webElement.TagName;
	public string Text => _webElement.Text;
	public Point Location => _webElement.Location;
	public Size Size => _webElement.Size;
	
	public bool Enabled => _webElement.Enabled;
	public bool Selected => _webElement.Selected;
	public bool Displayed => _webElement.Displayed;

    public IElement FindElement(By by)
	{
		try
		{
			return new Element(_webElement.FindElement(by));
		}
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException($"No element found with locator: {by}", e);
		}
	}

	public void Clear()
	{
		try
		{
			_webElement.Clear();
		}
		catch (InvalidElementStateException e)
		{
			throw new InvalidElementStateException("Element is not in a state that allows clearing.", e);
		}
	}

	public void Click()
	{
		try
		{
			_webElement.Click();
		}
		catch (ElementNotInteractableException e)
		{
			throw new ElementNotInteractableException("Element is not interactable.", e);
		}
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException("Element does not exist in the DOM.", e);
		}
	}


	public ReadOnlyCollection<IElement> FindElements(By by)
	{
		try
		{
            var elements = _webElement.FindElements(by)
            .Select(e => e as IElement) 
            .Where(e => e != null) 
            .ToList()
            .AsReadOnly();

            return elements!;
        }
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException($"No elements found with locator: {by}", e);
		}
	}

	public string GetAttribute(string attributeName)
	{
		try
		{
			return _webElement.GetAttribute(attributeName);
		}
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException($"Element not found when trying to get attribute '{attributeName}'.", e);
		}
	}

	public string GetCssValue(string propertyName)
	{
		try
		{
			return _webElement.GetCssValue(propertyName);
		}
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException($"Element not found when trying to get CSS property '{propertyName}'.", e);
		}
	}
		
	public void SendKeys(string text)
	{
		try
		{
			_webElement.SendKeys(text);
		}
		catch (InvalidElementStateException e)
		{
			throw new InvalidElementStateException("Element state is invalid for sending keys.", e);
		}
	}

	public void Submit()
	{
		try
		{
			_webElement.Submit();
		}
		catch (NoSuchElementException e)
		{
			throw new NoSuchElementException("Element not found for submitting.", e);
		}
		catch (ElementNotInteractableException e)
		{
			throw new ElementNotInteractableException("Element is not interactable for submission.", e);
		}
	}
}