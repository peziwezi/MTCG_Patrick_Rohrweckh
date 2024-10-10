using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh
{
    internal class HttpResponse
    {
        public HttpResponse(TcpClient clientSocket) 
        {
            writer = writer = new StreamWriter(clientSocket.GetStream()) { AutoFlush = true };
            // ----- 2. Do the processing -----
            // .... 

            Console.WriteLine("----------------------------------------");

            // ----- 3. Write the HTTP-Response -----
            var writerAlsoToConsole = new StreamTracer(writer);  // we use a simple helper-class StreamTracer to write the HTTP-Response to the client and to the console

            writerAlsoToConsole.WriteLine("HTTP/1.0 200 OK");    // first line in HTTP-Response contains the HTTP-Version and the status code
            writerAlsoToConsole.WriteLine("Content-Type: text/html; charset=utf-8");     // the HTTP-headers (in HTTP after the first line, until the empy line)
            writerAlsoToConsole.WriteLine();
            writerAlsoToConsole.WriteLine("<html><body><h1>Hello World!</h1></body></html>");    // the HTTP-content (here we just return a minimalistic HTML Hello-World)

            Console.WriteLine("========================================");
        }
        public StreamWriter writer { get; set; }
    }
}
