namespace WebCrawler.Core.Interface
{
    public interface IWebOperation<TOutput, in TContext> : IOperation
    {
        TOutput Operate(IWebCrawler webCrawler, TContext context);
    }
}