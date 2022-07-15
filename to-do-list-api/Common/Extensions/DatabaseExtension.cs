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

    var pInfo = searchParam.Pagination;
    pInfo.TotalCnt = await dbSet.CountAsync();

    var queryable = dbSet.AsQueryable();

    if (searchParam.SortConditions != null && searchParam.SortConditions.Count > 0)
    {
      bool first = true;
      foreach (var sortCondition in searchParam.SortConditions)
      {
        queryable = queryable.OrderBy(sortCondition.PropertyName, sortCondition.Direction, !first);
        if (first) first = false;
      }
    }

    var result = new SearchList<T>()
    {
      List = await queryable
      // .OrderBy("Completed", SortDirection.Ascending)
      // .OrderBy("RegDate", SortDirection.Ascending, true)
      .Skip(pInfo.SkipCount)
      .Take(pInfo.PageSize)
      .ToListAsync(),
      Pagination = pInfo
    };
    // if (searchParam)
    return result;
  }

  public static IOrderedQueryable<T> OrderBy<T> (this IQueryable<T> source, string propertyName, SortDirection descending, bool anotherLevel = false)
  {
    var param = Expression.Parameter(typeof (T), string.Empty);
    var property = Expression.PropertyOrField(param, propertyName);
    var sort = Expression.Lambda(property, param);

    var call = Expression.Call(
      typeof (Queryable),
      (!anotherLevel ? "OrderBy" : "ThenBy") +
      (descending == SortDirection.Descending ? "Descending" : String.Empty),
      new[] { typeof (T), property.Type},
      source.Expression,
      Expression.Quote(sort)
    );

    return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
  }
}