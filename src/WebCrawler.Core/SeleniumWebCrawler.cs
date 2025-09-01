using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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

        public void BrowseUrl(
            string url, Func<IWebDriver, IWebElement>? waitCondition = null)
        {
            EnsureArg.IsNotNullOrWhiteSpace(url, nameof(url));
            this.webDriver.Url = url;

            // Always wait until document.readyState == complete
            this.defaultWait.Until(driver =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            // If caller wants to wait for something specific (like an element)
            if (waitCondition != null)
            {
                this.defaultWait.Until(waitCondition);
            }
        }

        public void BrowseUrlAndWaitForElement(string url, By locator)
        {
            this.BrowseUrl(url, ExpectedConditions.ElementExists(locator));
        }
    }
}