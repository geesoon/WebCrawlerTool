using System.Globalization;
using CsvHelper;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
{
    public sealed class CsvFileWriter : IFileWriter
    {
        public async Task WriteToFileAsync(string path, object data)
        {
            await using var writer = new StreamWriter(path);
            await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            await csv.WriteRecordsAsync([data]);
        }
    }
}