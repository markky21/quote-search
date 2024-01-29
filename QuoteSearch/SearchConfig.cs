namespace QuoteSearch;

public record SearchConfig(string SearchString, int SearchInPages, int QuotesPerPage, bool IsProcessingParallel);