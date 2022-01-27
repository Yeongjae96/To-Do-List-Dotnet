using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;
[ApiController]
[Route("[controller]")]
public class TodoController : Controller
{
  [HttpGet]
  public ActionResult<List<string>> Get()
  {
    var result = new List<string> { "1","2","3","4","5" };

    return Ok(result);
  }
}