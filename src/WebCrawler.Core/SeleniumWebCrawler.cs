using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EnsureThat;

namespace WebCrawler.Core
{
    public sealed class SeleniumWebCrawler : IWebCrawler, IDisposable
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait defaultWait;
        private bool isDisposed;

        public SeleniumWebCrawler(IWebDriver webDriver, int defaultTimeoutSeconds = 10)
        {
            this.webDriver = EnsureArg.IsNotNull(webDriver, nameof(webDriver));
            this.defaultWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(defaultTimeoutSeconds));
        }

        public void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }

            this.webDriver.Quit();
            this.webDriver.Dispose();
            this.isDisposed = true;
        }

        public IReadOnlyList<IWebElement> FindElements(By by)
        {
            return this.webDriver.FindElements(by);
        }

        /// <summary>
        /// Navigates to a URL and optionally waits for a condition.
        /// </summary>
        /// <param name="url">The target URL.</param>
        public void BrowseUrl(string url)
        {
            EnsureArg.IsNotNullOrWhiteSpace(url, nameof(url));
            this.webDriver.Url = url;

            // Always wait until document.readyState == complete
            this.defaultWait.Until(driver =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}