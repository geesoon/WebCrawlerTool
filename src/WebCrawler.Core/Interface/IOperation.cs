namespace WebCrawler.Core.Interface
{
    public interface IOperation
    {
        public object Operate(IWebCrawler webCrawler, dynamic input);
    }
}