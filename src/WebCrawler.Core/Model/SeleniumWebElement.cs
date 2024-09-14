using OpenQA.Selenium;
using WebCrawler.Core.Interface;

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