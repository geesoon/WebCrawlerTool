using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    /// <summary>
    /// A workflow implementation
    /// </summary>
    public sealed class WorkFlow : IWorkFlow
    {
        private readonly IDictionary<IWebOperationPipeline, IEnumerable<object>> results;
        private IEnumerable<IWebOperationPipeline> pipelines = [];

        public WorkFlow(IEnumerable<IWebOperationPipeline> pipelines = null)
        {
            if (pipelines != null)
            {
                this.pipelines = pipelines;
            }

            this.results = new Dictionary<IWebOperationPipeline, IEnumerable<object>>();
        }

        public IWorkFlow AddPipeline(IWebOperationPipeline pipeline)
        {
            this.pipelines = this.pipelines.Append(pipeline);
            return this;
        }

        public IWorkFlow RemovePipeline(IWebOperationPipeline pipeline)
        {
            this.pipelines = this.pipelines.Where(x => x != pipeline);
            return this;
        }

        public IWorkFlow Execute()
        {
            foreach (var pipeline in this.pipelines)
            {
                var result = pipeline.Execute();
                this.results.Add(pipeline, result);
            }
            return this;
        }

        public IWorkFlow OutputResults(IFileWriter fileWriter, string fileName)
        {
            var allResults = this.ParseOutput();

            if (fileName != null)
            {
                fileWriter.WriteToFile($"./Outputs/{fileName}", allResults);
            }
            else
            {
                fileWriter.WriteToFile($"./Outputs/{GetType().Name}_result.json", allResults);
            }
            return this;
        }

        private Dictionary<string, IEnumerable<object>> ParseOutput()
        {
            var parsedOutputs = new Dictionary<string, IEnumerable<object>>();
            foreach (var item in this.results)
            {
                parsedOutputs.Add(item.Key.GetType().Name, item.Value);
            }
            return parsedOutputs;
        }
    }
}