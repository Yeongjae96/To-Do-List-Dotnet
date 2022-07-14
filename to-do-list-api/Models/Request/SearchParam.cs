using TodoList.Models.Common;

namespace TodoList.Models.Request;

public class SearchParam<T>
{
  public int PageNo { get; set; }
  public int PageSize { get; set; }
  public int PageNumPerOnce { get; set; }
  public string SearchKeyword { get; set; }
  public T Data { get; set; }

  public PaginationInfo GetPaginationInfo()
  {
    return PaginationInfo.GetPagination(PageNo, 0, PageSize, PageNumPerOnce);
  }
}