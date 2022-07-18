using System.Collections.Concurrent;

namespace TodoList.Models.Request;

public class SortingList : List<SortCondition> { }

public class SortCondition
{
  public string PropertyName { get; set; }
  public SortDirection Direction { get; set; } = SortDirection.Ascending;
}

public enum SortDirection
{
  Ascending = 0,
  Descending = 1
}