using Microsoft.EntityFrameworkCore;
using TodoList.Contexts.BoardGame;
using TodoList.Contexts.Todo;
using TodoList.Middlewares;
using TodoList.Services.BoardGame;
using TodoList.Services.Todo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Add Context
builder.Services.AddDbContext<TodoContext>(options =>
{
  options.UseMySql(builder.Configuration.GetConnectionString("MariaDbConnectionString")
  , ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDbConnectionString"))
  );
});

builder.Services.AddDbContext<BoardGameHistoryContext>(options =>
{
  options.UseMySql(builder.Configuration.GetConnectionString("MariaDbConnectionString")
  , ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDbConnectionString"))
  );
});

// Add Services
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<BoardGameHistoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UsePathBase(new PathString("/api"));
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Configure HTTP request pipeline
{
  app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

  app.UseMiddleware<ErrorHandlerMiddleware>();
}


// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
