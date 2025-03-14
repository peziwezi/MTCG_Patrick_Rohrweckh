﻿using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
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
    internal class PackagesEndpoint
    {
        public PackagesEndpoint(HttpRequest request, HttpResponse response, DataHandler dataHandler)
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
                                        int? id = dataHandler.packageHandler.CreatePackage("Available");
                                        Package package = new Package(cards);
                                        for (int i = 0; i < package.PackageMax; i++)
                                        {
                                            DataCard temp = new DataCard(package.Packages[i].Id, package.Packages[i].Name, package.Packages[i].Damage, id);
                                            dataHandler.cardHandler.CreateCard(temp);
                                        }
                                        response.WriteResponse(201, "", "");
                                    }
                                    catch (ArgumentException)
                                    {
                                        response.WriteResponse(409, "Unable to create package", "");
                                    }
                                    catch (Npgsql.NpgsqlException)
                                    {
                                        response.WriteResponse(503, "Unable to connect to database ", "");
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
