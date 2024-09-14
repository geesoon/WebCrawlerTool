using OpenQA.Selenium;
using EnsureThat;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class SeleniumWebCrawler : IWebCrawler, IDisposable
    {
        private readonly IWebDriver webDriver;
        private bool isDisposed;

        public SeleniumWebCrawler(IWebDriver webDriver)
        {
            this.webDriver = EnsureArg.IsNotNull(webDriver, nameof(webDriver));
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

        public void BrowseUrl(string Url)
        {
            EnsureArg.IsNotNullOrWhiteSpace(Url, nameof(Url));
            this.webDriver.Url = Url;
        }
    }
}