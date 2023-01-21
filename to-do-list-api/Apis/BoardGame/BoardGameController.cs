namespace TodoList.Apis.BoardGame;

using Microsoft.AspNetCore.Mvc;
using TodoList.Common;
using TodoList.Common.Base;
using TodoList.Models.BoardGame;
using TodoList.Models.Common;
using TodoList.Models.Request;
using TodoList.Services.BoardGame;

[ApiController]
[Route("v1/[controller]")]
public class BoardGameController : YControllerBase
{
  public readonly BoardGameHistoryService _service;

  public BoardGameController(BoardGameHistoryService service)
  {
    _service = service;
  }

  [HttpPost]
  [Route("history")]
  public async Task<IActionResult> CreateHistory([FromBody] BoardGameHistory history)
  {
    var result = await _service.CreateHistory(history);
    return OkJson<Boolean>(result);
  }

  [HttpGet]
  [Route("history")]
  public async Task<IActionResult> GetHistoryList([FromQuery] SearchParam<BoardGameHistory> searchParam)
  {
    var result = await _service.GetBoardGameHistoryList(searchParam);
    return OkJson<SearchList<BoardGameHistory>>(result);
  }
}