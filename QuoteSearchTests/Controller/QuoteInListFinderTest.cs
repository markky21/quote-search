using QuoteSearch.Controller;
using QuoteSearch.Models;
using QuoteSearchTests.DataAccess;

namespace QuoteSearchTests.Controller;

[TestFixture]
[TestOf(typeof(QuoteInListFinder))]
public class QuoteInListFinderTest
{
    [Test]
    public void Find_datum_by_given_word()
    {
        var result = QuoteInListFinder.Find(QuoteRepositoryFixture.QuotesMultiple, "Test");

        Assert.That(result, Is.EqualTo(QuoteRepositoryFixture.QuotesMultiple[0]));
    }

    [Test]
    public void Search_by_whole_word()
    {
        var result = QuoteInListFinder.Find(QuoteRepositoryFixture.QuotesMultiple, "Te");

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Search_is_case_unsensitive()
    {
        var result = QuoteInListFinder.Find(QuoteRepositoryFixture.QuotesMultiple, "test");

        Assert.That(result, Is.EqualTo(QuoteRepositoryFixture.QuotesMultiple[0]));
    }

    [TestCaseSource(nameof(DifferentOrderedQuotes))]
    public void Takes_shortest_matching_quote(IEnumerable<Datum> quotes)
    {
        var result = QuoteInListFinder.Find(quotes.ToList(), "test");

        Assert.That(result.QuoteText, Is.EqualTo("Test Quote"));
    }

    public static object[] DifferentOrderedQuotes
    {
        get
        {
            var reverseQuotes = new List<Datum>(QuoteRepositoryFixture.QuotesMultiple);
            reverseQuotes.Reverse();
            return new object[]
            {
                QuoteRepositoryFixture.QuotesMultiple,
                reverseQuotes
            };
        }
    }
}