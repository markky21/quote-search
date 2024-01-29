using System.Net;
using Moq;
using Moq.Protected;
using QuoteSearch.DataAccess;
using QuoteSearch.Models;

namespace QuoteSearchTests.DataAccess;

public static class QuoteRepositoryFixture
{
    public static readonly string QuotesSuccessResponse =
        "{\"statusCode\":200,\"message\":\"\",\"pagination\":{\"currentPage\":1,\"nextPage\":2,\"totalPages\":10},\"totalQuotes\":100,\"data\":[{\"_id\":\"1\",\"quoteText\":\"Test Quote\",\"quoteAuthor\":\"Test Author\",\"quoteGenre\":\"Test Genre\",\"__v\":0}]}";

    public static readonly string QuotesMultipleRecordsSuccessResponse =
        "{\"statusCode\":200,\"message\":\"\",\"pagination\":{\"currentPage\":1,\"nextPage\":2,\"totalPages\":10},\"totalQuotes\":100,\"data\":[{\"_id\":\"1\",\"quoteText\":\"Test Quote\",\"quoteAuthor\":\"Test Author\",\"quoteGenre\":\"Test Genre\",\"__v\":0},{\"_id\":\"2\",\"quoteText\":\"Test Quote2\",\"quoteAuthor\":\"Test Author2\",\"quoteGenre\":\"Test Genre2\",\"__v\":0}]}";

    public static readonly List<Datum> Quotes =
    [
        new Datum("1",
            "Test Quote",
            "Test Author",
            "Test Genre",
            0)
    ];

    public static readonly List<Datum> QuotesMultiple =
    [
        new Datum("1",
            "Test Quote",
            "Test Author",
            "Test Genre",
            0),
        new Datum("2",
            "Test Quote2",
            "Test Author2",
            "Test Genre2",
            0)
    ];

    private static Mock<HttpMessageHandler> MockHttpMessageHandlerSuccess()
    {
        return MockHttpMessageHandlerSuccess(QuotesSuccessResponse);
    }

    private static Mock<HttpMessageHandler> MockHttpMessageHandlerSuccess(string response)
    {
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(response)
            });
        return mockHttpMessageHandler;
    }

    public static QuoteRepository Create()
    {
        return new QuoteRepository(new HttpClient(MockHttpMessageHandlerSuccess().Object));
    }

    public static QuoteRepository Create(string response)
    {
        return new QuoteRepository(new HttpClient(MockHttpMessageHandlerSuccess(response).Object));
    }
}