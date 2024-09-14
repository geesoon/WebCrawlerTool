using Bible.Data;
using EnsureThat;
using OpenQA.Selenium;
using WebCrawler.Core.Interface;
using WebCrawler.Core.Service;

namespace BlueLetterBibleCrawler.Operations
{
    public sealed class SearchOperation : WebOperationBase<IEnumerable<BibleVerse>, string>
    {
        private readonly string SearchUrl = "https://www.blueletterbible.org/search/search.cfm";
        private readonly By By = By.CssSelector(".scriptureText");
        private readonly string Criteria;
        private readonly BibleTranslation Translation;

        public SearchOperation(string criteria, BibleTranslation translation)
        {
            Criteria = EnsureArg.IsNotNull(criteria, nameof(criteria));
            Translation = translation;
        }

        public override IEnumerable<BibleVerse> Operate(IWebCrawler webCrawler, string context)
        {
            webCrawler.BrowseUrl($"{SearchUrl}?Criteria={Criteria}&t={Translation}");
            var result = webCrawler
                .FindElements(By)
                .ToList();

            IEnumerable<BibleVerse> bibleVerses = [];
            foreach (var element in result)
            {
                var reference = element.FindElement(By.TagName("a")).Text;
                var text = element.Text;

                // Removing the verseReference from scriptureText
                var stringToRemove = reference + " - ";
                int index = text.IndexOf(stringToRemove);
                if (index > -1)
                {
                    text = text.Remove(index, stringToRemove.Length);
                }
                try
                {
                    bibleVerses = bibleVerses.Append(new BibleVerse(reference, text));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{reference}, {ex.ToString()}");
                }
            }
            return bibleVerses;
        }
    }
}