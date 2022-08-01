namespace TodoList.Models.Request;

public class FilterList : List<FilterCondition> { }

public class FilterCondition
{
  public string PropertyName { get; set; }
  public string Value { get; set; }
  public string Operator { get; set; }
}
