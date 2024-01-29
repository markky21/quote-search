using QuoteSearch.Models;

namespace QuoteSearch.Controller;

public static class QuoteInListFinder
{
    public static Datum? Find(IReadOnlyList<Datum> quotes, string searchWord)
    {
        var searchWordLower = searchWord.ToLower();
        return quotes
            .Where(datum => datum.QuoteText.ToLower().Contains(searchWordLower + " ") ||
                            datum.QuoteAuthor.ToLower().Contains(" " + searchWordLower))
            .MinBy(datum => datum.QuoteText.Length);
    }
}