using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuoteSearch.Models;

public record Datum(
    [property: JsonProperty("_id")]
    [property: JsonPropertyName("_id")]
    string Id,
    [property: JsonProperty("quoteText")]
    [property: JsonPropertyName("quoteText")]
    string QuoteText,
    [property: JsonProperty("quoteAuthor")]
    [property: JsonPropertyName("quoteAuthor")]
    string QuoteAuthor,
    [property: JsonProperty("quoteGenre")]
    [property: JsonPropertyName("quoteGenre")]
    string QuoteGenre,
    [property: JsonProperty("__v")]
    [property: JsonPropertyName("__v")]
    int V
);