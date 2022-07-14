using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.Todo;

public class CreateTodoDTO
{
  [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
  public string Title { get; set; }
  public int Priority { get; set; }
  public string Flag { get; set; }
  // public DateTime RegDate { get; set; }
}