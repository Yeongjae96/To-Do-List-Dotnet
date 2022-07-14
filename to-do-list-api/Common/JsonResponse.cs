namespace TodoList.Common;

public class JsonResponse<T>
{
  public bool Success { get; set; }
  public string Message { get; set; }
  public T Data { get; set; }
}