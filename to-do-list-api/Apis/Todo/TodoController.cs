using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Base;
using TodoList.Models.Request;
using TodoList.Models.Todo;
using TodoList.Services.Todo;
namespace TodoList.Apis.Todo;

[ApiController]
[Route("v1/[controller]")]
public class TodoController : YControllerBase
{
  private readonly TodoService _service;

  public TodoController(TodoService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> Get([FromBody] SearchParam<TodoItem> searchParam)
  {
    var result = await _service.GetTodos(searchParam);
    return OkJson(result);
  }

  [HttpGet]
  [Route("{no}")]
  public async Task<IActionResult> SelectOne(int? no)
  {
    var result = await _service.GetTodo(no);
    return OkJson(result);
  }

  [HttpPost]
  public async Task<IActionResult> Insert([FromBody]TodoItem item)
  {
    var result = await _service.InsertTodo(item);
    return OkJson(result);
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody]TodoItem item)
  {
    var result = await _service.UpdateTodo(item);
    return OkJson(result);
  }

  [HttpDelete]
  [Route("{no}")]
  public async Task<IActionResult> Delete(int? no)
  {
    var result = await _service.DeleteTodo(no);
    return OkJson(result);
  }

  [HttpPut]
  [Route("completed")]
  public async Task<IActionResult> UpdateCompleted([FromBody]TodoItem todoItem)
  {
    var result = await _service.UpdateCompleted(todoItem);
    return OkJson(result);
  }
}