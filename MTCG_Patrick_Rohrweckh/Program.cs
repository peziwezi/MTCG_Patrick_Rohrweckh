using MTCG_Patrick_Rohrweckh;
using System.Net;
using System.Net.Sockets;
using System.Text;


// ===== I. Start the HTTP-Server =====
HttpServer httpServer = new HttpServer(IPAddress.Loopback, 10001);
httpServer.Start();

while (true)
{
    // ----- 0. Accept the TCP-Client and create the reader and writer -----
    TcpClient clientSocket = httpServer.AcceptTcpClient();
    HttpRequest httpRequest = new HttpRequest(clientSocket);
    HttpResponse httpResponse = new HttpResponse(clientSocket);
}
