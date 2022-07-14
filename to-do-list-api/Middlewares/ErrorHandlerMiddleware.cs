using Newtonsoft.Json;

namespace TodoList.Middlewares;

public class ErrorHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public ErrorHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next.Invoke(context);
    } 
    catch (Exception error)
    {
      var response = context.Response;
      response.ContentType = "application/json";

      switch (error)
      {
        case ApplicationException e:
          response.StatusCode = 400;
          break;
        case KeyNotFoundException e:
          response.StatusCode = 404;
          break;
        default:
          response.StatusCode = 500;
          break;
      }

      var result = JsonConvert.SerializeObject(new { msg = error?.Message });
      await response.WriteAsync(result);
    }
  }

}