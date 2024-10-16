using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Project.Core.UI.Elements.Elements
{
	public class Element : IElement
	{
		private readonly IWebElement _webElement;

		public Element(IWebElement webElement)
		{
			_webElement = webElement ?? throw new ArgumentNullException(nameof(webElement), "WebElement cannot be null.");
		}

		public string TagName => _webElement.TagName;

		public string Text => _webElement.Text;

		public bool Enabled => _webElement.Enabled;

		public bool Selected => _webElement.Selected;

		public Point Location => _webElement.Location;

		public Size Size => _webElement.Size;

		public bool Displayed => _webElement.Displayed;

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

		public void Clear(string element)
		{
			throw new NotImplementedException();
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

		public IWebElement FindElement(By by)
		{
			try
			{
				return _webElement.FindElement(by);
			}
			catch (NoSuchElementException e)
			{
				throw new NoSuchElementException($"No element found with locator: {by}", e);
			}
		}

		public ReadOnlyCollection<IWebElement> FindElements(By by)
		{
			try
			{
				return _webElement.FindElements(by);
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

		public string GetDomAttribute(string attributeName)
		{
			try
			{
				return _webElement.GetDomAttribute(attributeName);
			}
			catch (NoSuchElementException e)
			{
				throw new NoSuchElementException($"Element not found when trying to get DOM attribute '{attributeName}'.", e);
			}
		}

		public string GetDomProperty(string propertyName)
		{
			try
			{
				return _webElement.GetDomProperty(propertyName);
			}
			catch (NoSuchElementException e)
			{
				throw new NoSuchElementException($"Element not found when trying to get DOM property '{propertyName}'.", e);
			}
		}

		public ISearchContext GetShadowRoot()
		{
			try
			{
				return _webElement.GetShadowRoot();
			}
			catch (NoSuchElementException e)
			{
				throw new NoSuchElementException("Element not found when trying to get ShadowRoot.", e);
			}
		}

		public void SendKeys(string value)
		{
			try
			{
				_webElement.SendKeys(value);
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
}
