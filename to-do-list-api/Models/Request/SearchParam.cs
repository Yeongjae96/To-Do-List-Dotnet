using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Interface;
using TodoList.Models.Common;

namespace TodoList.Models.Request;

public class SearchParam<T>
{
  public int PageNo { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public int PageNumPerOnce { get; set; } = 10;
  public string SearchKeyword { get; set; }

  [FromQuery(Name = "sortCondition")]
  public SortingList SortCondition { get; set; }

  [FromQuery(Name = "filterCondition")]
  public FilterList FilterCondition { get; set; }

  // public T Data { get; set; }

  // public PaginationInfo Pagination { get => PaginationInfo.GetPagination(PageNo, 0, PageSize, PageNumPerOnce); }
}