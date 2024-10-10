using MTCG_Patrick_Rohrweckh;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;


// ===== I. Start the HTTP-Server =====
HttpServer httpServer = new HttpServer(IPAddress.Loopback, 10001);
httpServer.Start();


while (true)
{
    // ----- 0. Accept the TCP-Client and create the reader and writer -----
    TcpClient clientSocket = httpServer.AcceptTcpClient();
    using StreamReader reader = new StreamReader(clientSocket.GetStream());
    using StreamWriter writer = new StreamWriter(clientSocket.GetStream()) { AutoFlush = true };
    HttpRequest httpRequest = new HttpRequest(reader);
    HttpResponse httpResponse = new HttpResponse(writer);
    UserEndpoint userEndpoint = new UserEndpoint(httpRequest, httpResponse);
   
}
