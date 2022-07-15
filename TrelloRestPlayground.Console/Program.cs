using TrelloRestPlayground.Api.Boards;

namespace TrelloRestPlayground.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var boardId = await GetBoardId();
        }

        private static async Task<string?> GetBoardId()
        {
            var boards = await new BoardFetcher().FetchBoards();
            var board = boards!.First(x => x.Name!.Equals("Testing Trello API"));
            var boardId = board.Id;
            return boardId;
        }
    }
}
