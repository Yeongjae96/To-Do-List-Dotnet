namespace TodoList.Common.Extensions;

public static class CollectionExtension
{
  public static void ForEach<T>(this IEnumerable<T> enumerator, Action<T> action)
  {
    foreach (var target in enumerator)
    {
      action.Invoke(target);
    }
  }
}