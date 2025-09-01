using System.Collections.Concurrent;
using EnsureThat;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    /// <summary>
    /// A workflow implementation
    /// </summary>
    public sealed class WorkFlow : IWorkFlow
    {
        private readonly ConcurrentDictionary<IWebOperationPipeline, IEnumerable<object>> pipelines = new();

        public WorkFlow()
        {
        }

        public IWorkFlow AddPipeline(IWebOperationPipeline pipeline)
        {
            EnsureArg.IsNotNull(pipeline, nameof(pipeline));
            this.pipelines.TryAdd(pipeline, null);
            return this;
        }

        public IWorkFlow RemovePipeline(IWebOperationPipeline pipeline)
        {
            EnsureArg.IsNotNull(pipeline, nameof(pipeline));
            this.pipelines.TryRemove(pipeline, out _);
            return this;
        }

        public IWorkFlow Execute()
        {
            foreach (var keyValuePair in this.pipelines)
            {
                var result = keyValuePair.Key.Execute();
                this.pipelines.TryUpdate(keyValuePair.Key, result, keyValuePair.Value);
            }
            return this;
        }

        public async Task<IWorkFlow> OutputResultsAsync(IFileWriter fileWriter, string fileName)
        {
            var allResults = this.ParseOutput();
            fileName = fileName != null ? $"./Outputs/{fileName}" : $"./Outputs/{GetType().Name}_result.json";

            await fileWriter.WriteToFileAsync(fileName, allResults).ConfigureAwait(false);
            return this;
        }

        private Dictionary<string, IEnumerable<object>> ParseOutput()
        {
            return this.pipelines
                .ToDictionary(
                    item => item.Key.GetType().Name,
                    item => item.Value);
        }
    }
}