using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuoteSearch.Models;

public record QuotesResponse(
    [property: JsonProperty("statusCode")]
    [property: JsonPropertyName("statusCode")]
    int StatusCode,
    [property: JsonProperty("message")]
    [property: JsonPropertyName("message")]
    string Message,
    [property: JsonProperty("pagination")]
    [property: JsonPropertyName("pagination")]
    Pagination Pagination,
    [property: JsonProperty("totalQuotes")]
    [property: JsonPropertyName("totalQuotes")]
    int TotalQuotes,
    [property: JsonProperty("data")]
    [property: JsonPropertyName("data")]
    IReadOnlyList<Datum> Data
);