namespace WebCrawler.Core
{
    /// <summary>
    /// Chaining operation pipeline across multiple web site and aggregate the results.
    /// </summary>
    public interface IWorkFlow
    {
        public IWorkFlow AddPipeline(IWebOperationPipeline pipeline);
        public IWorkFlow RemovePipeline(IWebOperationPipeline pipeline);
        public IWorkFlow Execute();
        public Task<IWorkFlow> OutputResultsAsync(
            IFileWriter fileWriter,
            string searchTerm,
            string translation,
            string fileName);
    }
}