using System.Text.Json;
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

            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                var jsonString = JsonSerializer.Serialize(data);
                streamWriter.WriteLine(jsonString);
            }
        }
    }
}