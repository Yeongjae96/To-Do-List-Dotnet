using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Models.Common;

namespace TodoList.Common.Interface;

public interface IPaginable
{
  [NotMapped]
  public PaginationInfo Pagination { get; }
}