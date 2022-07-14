using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Common.Database;
using TodoList.Common.Extensions;
using TodoList.Common.Interface;
using TodoList.Models.Common;
using TodoList.Models.Request;

namespace TodoList.Models.Todo;

[Table("tb_todo")]
public class TodoItem
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int? No { get; set; }
  public string Title { get; set; }
  [Column("reg_date", TypeName = "Datetime")]
  [SqlDefaultValue(DefaultValue = "curdate()")]
  public DateTime? RegDate { get; set; }
  public string Content { get; set; }

  public bool Completed { get; set; }
}