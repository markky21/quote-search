namespace QuoteSearch.View;

public class UserSearchRequestGenerator(IUserInteractor userInteractor) : IUserSearchRequestGenerator
{
    private readonly IUserInteractor _userInteractor = userInteractor;

    public SearchConfig AskUserForSearchConfiguration()
    {
        _userInteractor.Print("Enter a word to search:");
        var searchString = _userInteractor.ReadString();

        _userInteractor.Print("How many pages use for search?");
        var searchInPages = _userInteractor.ReadInt();

        _userInteractor.Print("How many quotes should be in pages?");
        var quotesPerPage = _userInteractor.ReadInt();

        _userInteractor.Print("Should processing of the downloaded data be performed in parallel?");
        var isProcessingParallel = _userInteractor.ReadBool();

        return new SearchConfig(searchString, searchInPages, quotesPerPage, isProcessingParallel);
    }
}