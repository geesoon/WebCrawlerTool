using System.Globalization;
using CsvHelper;
using WebCrawler.Core.Interface;

namespace WebCrawler.Core.Service
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