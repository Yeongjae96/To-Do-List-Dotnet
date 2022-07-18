using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Common.Interface;
using TodoList.Models.Common;

namespace TodoList.Models.Request;

public class SearchParam<T> : IPaginable
{
  public int PageNo { get; set; }
  public int PageSize { get; set; }
  public int PageNumPerOnce { get; set; }
  public string SearchKeyword { get; set; }

  [FromQuery(Name="sortCondition")]
  public SortingList SortCondition { get; set; }

  public T Data { get; set; }

  public PaginationInfo Pagination { get => PaginationInfo.GetPagination(PageNo, 0, PageSize, PageNumPerOnce); }

}