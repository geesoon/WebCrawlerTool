using Bible.Data;
using EnsureThat;
using OpenQA.Selenium;
using WebCrawler.Core.Interface;
using WebCrawler.Core.Service;

namespace BlueLetterBibleCrawler.Operation
{
    public sealed class SearchOperation : WebOperationBase<List<BibleVerse>, string>
    {
        private readonly string SearchUrl = "https://www.blueletterbible.org/search/search.cfm";
        private readonly By By = By.CssSelector(".scriptureText");
        private readonly string Criteria;
        private readonly BibleTranslation Translation;

        public SearchOperation(string criteria, BibleTranslation translation)
        {
            this.Criteria = EnsureArg.IsNotNull(criteria, nameof(criteria));
            this.Translation = translation;
        }

        public override List<BibleVerse> Operate(IWebCrawler webCrawler, string context)
        {
            webCrawler.BrowseUrl($"{SearchUrl}?Criteria={Criteria}&t={Translation}");
            var allSearchResults = webCrawler.FindElements(By);

            IEnumerable<BibleVerse> bibleVerses = [];
            foreach (var element in allSearchResults)
            {
                var reference = ExtractReferenceFromElement(element);
                var verseText = RemoveReferenceFromVerseText(reference, element.Text);
                var bibleVerse = new BibleVerse(reference, verseText);
                bibleVerses = bibleVerses.Append(bibleVerse);
            }

            return bibleVerses.ToList();

            static string ExtractReferenceFromElement(IWebElement element)
            {
                return element
                    .FindElement(By.CssSelector("a"))
                    .GetAttribute("innerHTML");
            }

            static string RemoveReferenceFromVerseText(string reference, string verseText)
            {
                var stringToRemove = reference + " - ";
                int index = verseText.IndexOf(stringToRemove);
                if (index > -1)
                {
                    verseText = verseText.Remove(index, stringToRemove.Length);
                }
                return verseText;
            }
        }
    }
}