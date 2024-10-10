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
        public HttpResponse(StreamWriter writer) 
        {
             writerAlsoToConsole = new StreamTracer(writer);  // we use a simple helper-class StreamTracer to write the HTTP-Response to the client and to the console
        }
        public void WriteResponse(int statusCode, string statusMessage, string content)
        {
            // ----- 3. Write the HTTP-Response -----

            writerAlsoToConsole.WriteLine("HTTP/1.0 " + statusCode +" " + statusMessage);    // first line in HTTP-Response contains the HTTP-Version and the status code
            if(content != "")
            {
                writerAlsoToConsole.WriteLine("Content-Type: application/json");     // the HTTP-headers (in HTTP after the first line, until the empy line)
                writerAlsoToConsole.WriteLine();
                writerAlsoToConsole.WriteLine(content);    // the HTTP-content 
            }
            else
            {
                writerAlsoToConsole.WriteLine();
            }
            Console.WriteLine("========================================");
        }
        public StreamTracer writerAlsoToConsole;
    }
}
