using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using websocket_api.Service;

namespace websocket_api.Controllers;

public class BoardGameController : ControllerBase
{
  public readonly WebSocketService _ws;

  public BoardGameController(WebSocketService ws)
  {
    _ws = ws;
  }

  [Route("/ws")]
  public async Task Get()
  {
    if (HttpContext.WebSockets.IsWebSocketRequest)
    {
      var webSocket = await _ws.ReceiveClient(HttpContext.WebSockets);
      await Send(webSocket);
    }
    else
    {
      HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
  }

  private async Task Send(WebSocket webSocket)
  {
    var buffer = new byte[1024 * 4];

    // var receiveResult = await webSocket.ReceiveAsync(
    //     new ArraySegment<byte>(buffer), CancellationToken.None);

    WebSocketReceiveResult receiveResult = new WebSocketReceiveResult(0, WebSocketMessageType.Text, true);

    while (true)
    {
      receiveResult = await webSocket.ReceiveAsync(
          new ArraySegment<byte>(buffer), CancellationToken.None);

      if (receiveResult.CloseStatus.HasValue) break;

      // 중간 처리기
      var resultString = _ws.ResolveData(buffer);
      Console.WriteLine(resultString);

      await webSocket.SendAsync(
          new ArraySegment<byte>(buffer, 0, receiveResult.Count),
          receiveResult.MessageType,
          receiveResult.EndOfMessage,
          CancellationToken.None);
    }
    await _ws.CloseClient(webSocket);
  }
}
