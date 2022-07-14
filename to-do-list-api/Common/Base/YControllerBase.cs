using Microsoft.AspNetCore.Mvc;

namespace TodoList.Common.Base;

public abstract class YControllerBase : Controller
{
  protected virtual OkObjectResult OkJson<T>(T data)
  {
    var result = new JsonResponse<T>()
    {
      Success = true,
      Message = "",
      Data = data
    };

    return Ok(result);
  }
}