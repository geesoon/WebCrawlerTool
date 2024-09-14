using System.ComponentModel;

namespace Bible.Data
{
    public enum BibleBooks
    {
        // Old Testament
        [Description("Genesis")]
        Genesis,
        [Description("Exodus")]
        Exodus,
        [Description("Leviticus")]
        Leviticus,
        [Description("Numbers")]
        Numbers,
        [Description("Deuteronomy")]
        Deuteronomy,
        [Description("Joshua")]
        Joshua,
        [Description("Judges")]
        Judges,
        [Description("Ruth")]
        Ruth,
        [Description("1 Samuel")]
        FirstSamuel,
        [Description("2 Samuel")]
        SecondSamuel,
        [Description("1 Kings")]
        FirstKings,
        [Description("2 Kings")]
        SecondKings,
        [Description("1 Chronicles")]
        FirstChronicles,
        [Description("2 Chronicles")]
        SecondChronicles,
        [Description("Ezra")]
        Ezra,
        [Description("Nehemiah")]
        Nehemiah,
        [Description("Esther")]
        Esther,
        [Description("Job")]
        Job,
        [Description("Psalms")]
        Psalms,
        [Description("Proverbs")]
        Proverbs,
        [Description("Ecclesiastes")]
        Ecclesiastes,
        [Description("Song of Solomon")]
        SongOfSolomon,
        [Description("Isaiah")]
        Isaiah,
        [Description("Jeremiah")]
        Jeremiah,
        [Description("Lamentations")]
        Lamentations,
        [Description("Ezekiel")]
        Ezekiel,
        [Description("Daniel")]
        Daniel,
        [Description("Hosea")]
        Hosea,
        [Description("Joel")]
        Joel,
        [Description("Amos")]
        Amos,
        [Description("Obadiah")]
        Obadiah,
        [Description("Jonah")]
        Jonah,
        [Description("Micah")]
        Micah,
        [Description("Nahum")]
        Nahum,
        [Description("Habakkuk")]
        Habakkuk,
        [Description("Zephaniah")]
        Zephaniah,
        [Description("Haggai")]
        Haggai,
        [Description("Zechariah")]
        Zechariah,
        [Description("Malachi")]
        Malachi,

        // New Testament
        [Description("Matthew")]
        Matthew,
        [Description("Mark")]
        Mark,
        [Description("Luke")]
        Luke,
        [Description("John")]
        John,
        [Description("Acts")]
        Acts,
        [Description("Romans")]
        Romans,
        [Description("1 Corinthians")]
        FirstCorinthians,
        [Description("2 Corinthians")]
        SecondCorinthians,
        [Description("Galatians")]
        Galatians,
        [Description("Ephesians")]
        Ephesians,
        [Description("Philippians")]
        Philippians,
        [Description("Colossians")]
        Colossians,
        [Description("1 Thessalonians")]
        FirstThessalonians,
        [Description("2 Thessalonians")]
        SecondThessalonians,
        [Description("1 Timothy")]
        FirstTimothy,
        [Description("2 Timothy")]
        SecondTimothy,
        [Description("Titus")]
        Titus,
        [Description("Philemon")]
        Philemon,
        [Description("Hebrews")]
        Hebrews,
        [Description("James")]
        James,
        [Description("1 Peter")]
        FirstPeter,
        [Description("2 Peter")]
        SecondPeter,
        [Description("1 John")]
        FirstJohn,
        [Description("2 John")]
        SecondJohn,
        [Description("3 John")]
        ThirdJohn,
        [Description("Jude")]
        Jude,
        [Description("Revelation")]
        Revelation,
    }

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
            {"Acts", BibleBooks.Acts},
            {"Rom", BibleBooks.Romans},
            {"1Cor", BibleBooks.FirstCorinthians},
            {"2Cor", BibleBooks.SecondCorinthians},
            {"Gal", BibleBooks.Galatians},
            {"Eph", BibleBooks.Ephesians},
            {"Phil", BibleBooks.Philippians},
            {"Col", BibleBooks.Colossians},
            {"1Thess", BibleBooks.FirstThessalonians},
            {"2Thess", BibleBooks.SecondThessalonians},
            {"1Tim", BibleBooks.FirstTimothy},
            {"2Tim", BibleBooks.SecondTimothy},
            {"Titus", BibleBooks.Titus},
            {"Phm", BibleBooks.Philemon},
            {"Heb", BibleBooks.Hebrews},
            {"Jas", BibleBooks.James},
            {"1Pet", BibleBooks.FirstPeter},
            {"2Pet", BibleBooks.SecondPeter},
            {"1John", BibleBooks.FirstJohn},
            {"2John", BibleBooks.SecondJohn},
            {"3John", BibleBooks.ThirdJohn},
            {"Jude", BibleBooks.Jude},
            {"Rev", BibleBooks.Revelation}
        };

        public static BibleBooks GetEnumFromAbbreviation(string abbreviation)
        {
            if (AbbreviationsToEnum.TryGetValue(abbreviation, out BibleBooks result))
                return result;
            throw new ArgumentException($"No enum value found for abbreviation '{abbreviation}'.", nameof(abbreviation));
        }
    }
}