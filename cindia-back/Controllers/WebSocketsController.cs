using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class WebSocketsController: Controller
{
    [HttpGet]
    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private static async Task Echo(WebSocket webSocket)
    {
        try
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult receiveResult;
    
            while (webSocket.State == WebSocketState.Open)
            {
                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
    
                if (receiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(
                        WebSocketCloseStatus.NormalClosure,
                        "Received close message from client",
                        CancellationToken.None);
                    break;
                }
    
                // Handle the received message
                var receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                Console.WriteLine("Received message: " + receivedMessage);
    
                // Modify or process the message as needed
    
                // Echo the message back to the client
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);
            }
        }
        catch (WebSocketException ex)
        {
            Console.WriteLine("WebSocket error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (webSocket.State == WebSocketState.Open)
                await webSocket.CloseAsync(
                    WebSocketCloseStatus.InternalServerError,
                    "An error occurred on the server",
                    CancellationToken.None);
    
            webSocket.Dispose();
        }
    }

}