using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public abstract class WebOperation<TOutput, TContext> : IWebOperation<TOutput, TContext>
    {
        protected abstract TOutput Operate(IWebCrawler webCrawler, TContext context);

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