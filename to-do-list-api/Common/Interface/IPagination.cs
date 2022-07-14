using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Common.Interface;

public interface IPagination<T>
{
  public PaginationInfo GetPagination(SearchParam<T> searchParam);
}