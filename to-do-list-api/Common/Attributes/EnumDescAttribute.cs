[AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
public class EnumDescAttribute : Attribute
{
  public EnumDescAttribute(string value)
  {
    Value = value;
  }

  public string Value { get; set; }
}