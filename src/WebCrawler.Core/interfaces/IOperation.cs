namespace WebCrawler.Core.Interfaces
{
    public interface IOperation
    {
        public object Operate(IWebCrawler webCrawler, dynamic input);
    }
}