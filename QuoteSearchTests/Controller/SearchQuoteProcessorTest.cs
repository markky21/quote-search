using QuoteSearch.Controller;

namespace QuoteSearchTests.Controller;

[TestFixture]
[TestOf(typeof(SearchQuoteProcessor))]
public class SearchQuoteProcessorTest
{
    [Test]
    public void Process_search_in_sequential_search()
    {
        var _searchQuoteRequestProcessor = SearchQuoteRequestProcessorFixture.Create();
        var _sut = new SearchQuoteProcessor(_searchQuoteRequestProcessor);
        var result = _sut.ProcessSequential(new SearchParams("Test", 3, 10));

        var expected = new SearchResult[]
        {
            new(true, "Test Quote"),
            new(true, "Test Quote"),
            new(true, "Test Quote")
        };
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public async Task Process_search_in_parrallel_search()
    {
        var _searchQuoteRequestProcessor = SearchQuoteRequestProcessorFixture.Create();
        var _sut = new SearchQuoteProcessor(_searchQuoteRequestProcessor);
        var result = await _sut.ProcessParallel(new SearchParams("Test", 3, 10));

        var expected = new SearchResult[]
        {
            new(true, "Test Quote"),
            new(true, "Test Quote"),
            new(true, "Test Quote")
        };
        CollectionAssert.AreEqual(expected, result);
    }
}