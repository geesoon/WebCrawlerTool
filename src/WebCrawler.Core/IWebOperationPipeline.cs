namespace WebCrawler.Core
{
    /// <summary>
    /// This IWebOperationPipeline responsible for chaining operations into a pipeline
    /// </summary>
    public interface IWebOperationPipeline
    {
        public void AddOperation(IWebOperation webOperation);
        public void RemoveOperation(IWebOperation webOperation);
        public List<object> Execute();
    }
}