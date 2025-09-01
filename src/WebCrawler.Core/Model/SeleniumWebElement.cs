using OpenQA.Selenium;

namespace WebCrawler.Core.Model
{
    internal sealed class SeleniumWebElement : IElement
    {
        private readonly IWebElement webElement;
        public SeleniumWebElement(IWebElement webElement)
        {
            this.webElement = webElement;
        }
    }
}