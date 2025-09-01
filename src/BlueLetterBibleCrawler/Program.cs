using BlueLetterBibleCrawler.Operation;
using OpenQA.Selenium.Chrome;
using WebCrawler.Core.Service;
using Bible.Data;

namespace BlueLetterBibleCrawler
{
    public static class Program
    {
        private static SeleniumWebCrawler CreateWebCrawler()
        {
            var chromeOptions = new ChromeOptions();
            // chromeOptions.AddArgument("--headless");
            // chromeOptions.AddArgument("--disable-gpu");

            var webDriver = new ChromeDriver(chromeOptions)
            {
                Url = "https://www.blueletterbible.org/"
            };

            return new SeleniumWebCrawler(webDriver);
        }

        public static async Task Main(string[] args)
        {
            var webCrawler = CreateWebCrawler();
            var operationPipeline = new WebOperationPipeline(webCrawler);
            operationPipeline.AddOperation(new SearchOperation("Love", BibleTranslation.KJV));

            var workflow = new WorkFlow()
                .AddPipeline(operationPipeline)
                .Execute();

            await workflow.OutputResultsAsync(new JsonFileWriter(), "blb_concordance_love.json");
            webCrawler.Dispose();
        }
    }
}