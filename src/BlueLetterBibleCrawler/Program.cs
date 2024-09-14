using BlueLetterBibleWebCrawler.Operations;
using OpenQA.Selenium.Chrome;
using WebCrawler.Core.Service;

namespace BlueLetterBibleCrawler
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var workflow = new WorkFlowBase();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--disable-gpu");

            using var blueLetterBibleWebDriver = new ChromeDriver(chromeOptions)
            {
                Url = "https://www.blueletterbible.org/"
            };
            var blueLetterBibleWebCrawler = new SeleniumWebCrawler(blueLetterBibleWebDriver);
            var blueLetterBibleWebOperationPipeline = new WebOperationPipeline(blueLetterBibleWebCrawler);
            blueLetterBibleWebOperationPipeline.AddOperation(new SearchOperation("Love", Bible.Data.BibleTranslation.KJV));
            var jsonFileWriter = new JsonFileWriter();
            workflow
                .AddPipeline(blueLetterBibleWebOperationPipeline)
                .Execute()
                .OutputResults(jsonFileWriter);
        }
    }
}