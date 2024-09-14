namespace WebCrawler.Core.Interface
{
    /// <summary>
    /// This IWebOperationPipeline responsible for chaining operations into a pipeline
    /// </summary>
    public interface IWebOperationPipeline
    {
        public void AddOperation(IOperation operation);
        public void RemoveOperation(IOperation operation);
        public IEnumerable<object> Execute();
    }
}