namespace WebCrawler.Core
{
    public interface IFileWriter
    {
        Task WriteToFileAsync(string path, object data);
    }
}