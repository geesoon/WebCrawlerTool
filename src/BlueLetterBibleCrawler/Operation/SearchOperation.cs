using Bible.Data;
using EnsureThat;
using OpenQA.Selenium;
using WebCrawler.Core.Interface;
using WebCrawler.Core.Service;

namespace BlueLetterBibleCrawler.Operation
{
    public sealed class SearchOperation : WebOperation<List<BibleVerse>, string>
    {
        private readonly string searchUrl = "https://www.blueletterbible.org/search/search.cfm";
        private readonly By By = By.CssSelector(".scriptureText");
        private readonly string criteria;
        private readonly string bibleTranslation;

        public SearchOperation(
            string criteria,
            string translation)
        {
            this.criteria = EnsureArg.IsNotNullOrWhiteSpace(criteria, nameof(criteria));
            this.bibleTranslation = EnsureArg.IsNotNullOrWhiteSpace(translation, nameof(translation));
        }

        protected override List<BibleVerse> Operate(IWebCrawler webCrawler, string context)
        {
            var url = $"{this.searchUrl}?Criteria={this.criteria}&t={this.bibleTranslation}";
            webCrawler.BrowseUrl(url);
            var allSearchResults = webCrawler.FindElements(By);

            IEnumerable<BibleVerse> bibleVerses = [];
            foreach (var element in allSearchResults)
            {
                var reference = ExtractReferenceFromElement(element);
                var verseText = RemoveReferenceFromVerseText(reference, element.Text);
                var bibleVerse = new BibleVerse(reference, verseText);
                bibleVerses = bibleVerses.Append(bibleVerse);
            }

            return [.. bibleVerses];

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