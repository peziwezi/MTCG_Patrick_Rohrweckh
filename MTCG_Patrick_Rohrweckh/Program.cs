using MTCG_Patrick_Rohrweckh;
using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
using MTCG_Patrick_Rohrweckh.HttpServer;
using MTCG_Patrick_Rohrweckh.HttpServer.Endpoints;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Transactions;

// ===== I. Start the HTTP-Server =====
HttpServer httpServer = new HttpServer(IPAddress.Loopback, 10001);
httpServer.Start();

while (true)
{
    ThreadPool.QueueUserWorkItem(delegate
    {
        // ----- 0. Accept the TCP-Client and create the reader and writer -----
        TcpClient clientSocket = httpServer.AcceptTcpClient();
        using StreamReader reader = new StreamReader(clientSocket.GetStream());
        using StreamWriter writer = new StreamWriter(clientSocket.GetStream()) { AutoFlush = true };
        HttpRequest httpRequest = new HttpRequest(reader);
        HttpResponse httpResponse = new HttpResponse(writer);
        DataHandler dataHandler = new DataHandler();
        if (httpRequest.path == "/users" || httpRequest.path == "/sessions")
        {
            UserEndpoint userEndpoint = new UserEndpoint(httpRequest, httpResponse, dataHandler);
        }
        else if (httpRequest.path == "/packages")
        {
            PackagesEndpoint packagesEndpoint = new PackagesEndpoint(httpRequest, httpResponse, dataHandler);
        }
        else if (httpRequest.path == ("/transactions/packages"))
        {
            TransactionEndpoint transactionEndpoint = new TransactionEndpoint(httpRequest, httpResponse, dataHandler);
        }
        else
        {
            httpResponse.WriteResponse(404, "Not Found", "");
        }

    });
}
