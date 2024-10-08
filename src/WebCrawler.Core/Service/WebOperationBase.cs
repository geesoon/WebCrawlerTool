using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public abstract class WebOperationBase<TOutput, TContext> : IWebOperation<TOutput, TContext>
    {
        public abstract TOutput Operate(IWebCrawler webCrawler, TContext context);

        public object Operate(IWebCrawler webCrawler, dynamic input)
        {
            return Operate(webCrawler, input);
        }

        TOutput IWebOperation<TOutput, TContext>.Operate(IWebCrawler webCrawler, TContext context)
        {
            return Operate(webCrawler, context);
        }
    }
}