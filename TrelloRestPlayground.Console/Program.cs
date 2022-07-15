using TrelloRestPlayground.Api.Boards;
using TrelloRestPlayground.Api.Lists;

namespace TrelloRestPlayground.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var boardId = await GetBoardId();
            var lists = await GetLists(boardId);
        }

        private static async Task<string?> GetBoardId()
        {
            var boards = await new TrelloBoardFetcher().FetchBoards();
            var board = boards!.First(x => x.Name!.Equals("Testing Trello API"));
            var boardId = board.Id;
            return boardId;
        }

        private static async Task<IEnumerable<TrelloList>?> GetLists(string? boardId)
        {
            var lists = await new TrelloListFetcher().FetchLists(boardId);
            return lists;
        }
    }
}
