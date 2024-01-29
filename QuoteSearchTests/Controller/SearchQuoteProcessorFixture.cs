using QuoteSearch.Controller;

namespace QuoteSearchTests.Controller;

public static class SearchQuoteProcessorFixture
{
    public static ISearchQuoteProcessor Create()
    {
        return new SearchQuoteProcessor(SearchQuoteRequestProcessorFixture.Create());
    }
}