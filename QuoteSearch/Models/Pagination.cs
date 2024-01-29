using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuoteSearch.Models;

public record Pagination(
    [property: JsonProperty("currentPage")]
    [property: JsonPropertyName("currentPage")]
    int CurrentPage,
    [property: JsonProperty("nextPage")]
    [property: JsonPropertyName("nextPage")]
    int NextPage,
    [property: JsonProperty("totalPages")]
    [property: JsonPropertyName("totalPages")]
    int TotalPages
);