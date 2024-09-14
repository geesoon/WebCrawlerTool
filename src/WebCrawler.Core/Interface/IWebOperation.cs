namespace WebCrawler.Core.Interface
{
    public interface IWebOperation<out TOutput, in TContext> : IOperation
    {
        TOutput Operate(IWebCrawler webCrawler, TContext context);
    }
}