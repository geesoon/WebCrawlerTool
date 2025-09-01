namespace Bible.Data
{
    public static class BibleBooksExtensions
    {
        private static readonly Dictionary<string, BibleBooks> AbbreviationsToEnum = new(StringComparer.OrdinalIgnoreCase)
            {
                // Old Testament Abbreviations
                {"Gen", BibleBooks.Genesis},
                {"Exo", BibleBooks.Exodus},
                {"Lev", BibleBooks.Leviticus},
                {"Num", BibleBooks.Numbers},
                {"Deu", BibleBooks.Deuteronomy},
                {"Jos", BibleBooks.Joshua},
                {"Judg", BibleBooks.Judges},
                {"Jdg", BibleBooks.Judges},
                {"Ruth", BibleBooks.Ruth},
                {"1Sam", BibleBooks.FirstSamuel},
                {"1Sa", BibleBooks.FirstSamuel},

                {"2Sam", BibleBooks.SecondSamuel},
                {"2Sa", BibleBooks.SecondSamuel},

                {"1Kgs", BibleBooks.FirstKings},
                {"1Ki", BibleBooks.FirstKings},

                {"2Kgs", BibleBooks.SecondKings},
                {"2Ki", BibleBooks.SecondKings},

                {"1Chr", BibleBooks.FirstChronicles},
                {"1Ch", BibleBooks.FirstChronicles},

                {"2Chr", BibleBooks.SecondChronicles},
                {"2Ch", BibleBooks.SecondChronicles},

                {"Ezr", BibleBooks.Ezra},
                {"Neh", BibleBooks.Nehemiah},
                {"Est", BibleBooks.Esther},
                {"Job", BibleBooks.Job},
                {"Psa", BibleBooks.Psalms},
                {"Pro", BibleBooks.Proverbs},
                {"Ecc", BibleBooks.Ecclesiastes},
                {"Song", BibleBooks.SongOfSolomon},
                {"Isa", BibleBooks.Isaiah},
                {"Jer", BibleBooks.Jeremiah},
                {"Lam", BibleBooks.Lamentations},
                {"Eze", BibleBooks.Ezekiel},
                {"Dan", BibleBooks.Daniel},
                {"Hos", BibleBooks.Hosea},
                {"Joel", BibleBooks.Joel},
                {"Amos", BibleBooks.Amos},
                {"Obad", BibleBooks.Obadiah},
                {"Jonah", BibleBooks.Jonah},
                {"Mic", BibleBooks.Micah},
                {"Nah", BibleBooks.Nahum},
                {"Hab", BibleBooks.Habakkuk},
                {"Zeph", BibleBooks.Zephaniah},
                {"Hag", BibleBooks.Haggai},
                {"Zech", BibleBooks.Zechariah},
                {"Mal", BibleBooks.Malachi},

                // New Testament Abbreviations
                {"Matt", BibleBooks.Matthew},
                {"Mark", BibleBooks.Mark},
                {"Luke", BibleBooks.Luke},
                {"John", BibleBooks.John},
                {"Jhn", BibleBooks.John},

                { "Acts", BibleBooks.Acts},
                {"Act", BibleBooks.Acts},
                {"Rom", BibleBooks.Romans},
                {"1Co", BibleBooks.FirstCorinthians},
                {"1Cor", BibleBooks.FirstCorinthians},
                {"2Co", BibleBooks.SecondCorinthians},
                {"2Cor", BibleBooks.SecondCorinthians},

                { "Gal", BibleBooks.Galatians},
                {"Eph", BibleBooks.Ephesians},
                {"Phil", BibleBooks.Philippians},
                {"Phl", BibleBooks.Philippians},

                { "Col", BibleBooks.Colossians},
                {"1Thess", BibleBooks.FirstThessalonians},
                {"1Th", BibleBooks.FirstThessalonians},

                { "2Thess", BibleBooks.SecondThessalonians},
                {"2Th", BibleBooks.SecondThessalonians},

                { "1Tim", BibleBooks.FirstTimothy},
                { "1Ti", BibleBooks.FirstTimothy},

                { "2Tim", BibleBooks.SecondTimothy},
                { "2Ti", BibleBooks.SecondTimothy},

                { "Titus", BibleBooks.Titus},
                {"Phm", BibleBooks.Philemon},

                { "Heb", BibleBooks.Hebrews},
                {"Jas", BibleBooks.James},
                {"1Pet", BibleBooks.FirstPeter},
                {"2Pet", BibleBooks.SecondPeter},
                {"1John", BibleBooks.FirstJohn},
                {"1Jo", BibleBooks.FirstJohn},

                { "2John", BibleBooks.SecondJohn},
                { "2Jo", BibleBooks.SecondJohn},

                { "3John", BibleBooks.ThirdJohn},
                {"Jude", BibleBooks.Jude},
                {"Rev", BibleBooks.Revelation}
            };

        public static BibleBooks GetEnumFromAbbreviation(this string abbreviation)
        {
            if (AbbreviationsToEnum.TryGetValue(abbreviation, out BibleBooks result))
                return result;
            throw new ArgumentException($"No enum value found for abbreviation '{abbreviation}'.", nameof(abbreviation));
        }
    }
}