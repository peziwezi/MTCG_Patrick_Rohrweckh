using MTCG_Patrick_Rohrweckh.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    internal class PackagesEndpoint
    {
        public PackagesEndpoint(HttpRequest request, HttpResponse response)
        {
            if (request != null)
            {
                if (request.content != null)
                {
                    try
                    {
                        List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(request.content);
                        if (cards != null)
                        {
                            if (request.method == "POST")
                            {
                                if(request.token == "admin")
                                {
                                    try
                                    {
                                        Package package = new Package(cards);
                                        response.WriteResponse(201, "", "");
                                    }
                                    catch (ArgumentException)
                                    {
                                        response.WriteResponse(409, "Unable to create package", "");
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
                    }
                    catch (JsonReaderException)
                    {
                        response.WriteResponse(400, "Bad Request", "");
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
