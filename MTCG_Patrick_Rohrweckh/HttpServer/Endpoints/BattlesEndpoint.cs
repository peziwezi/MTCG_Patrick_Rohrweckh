using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    class BattlesEndpoint
    {
        public BattlesEndpoint(HttpRequest request, HttpResponse response, DataHandler dataHandler)
        {
            // ----- 2. Do the processing -----
            // .... 
            if (request != null)
            {
                if (request.content == null)
                {
                    try
                    {
                        if (request.method == "POST")
                        {

                            if (request.token != "" && request.token != null)
                            {
                                try
                                {
                                    DataUser dataUser = dataHandler.userHandler.RetrieveUser(request.token);
                                    response.WriteResponse(201, "", "");
                                }
                                catch (ArgumentException)
                                {
                                    response.WriteResponse(409, "User already exists", "");
                                }
                                catch (Npgsql.NpgsqlException)
                                {
                                    response.WriteResponse(503, "Unable to connect to database ", "");
                                }
                            }
                        }
                        else
                        {
                            response.WriteResponse(405, "Method Not Allowed", "");
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
