using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    internal class UserEndpoint
    {
        public UserEndpoint(HttpRequest request, HttpResponse response, DataHandler dataHandler)
        {
            // ----- 2. Do the processing -----
            // .... 
            if (request != null)
            {
                if (request.content != null)
                {
                    try
                    {
                        User user = JsonConvert.DeserializeObject<User>(request.content);
                        if (user != null)
                        {
                            if (request.method == "POST")
                            {
                                if (request.path == "/users")
                                {
                                    try
                                    {
                                        DataUser dataUser = new DataUser(user.Username, user.Password, user.ELO, user.Coins);
                                        dataHandler.userHandler.CreateUser(dataUser);
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
                                else if (request.path == "/sessions")
                                {
                                    try
                                    {
                                        DataUser dataUser = dataHandler.userHandler.RetrieveUser(user.Username);
                                        if (dataUser.Password == user.Password)
                                        {
                                            string token = user.Username + "-mtcgToken";
                                            string json = JsonConvert.SerializeObject(token);
                                            response.WriteResponse(200, "", json);
                                        }
                                        else
                                        {
                                            response.WriteResponse(401, "Login failed", "");
                                        }
                                    }
                                    catch (ArgumentException)
                                    {
                                        response.WriteResponse(401, "Login failed", "");
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
