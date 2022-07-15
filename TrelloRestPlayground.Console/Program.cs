using TrelloRestPlayground.Api.Boards;
using TrelloRestPlayground.Api.Cards;
using TrelloRestPlayground.Api.Lists;

namespace TrelloRestPlayground.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var boardId = await GetBoardId();
            var listId = await GetLists(boardId);
            var cardId = await GetCardsInList(listId);
        }

        private static async Task<string?> GetBoardId()
        {
            var boards = await new TrelloBoardFetcher().FetchBoards();
            var board = boards!.First(x => x.Name!.Equals("Testing Trello API"));
            var boardId = board.Id;
            return boardId;
        }

        private static async Task<string> GetLists(string? boardId)
        {
            var lists = await new TrelloListFetcher().FetchListsForBoard(boardId);
            var list = lists!.First(x => x.Name!.Equals("AAAAA"));
            var listId = list.Id;
            return listId!;
        }

        private static async Task<string> GetCardsInList(string? listId)
        {
            var cards = await new TrelloCardFetcher().FetchCardsForList(listId);
            var card = cards!.First();
            var cardId = card.Id;
            return cardId!;
        }
    }
}
