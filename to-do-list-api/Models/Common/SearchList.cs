using TodoList.Common.Base;
using TodoList.Common.Interface;

namespace TodoList.Models.Common;
public class SearchList<T> : IPaginable
{
  public SearchList() { }
  public IEnumerable<T> List { get; set; }
  public PaginationInfo Pagination { get; set; }
}