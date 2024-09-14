using System.Text.Json;

namespace WebCrawler.Core.Services
{
    public sealed class JsonFileWriter : IFileWriter
    {
        public void WriteToFile(string path, object data)
        {
            var jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(path, jsonString);
        }
    }
}