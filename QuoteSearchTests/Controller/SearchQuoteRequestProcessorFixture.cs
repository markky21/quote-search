using QuoteSearch.Controller;
using QuoteSearchTests.DataAccess;

namespace QuoteSearchTests.Controller;

public static class SearchQuoteRequestProcessorFixture
{
    public static ISearchQuoteRequestProcessor Create()
    {
        return new SearchQuoteRequestProcessor(QuoteRepositoryFixture.Create());
    }
}