namespace WebCrawler.Core
{
    public interface IWebOperation
    {
        object Operate(IWebCrawler webCrawler, object input);
    }
}