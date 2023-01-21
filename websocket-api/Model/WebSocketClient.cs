using System.Net.WebSockets;

namespace websocket_api.Model;

public enum WscType
{
  Client
}

public class WebSocketClient
{

  private WebSocket _ws;

  public Guid ClientID { get; } = Guid.NewGuid();

  public WebSocketClient(WebSocket ws)
  {
    _ws = ws;
    Type = WscType.Client;
  }

  public WscType Type { get; set; }
}