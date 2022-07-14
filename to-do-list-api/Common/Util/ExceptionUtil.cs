namespace TodoList.Common.Util;

public class ExceptionUtil 
{
  public static T ThrowIfNull<T>(Object obj) where T : Exception, new()
  {
    if (obj == null) throw new T();
    return null;
  }

}