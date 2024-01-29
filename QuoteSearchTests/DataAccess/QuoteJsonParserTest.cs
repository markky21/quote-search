using QuoteSearch.DataAccess;

namespace QuoteSearchTests.DataAccess;

[TestFixture]
[TestOf(typeof(QuoteJsonParser))]
public class QuoteJsonParserTest
{
    [Test]
    public void Parse_message_and_return_quotes_list()
    {
        var result = QuoteJsonParser.ParseQuotes(QuoteRepositoryFixture.QuotesSuccessResponse);
        Assert.That(result, Is.EqualTo(QuoteRepositoryFixture.Quotes));
    }
}