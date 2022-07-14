using Microsoft.EntityFrameworkCore;
using TodoList.Common.Extensions;
using TodoList.Common.Interface;
using TodoList.Common.Util;
using TodoList.Contexts.Todo;
using TodoList.Models.Request;
using TodoList.Models.Todo;

namespace TodoList.Services.Todo;
public class TodoService
{
  public readonly TodoContext _context;

  public TodoService(TodoContext context) 
  {
    _context = context;
  }

  public async Task<IEnumerable<TodoItem>> GetTodos<T>(SearchParam<T> searchParam) 
  {
    var result = await _context.TodoSet.ToListAsync();

    result.ForEach(item => {
      var originRegDate = item.RegDate.Value;
      item.RegDate = originRegDate.ToTimeZone(TimeZoneId.Korea);
    });

    return result;
  }
  
  public async Task<TodoItem> GetTodo(int? no) 
  {
    var result = await _context.TodoSet.FirstOrDefaultAsync(x => x.No == no);
    ExceptionUtil.ThrowIfNull<KeyNotFoundException>(result);

    return result;
  }

  public async Task<TodoItem> InsertTodo(TodoItem todoItem)
  {
    _context.TodoSet.Add(todoItem);
    await _context.SaveChangesAsync();
    
    return todoItem;
  }

  public async Task<int> UpdateTodo(TodoItem todoItem)
  {
    var originTodo = await _context.TodoSet.FirstOrDefaultAsync(x => x.No == todoItem.No);
    ExceptionUtil.ThrowIfNull<KeyNotFoundException>(originTodo);

    originTodo.Title = todoItem.Title;
    originTodo.Content = todoItem.Content;

    _context.TodoSet.Update(originTodo);
    return await _context.SaveChangesAsync();
  }

  public async Task<int> DeleteTodo(int? no)
  {
    var removeTodo = await _context.TodoSet.FirstOrDefaultAsync(x => x.No == no);
    ExceptionUtil.ThrowIfNull<KeyNotFoundException>(removeTodo);

    _context.TodoSet.Remove(removeTodo);
    return await _context.SaveChangesAsync();
  }

  public async Task<TodoItem> UpdateCompleted(TodoItem item)
  {
    var updateTodo = await _context.TodoSet.FirstOrDefaultAsync(x => x.No == item.No);
    ExceptionUtil.ThrowIfNull<KeyNotFoundException>(updateTodo);

    updateTodo.Completed = item.Completed;
    await _context.SaveChangesAsync();
    return updateTodo;
  }
}