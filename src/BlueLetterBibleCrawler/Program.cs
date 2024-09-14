using BlueLetterBibleCrawler.Operation;
using OpenQA.Selenium.Chrome;
using WebCrawler.Core.Service;
using Bible.Data;

namespace BlueLetterBibleCrawler
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var webCrawler = CreateWebCrawler();
            var operationPipeline = new WebOperationPipeline(webCrawler);
            operationPipeline.AddOperation(new SearchOperation("Love", BibleTranslation.KJV));

            var fileName = "blb_concordance_love";
            _ = new WorkFlow()
                .AddPipeline(operationPipeline)
                .Execute()
                .OutputResults(new JsonFileWriter(), fileName + "json")

            webCrawler.Dispose();
        }

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
    }
}