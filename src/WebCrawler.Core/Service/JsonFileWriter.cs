using System.Text.Json;
using System.Text.Json.Serialization;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class JsonFileWriter : IFileWriter
    {
        public void WriteToFile(string path, object data)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var streamWriter = new StreamWriter(fileStream);
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data, options);
            streamWriter.WriteLine(jsonString);
        }
    }
}