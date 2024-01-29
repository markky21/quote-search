namespace QuoteSearch.View;

public interface IUserInteractor
{
    void Print(string message);
    string ReadString();
    int ReadInt();
    bool ReadBool();
}