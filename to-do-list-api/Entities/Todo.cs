namespace TodoList.Entities;

public class Todo : Entity 
{
  /// <summary>
  /// 기본키
  /// </summary>
  public long No { get; set; }
  public string Title { get; set; } = null!;
  public DateOnly? RegDate { get; set; }
  public string Content { get; set; }
}