using QuoteSearch.Controller;
using QuoteSearchTests.DataAccess;

namespace QuoteSearchTests.Controller;

[TestFixture]
[TestOf(typeof(SearchQuoteRequestProcessor))]
public class SearchQuoteRequestProcessorTest
{
    [SetUp]
    public void SetUp()
    {
        _sut = new SearchQuoteRequestProcessor(QuoteRepositoryFixture.Create());
    }

    private SearchQuoteRequestProcessor _sut;

    [Test]
    public async Task Process_search_quote_request_with_no_success()
    {
        var result = await _sut.Process(new SearchParams("sea", 5, 10));

        Assert.That(result, Is.EqualTo(new SearchResult(false, "No quotes found")));
    }

    [Test]
    public async Task Process_search_quote_request_with_success()
    {
        var result = await _sut.Process(new SearchParams("Test", 5, 10));

        Assert.That(result, Is.EqualTo(new SearchResult(true, "Test Quote")));
    }
}