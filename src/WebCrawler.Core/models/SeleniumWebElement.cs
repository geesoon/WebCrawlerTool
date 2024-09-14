using OpenQA.Selenium;

namespace WebCrawler.Core.Model
{
    public class SeleniumWebElement : IElement
    {
        private readonly IWebElement webElement;
        public SeleniumWebElement(IWebElement webElement)
        {
            this.webElement = webElement;
        }
    }
}