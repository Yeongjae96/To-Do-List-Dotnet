using TodoList.DB;
using TodoList.Models.Todo;
using TodoList.Repositories;

namespace TodoList.Services;

public interface ITodoService
{
  public Task<int> CreateTodo(CreateTodoDTO createTodoDTO);
  public Task<int> DeleteTodo();
  
}

public class TodoService : ITodoService
{
  private readonly ITodoRepository _todoRepository;

  public TodoService(ITodoRepository dbContext) 
  {
    _todoRepository = dbContext;
  }

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      _todoRepository.Dispose(); 
    }
  }

  public void Dispose() 
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  public async Task<int> CreateTodo(CreateTodoDTO createTodoDTO)
  {
    _todoRepository.Create(createTodoDTO);
    return await _todoRepository.SaveChangesAsync();
  }

  public Task<int> DeleteTodo()
  {
    throw new NotImplementedException();
  }
}