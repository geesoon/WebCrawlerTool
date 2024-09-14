using EnsureThat;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class WebOperationPipeline : IWebOperationPipeline
    {
        private readonly IWebCrawler webCrawler;
        private IEnumerable<IOperation> operations = [];

        public WebOperationPipeline(IWebCrawler webCrawler, IEnumerable<IOperation> operations = null)
        {
            this.webCrawler = EnsureArg.IsNotNull(webCrawler, nameof(webCrawler));
            if (operations is not null)
            {
                this.operations = operations;
            }
        }

        public void AddOperation(IOperation operation)
        {
            if (!this.operations.Contains(operation))
            {
                this.operations = this.operations.Append(operation);
            }
        }

        public void RemoveOperation(IOperation operation)
        {
            this.operations = this.operations.Where(x => x != operation);
        }

        public IEnumerable<object> Execute()
        {
            var results = Enumerable.Empty<object>();
            object nextInput = null;
            foreach (var operation in this.operations)
            {
                nextInput = operation.Operate(this.webCrawler, nextInput);
                results = results.Append(nextInput);
            }
            return results;
        }
    }
}