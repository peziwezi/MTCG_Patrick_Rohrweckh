using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            if (httpRequest != null)
            {
                if (httpRequest.path == "/users" || httpRequest.path == "/sessions")
                {
                    if (httpRequest.content != null)
                    {
                        User user = JsonConvert.DeserializeObject<User>(httpRequest.content);
                        if (httpRequest.path == "/users" && httpRequest.method == "POST")
                        {
                            httpResponse.WriteResponse(201, "");
                        }
                        else if (httpRequest.path == "/sessions" && httpRequest.method == "POST")
                        {
                            httpResponse.WriteResponse(200, "");
                        }

                    }
                    else
                    {
                        httpResponse.WriteResponse(400, "Bad Request");
                    }
                }
                else
                {
                    httpResponse.WriteResponse(400, "Bad Request");
                }
            }
            
        }
        
        public HttpRequest httpRequest { get; set; }
        public HttpResponse httpResponse { get; set; }
        

    }
}
