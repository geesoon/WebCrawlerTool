using System.Globalization;
using CsvHelper;

namespace WebCrawler.Core.Services
{
    public sealed class CsvFileWriter : IFileWriter
    {
        public void WriteToFile(string path, object data)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords((IEnumerable<dynamic>)data);
        }
    }
}