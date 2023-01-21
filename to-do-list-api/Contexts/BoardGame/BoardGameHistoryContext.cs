using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TodoList.Models.BoardGame;
using TodoList.Models.Todo;

namespace TodoList.Contexts.BoardGame;

public partial class BoardGameHistoryContext : DbContext
{
  public BoardGameHistoryContext(DbContextOptions<BoardGameHistoryContext> options) : base(options) { }

  public virtual DbSet<BoardGameHistory> BoardGameHistorySet { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // ID 속성
    modelBuilder
      .Entity<BoardGameHistory>()
      .Property(e => e.Id)
      .HasColumnName("ID")
      .HasDefaultValue(Guid.NewGuid().ToString());

    // CREATE DATE 속성
    modelBuilder
      .Entity<BoardGameHistory>()
      .Property(e => e.CreateDate)
      .HasColumnName("CREATE_DATE")
      .HasDefaultValue(DateTime.Now);

    // GameScore
    modelBuilder
      .Entity<BoardGameHistory>()
      .Property(e => e.GameScore)
      .HasColumnName("GAME_SCORE")
      // .HasDefaultValueSql()
      .HasConversion(
        v => v != null ? JsonConvert.SerializeObject(v) : "[]",
        v => v != null ? JsonConvert.DeserializeObject<Dictionary<string, int>>(v) : new Dictionary<string, int>()
      );

    // Completed 속성
    // modelBuilder
    //   .Entity<TodoItem>()
    //   .Property(e => e.Completed)
    //   .HasColumnName("completed")
    //   .HasMaxLength(1)
    //   .HasConversion(v => v ? "Y" : "N", v => v == "Y" ? true : false);
  }
}