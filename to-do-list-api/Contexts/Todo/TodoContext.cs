using Microsoft.EntityFrameworkCore;
using TodoList.Models.Todo;

namespace TodoList.Contexts.Todo;

public partial class TodoContext : DbContext
{
  public TodoContext(DbContextOptions<TodoContext> options) : base(options) {}

  public virtual DbSet<TodoItem> TodoSet { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // reg_date 속성
    modelBuilder
      .Entity<TodoItem>()
      .Property(e => e.RegDate)
      .HasColumnName("reg_date")
      .HasDefaultValue(DateTime.Now);

    // Completed 속성
    modelBuilder
      .Entity<TodoItem>()
      .Property(e => e.Completed)
      .HasColumnName("completed")
      .HasMaxLength(1)
      .HasConversion(v => v ? "Y" : "N", v => v == "Y" ? true : false);
  }
}