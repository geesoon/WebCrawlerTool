namespace WebCrawler.Core.Interfaces
{
    public interface IFileWriter
    {
        void WriteToFile(string path, object data);
    }
}