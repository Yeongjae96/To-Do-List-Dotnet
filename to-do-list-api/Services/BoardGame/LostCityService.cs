using TodoList.Common.Extensions;
using TodoList.Contexts.BoardGame;
using TodoList.Models.BoardGame;
using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Services.BoardGame;

public class LostCityService
{
  public readonly LostCityContext _context;
  public LostCityService(LostCityContext context) { _context = context; }

  // public async Task<SearchList<BoardGameHistory>> GetHistoryList(SearchParam<BoardGameHistory> searchParam)
  // {
  //   var result = await _context.BoardGameHistorySet.GetSearchList<BoardGameHistory>(searchParam);

  //   // 후처리 로직 


  //   return result;
  // }

  // public async Task<Boolean> CreateHistory(BoardGameHistory history)
  // {
  //   _context.BoardGameHistorySet.Add(history);
  //   return await _context.SaveChangesAsync() > 0;
  // }
}