using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.HttpServer
{
    internal class HttpServer
    {
        public HttpServer(IPAddress ipAdress, int port) {
            httpServer = new TcpListener(ipAdress, port);
        }
        public TcpListener httpServer { get; private set; }
        public void Start()
        {
            httpServer.Start();
            Console.WriteLine("Our first simple HTTP-Server: http://localhost:10001/");
        }
        public TcpClient AcceptTcpClient()
        {
            return httpServer.AcceptTcpClient();
        }
    }
}
