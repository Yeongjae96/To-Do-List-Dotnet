using Microsoft.EntityFrameworkCore;
using TodoList.Common.Interface;
using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Common.Extensions;

public static class DatabaseExtension 
{
  public async static Task<IEnumerable<T>> GetSearchList<T>(this DbSet<T> dbSet, SearchParam<T> searchParam) where T : class
  {
    if (searchParam.PageNo <= 0) searchParam.PageNo = 1;

    var pInfo = searchParam.GetPaginationInfo();

    // if (searchParam)
    return await dbSet
      .Skip(pInfo.PageNo * pInfo.PageSize)
      .Take(pInfo.PageSize)
      .ToListAsync();
  }
}