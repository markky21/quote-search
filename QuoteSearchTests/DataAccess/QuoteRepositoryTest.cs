using System.Net;
using Moq;
using Moq.Protected;
using QuoteSearch.DataAccess;

namespace QuoteSearchTests.DataAccess;

[TestFixture]
[TestOf(typeof(QuoteRepository))]
public class QuoteRepositoryTest
{
    [SetUp]
    public void Setup()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    "{\"statusCode\":200,\"message\":\"\",\"pagination\":{\"currentPage\":1,\"nextPage\":2,\"totalPages\":10},\"totalQuotes\":100,\"data\":[{\"_id\":\"1\",\"quoteText\":\"Test Quote\",\"quoteAuthor\":\"Test Author\",\"quoteGenre\":\"Test Genre\",\"__v\":0}]}")
            });

        _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object);
        _quoteRepository = new QuoteRepository(_mockHttpClient);
    }

    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient _mockHttpClient;
    private QuoteRepository _quoteRepository;

    [Test]
    public async Task GetQuotes_ReturnsExpectedQuotes()
    {
        var quotesParams = new GetQuotesParams();
        var quotes = await _quoteRepository.GetQuotes(quotesParams);

        Assert.That(quotes.Count, Is.EqualTo(1));
        Assert.That(quotes[0].Id, Is.EqualTo("1"));
        Assert.That(quotes[0].QuoteText, Is.EqualTo("Test Quote"));
        Assert.That(quotes[0].QuoteAuthor, Is.EqualTo("Test Author"));
        Assert.That(quotes[0].QuoteGenre, Is.EqualTo("Test Genre"));
    }
}