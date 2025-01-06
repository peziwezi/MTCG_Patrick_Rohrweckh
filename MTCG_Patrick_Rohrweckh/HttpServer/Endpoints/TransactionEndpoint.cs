using MTCG_Patrick_Rohrweckh.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    internal class TransactionEndpoint
    {
        public TransactionEndpoint(HttpRequest request, HttpResponse response) 
        {

            if (request != null)
            {
                if (request.content == null)
                {
                    if (request.method == "POST")
                    {
                        if (request.token != "")
                        {
                            try
                            {
                                response.WriteResponse(201, "", "");
                            }
                            catch (ArgumentException)
                            {
                                response.WriteResponse(409, "No packages available", "");
                            }
                        }
                        else
                        {
                            response.WriteResponse(403, "Forbidden", "");
                        }
                    }
                    else
                    {
                        response.WriteResponse(405, "Method Not Allowed", "");
                    }
                }
                else
                {
                    response.WriteResponse(400, "Bad Request", "");
                }
            }
        }
    }
}
