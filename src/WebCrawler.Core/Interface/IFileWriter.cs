namespace WebCrawler.Core.Interface
{
    public interface IFileWriter
    {
        Task WriteToFileAsync(string path, object data);
    }
}