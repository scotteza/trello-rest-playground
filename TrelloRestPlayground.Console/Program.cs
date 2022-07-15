using TrelloRestPlayground.Api;

namespace TrelloRestPlayground
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var trelloApi = new TrelloApi();
            var boards = await trelloApi.FetchBoards();
        }
    }
}
