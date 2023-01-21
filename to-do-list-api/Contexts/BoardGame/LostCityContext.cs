using Microsoft.EntityFrameworkCore;
using TodoList.Models.BoardGame;
using TodoList.Models.Todo;

namespace TodoList.Contexts.BoardGame;

public partial class LostCityContext : DbContext
{
  public LostCityContext(DbContextOptions<LostCityContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // ID 속성
    // modelBuilder
    //   .Entity<BoardGameHistory>()
    //   .Property(e => e.Id)
    //   .HasColumnName("ID")
    //   .HasDefaultValue(Guid.NewGuid().ToString());

    // modelBuilder
    //   .Entity<BoardGameHistory>()
    //   .Property(e => e.CreateDate)
    //   .HasColumnName("CREATE_DATE")
    //   .HasDefaultValue(DateTime.Now);

    // Completed 속성
    // modelBuilder
    //   .Entity<TodoItem>()
    //   .Property(e => e.Completed)
    //   .HasColumnName("completed")
    //   .HasMaxLength(1)
    //   .HasConversion(v => v ? "Y" : "N", v => v == "Y" ? true : false);
  }
}