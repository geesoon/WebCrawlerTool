using OpenQA.Selenium;

namespace WebCrawler.Core
{
    /// <summary>
    /// An abstraction of web crawler
    /// </summary>
    public interface IWebCrawler
    {
        /// <summary>
        /// Find element from the web page 
        /// </summary>
        /// <param name="by"></param>
        /// <returns>A list of read only IWebElement</returns> 
        /// <summary>
        public IReadOnlyList<IWebElement> FindElements(By by);

        /// <summary>
        /// Navigate to a URL and optionally wait for a condition
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="waitCondition"></param> <summary>
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="waitCondition"></param>
        public void BrowseUrl(string Url, Func<IWebDriver, IWebElement>? waitCondition = null);

        /// <summary>
        /// Navigate to a URL and wait for an element to be present
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="by"></param>
        public void BrowseUrlAndWaitForElement(string Url, By by);
    }
}