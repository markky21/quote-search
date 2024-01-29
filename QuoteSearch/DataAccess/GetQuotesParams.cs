namespace QuoteSearch.DataAccess;

public record GetQuotesParams(string? Query = null, int? Page = null, int? Limit = null)
{
    public override string ToString()
    {
        var queryList = new List<string>();
        if (Query != null) queryList.Add($"query={Query}");
        if (Page != null) queryList.Add($"page={Page}");
        if (Limit != null) queryList.Add($"limit={Limit}");
        return string.Join('&', queryList);
    }
}