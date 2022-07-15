namespace TrelloRestPlayground.Authorization;

public class TrelloAuthorizer
{
    public string GetToken()
    {
        var filePath = Path.Combine(".", "token.txt");
        return File.ReadAllLines(filePath).First();
    }

    public string GetKey()
    {
        var filePath = Path.Combine(".", "key.txt");
        return File.ReadAllLines(filePath).First();
    }
}
