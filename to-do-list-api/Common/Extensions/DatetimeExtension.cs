using System;
using TodoList.Common.Util;

namespace TodoList.Common.Extensions;

public static class DatetimeExtension
{
  public static string ToDateOnly(this DateTime dateTime)
  {
    return dateTime.ToString("yyyy-MM-dd");
  }

  public static DateTime ToTimeZone(this DateTime dateTime, TimeZoneId TimeZoneId)
  {
    var enumDescAttribute = typeof (TimeZoneId).GetField(TimeZoneId.ToString()).GetCustomAttribute<EnumDescAttribute>();
    ExceptionUtil.ThrowIfNull<KeyNotFoundException>(enumDescAttribute);

    var toTimeZone = TimeZoneInfo.FindSystemTimeZoneById(enumDescAttribute.Value);
    return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, toTimeZone);
  }
}

public enum TimeZoneId 
{
  [EnumDescAttribute("Korea Standard Time")]
  Korea
}