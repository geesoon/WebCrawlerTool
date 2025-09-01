using System.Collections.Concurrent;
using EnsureThat;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class WebOperationPipeline : IWebOperationPipeline
    {
        private readonly IWebCrawler webCrawler;
        private readonly ConcurrentDictionary<IWebOperation, IEnumerable<object>> webOperations = [];

        public WebOperationPipeline(IWebCrawler webCrawler)
        {
            this.webCrawler = EnsureArg.IsNotNull(webCrawler, nameof(webCrawler));
        }

        public void AddOperation(IWebOperation webOperation)
        {
            EnsureArg.IsNotNull(webOperation, nameof(webOperation));
            this.webOperations.TryAdd(webOperation, null);
        }

        public void RemoveOperation(IWebOperation webOperation)
        {
            EnsureArg.IsNotNull(webOperation, nameof(webOperation));
            this.webOperations.TryRemove(webOperation, out _);
        }

        public List<object> Execute()
        {
            var results = Enumerable.Empty<object>();
            object nextInput = null;
            foreach (var keyValuePair in this.webOperations)
            {
                nextInput = keyValuePair.Key.Operate(this.webCrawler, nextInput);
                results = results.Append(nextInput);
            }
            return results.ToList();
        }
    }
}