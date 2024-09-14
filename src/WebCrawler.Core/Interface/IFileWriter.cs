namespace WebCrawler.Core.Interface
{
    public interface IFileWriter
    {
        void WriteToFile(string path, object data);
    }
}