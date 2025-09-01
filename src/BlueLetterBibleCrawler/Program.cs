using BlueLetterBibleCrawler.Operation;
using OpenQA.Selenium.Chrome;
using WebCrawler.Core;

namespace BlueLetterBibleCrawler
{
    public static class Program
    {
        private static SeleniumWebCrawler CreateWebCrawler()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--disable-gpu");

            var webDriver = new ChromeDriver(chromeOptions)
            {
                Url = "https://www.blueletterbible.org/"
            };

            return new SeleniumWebCrawler(webDriver);
        }

        public static async Task Main(string[] args)
        {
            if (args.Length != 4 || args[0] != "-s" || args[2] != "-t")
            {
                Console.WriteLine("Usage: BlueLetterBibleCrawler -s <search term> -t <bible translation>");
                return;
            }

            var searchTerm = args[1];
            var translation = args[3];

            var webCrawler = CreateWebCrawler();
            var operationPipeline = new WebOperationPipeline(webCrawler);
            operationPipeline.AddOperation(new SearchOperation(searchTerm, translation));

            var workflow = new WorkFlow()
                .AddPipeline(operationPipeline)
                .Execute();

            await workflow.OutputResultsAsync(
                new JsonFileWriter(),
                searchTerm,
                translation,
                "blb_concordance_search_results.json");
            webCrawler.Dispose();
        }
    }
}