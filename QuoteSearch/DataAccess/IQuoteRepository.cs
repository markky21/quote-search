using QuoteSearch.Models;

namespace QuoteSearch.DataAccess;

public interface IQuoteRepository
{
    Task<IReadOnlyList<Datum>> GetQuotes(GetQuotesParams quotesParams);
}