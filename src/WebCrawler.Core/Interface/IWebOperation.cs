namespace WebCrawler.Core.Interface
{
    public interface IWebOperation
    {
        object Operate(IWebCrawler webCrawler, object input);
    }
}