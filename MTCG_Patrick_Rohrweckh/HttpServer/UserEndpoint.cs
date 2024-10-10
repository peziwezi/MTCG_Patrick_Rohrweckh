using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh
{
    internal class UserEndpoint
    {
        public UserEndpoint(HttpRequest request, HttpResponse response)
        {
            httpRequest = request;
            httpResponse = response;
            // ----- 2. Do the processing -----
            // .... 

            Console.WriteLine("----------------------------------------");
        }
        
        public HttpRequest httpRequest { get; set; }
        public HttpResponse httpResponse { get; set; }
        

    }
}
