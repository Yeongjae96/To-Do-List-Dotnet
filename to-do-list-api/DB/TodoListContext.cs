using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities;

namespace TodoList.DB
{
    public partial class TodoListContext : DbContext
    {
        static public IConfigurationRoot Configuration { get; set; }

        public TodoListContext()
        {
        }

        public TodoListContext(DbContextOptions<TodoListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Configuration.GetConnectionString("MariaDbConnectionString");
                MariaDbServerVersion serverVersion = new MariaDbServerVersion("10.5.9-mariadb");
                // optionsBuilder.UseMySql("server=mik-study-01.cwr5pft7om8g.ap-northeast-2.rds.amazonaws.com;user id=admin;password=passw0rd!;database=TodoList_YJ", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.13-mariadb"));
                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PRIMARY");

                entity.ToTable("tb_todo");

                entity.Property(e => e.No)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("NO")
                    .HasComment("기본키");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("CONTENT");

                entity.Property(e => e.RegDate)
                    .HasColumnName("REG_DATE")
                    .HasDefaultValueSql("curdate()");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("TITLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
