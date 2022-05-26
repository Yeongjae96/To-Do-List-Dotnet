using TodoList.Context;
using TodoList.Entities;

namespace TodoList.Repositories;

public class TodoRepository : Repository<Todo>, ITodoRepository 
{
  public TodoRepository(ApplicationDbContext dbContext) : base(dbContext) {}

}