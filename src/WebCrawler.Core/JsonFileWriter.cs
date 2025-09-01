using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebCrawler.Core
{
    public sealed class JsonFileWriter : IFileWriter
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter(),
            },
            WriteIndented = true,
        };

        public async Task WriteToFileAsync(string path, object data)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory) && !string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            await using var streamWriter = new StreamWriter(fileStream);

            var jsonString = JsonSerializer.Serialize(data, this._jsonSerializerOptions);
            await streamWriter.WriteLineAsync(jsonString);
        }
    }
}