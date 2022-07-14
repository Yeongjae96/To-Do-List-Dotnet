using System.Reflection;

namespace TodoList.Common.Extensions;

public static class AttributeExtension
{
  public static T GetCustomAttribute<T>(this FieldInfo property) where T : Attribute
  {
    T result = null;
    foreach (var attribute in property.GetCustomAttributes())
    {
      result = attribute as T;
      if (result == null) continue;
      break;
    }

    return result;
  }
}