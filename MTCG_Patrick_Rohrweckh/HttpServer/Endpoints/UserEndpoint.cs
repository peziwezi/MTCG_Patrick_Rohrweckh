using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    internal class UserEndpoint
    {
        public UserEndpoint(HttpRequest request, HttpResponse response, Dictionary<string, string> database)
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
                                        database.Add(user.Username, user.Password);
                                        response.WriteResponse(201, "", "");
                                    }
                                    catch (ArgumentException)
                                    {
                                        response.WriteResponse(409, "User already exists", "");
                                    }
                                }
                                else if (request.path == "/sessions")
                                {
                                    string value = "";
                                    if (database.TryGetValue(user.Username, out value))
                                    {
                                        if (database[user.Username] == user.Password)
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
                                    else
                                    {
                                        response.WriteResponse(401, "Login failed", "");
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
