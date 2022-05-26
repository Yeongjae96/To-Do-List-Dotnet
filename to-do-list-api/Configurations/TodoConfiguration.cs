using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Entities;

namespace TodoList.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
  public void Configure(EntityTypeBuilder<Todo> builder)
  {
    builder.UseCollation("utf8_unicode_ci")
           .HasCharSet("utf8");

    builder.HasKey(e => e.No)
           .HasName("PRIMARY");

    builder.ToTable("tb_todo");

    builder.Property(e => e.No).HasColumnName("No").HasColumnType("bigint(20)").HasComment("기본키");
    builder.Property(e => e.Content).HasColumnType("text").HasColumnName("CONTENT");
    builder.Property(e => e.RegDate).HasColumnName("REG_DATE").HasDefaultValueSql("curdate()");
    builder.Property(e => e.Title).HasColumnName("TITLE").HasMaxLength(100);
  }
}