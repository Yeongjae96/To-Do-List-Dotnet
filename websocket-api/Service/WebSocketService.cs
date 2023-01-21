using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using websocket_api.Model;

namespace websocket_api.Service;

public class WebSocketService : IDisposable
{
  private bool _isDisposed = false;


  private static readonly ConcurrentDictionary<WebSocket, WebSocketClient> _clients = new ConcurrentDictionary<WebSocket, WebSocketClient>();

  #region Dispose Pattern
  ~WebSocketService()
  {
    Dispose(false);
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(true);
  }

  public virtual void Dispose(bool isDisposing)
  {
    if (_isDisposed) return;

    if (isDisposing)
    {
      // internal Property Disposing!
    }

    isDisposing = true;
  }
  #endregion

  public string ResolveData(ArraySegment<byte> receiveData)
  {
    var requestString = Encoding.UTF8.GetString(receiveData);
    return result;
  }

  public async Task<WebSocket> ReceiveClient(WebSocketManager manager)
  {
    var ws = await manager.AcceptWebSocketAsync();
    var wsClient = new WebSocketClient(ws);
    _clients.TryAdd(ws, wsClient);

    Console.WriteLine($"Connect Client :: {wsClient.ClientID}");

    return ws;
  }

  public async Task CloseClient(WebSocket ws)
  {
    Console.WriteLine($"Disconnect Client :: {_clients[ws].ClientID}");

    await ws.CloseAsync(
        WebSocketCloseStatus.NormalClosure,
        "Closing",
        CancellationToken.None);

    if (_clients.ContainsKey(ws))
    {
      _clients.TryRemove(ws, out _);
    }
  }

  public async void Broadcast(WebSocket ws, string message)
  {
    foreach (var client in _clients)
    {
      if (client.Key == ws) continue;
      await SendMessage(client.Key, message);
    }
  }

  public async Task SendMessage(WebSocket ws, string message)
  {
    await ws.SendAsync(
      new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)),
      WebSocketMessageType.Binary,
      true,
      CancellationToken.None
    );
  }
}