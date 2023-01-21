using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Extensions;
using TodoList.Contexts.BoardGame;
using TodoList.Models.BoardGame;
using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Services.BoardGame;

public class BoardGameHistoryService
{

  public readonly BoardGameHistoryContext _context;

  public BoardGameHistoryService(BoardGameHistoryContext context)
  {
    _context = context;
  }

  public async Task<Boolean> CreateHistory(BoardGameHistory history)
  {
    _context.BoardGameHistorySet.Add(history);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<SearchList<BoardGameHistory>> GetBoardGameHistoryList(SearchParam<BoardGameHistory> searchParam)
  {
    var result = await _context.BoardGameHistorySet.GetSearchList<BoardGameHistory>(searchParam);

    // 후처리
    result.List.ForEach(item =>
    {
      item.CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToTimeZone(TimeZoneId.Korea) : item.CreateDate;
    });

    return result;
  }

}