using Microsoft.EntityFrameworkCore;
using TodoList.Configurations;
using TodoList.Entities;

namespace TodoList.Context;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

  public DbSet<Todo> Todos { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new TodoConfiguration());
  }
}