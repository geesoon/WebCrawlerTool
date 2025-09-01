using System.Collections.Concurrent;
using EnsureThat;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class WebOperationPipeline : IWebOperationPipeline
    {
        private readonly IWebCrawler webCrawler;
        private readonly ConcurrentDictionary<IOperation, IEnumerable<object>> operations = [];

        public WebOperationPipeline(IWebCrawler webCrawler)
        {
            this.webCrawler = EnsureArg.IsNotNull(webCrawler, nameof(webCrawler));
        }

        public void AddOperation(IOperation operation)
        {
            EnsureArg.IsNotNull(operation, nameof(operation));
            this.operations.TryAdd(operation, null);
        }

        public void RemoveOperation(IOperation operation)
        {
            EnsureArg.IsNotNull(operation, nameof(operation));
            this.operations.TryRemove(operation, out var operations);
        }

        public IEnumerable<object> Execute()
        {
            var results = Enumerable.Empty<object>();
            object nextInput = null;
            foreach (var keyValuePair in this.operations)
            {
                nextInput = keyValuePair.Key.Operate(this.webCrawler, nextInput);
                results = results.Append(nextInput);
            }
            return results;
        }
    }
}