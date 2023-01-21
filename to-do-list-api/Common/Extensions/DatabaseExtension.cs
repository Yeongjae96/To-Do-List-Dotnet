using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Common.Base;
using TodoList.Common.Interface;
using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Common.Extensions;

public static class DatabaseExtension
{
  public async static Task<SearchList<T>> GetSearchList<T>(this DbSet<T> dbSet, SearchParam<T> searchParam) where T : class
  {
    if (searchParam.PageNo <= 0) searchParam.PageNo = 1;

    var pInfo = PaginationInfo.GetPagination(searchParam);

    var totalCnt = await dbSet.CountAsync();

    if (totalCnt == 0)
    {
      var empty = SearchList<T>.Empty;
      empty.Pagination = pInfo;
      return empty;
    }

    pInfo.TotalCnt = totalCnt;

    var queryable = dbSet.AsQueryable();


    // 대상 정렬
    if (searchParam.SortCondition != null && searchParam.SortCondition.Count > 0)
    {
      bool first = true;
      foreach (var sortCondition in searchParam.SortCondition)
      {
        queryable = queryable.OrderBy(sortCondition.PropertyName, sortCondition.Direction, !first);
        if (first) first = false;
      }
    }

    // 대상 필터링 (아직 미구현)
    if (searchParam.FilterCondition != null && searchParam.SortCondition.Count > 0)
    {
      foreach (var filterCondition in searchParam.FilterCondition)
      {
        queryable = queryable.Where(filterCondition.PropertyName, filterCondition.Value, filterCondition.Operator);
      }
    }
    // 목록조회
    var list = await queryable
      .Skip(pInfo.getSkipCount())
      .Take(pInfo.PageSize)
      .ToListAsync();

    // 페이징
    var result = new SearchList<T>()
    {
      List = list,
      Pagination = pInfo
    };

    return result;
  }

  public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, SortDirection descending, bool anotherLevel = false)
  {
    var param = Expression.Parameter(typeof(T), string.Empty);
    var property = Expression.PropertyOrField(param, propertyName);
    var sort = Expression.Lambda(property, param);

    var call = Expression.Call(
      typeof(Queryable),
      (!anotherLevel ? "OrderBy" : "ThenBy") +
      (descending == SortDirection.Descending ? "Descending" : String.Empty),
      new[] { typeof(T), property.Type },
      source.Expression,
      Expression.Quote(sort)
    );

    // ESSO로그인 시 웹메일, 
    return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
  }

  public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, string op)
  {
    var param = Expression.Parameter(typeof(T), value);
    var property = Expression.PropertyOrField(param, propertyName);
    var lambda = Expression.Lambda(property, param);

    var call = Expression.Call(
      typeof(Queryable),
      "Where",
      new[] { typeof(T), property.Type },
      source.Expression,
      Expression.Quote(lambda)
    );

    return (IQueryable<T>)source.Provider.CreateQuery<T>(call);
  }
}