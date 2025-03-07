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
    internal class TransactionEndpoint
    {
        public TransactionEndpoint(HttpRequest request, HttpResponse response, DataHandler dataHandler)
        {

            if (request != null)
            {
                if (request.content == null)
                {
                    if (request.method == "POST")
                    {
                        if (request.token != "" && request.token != null)
                        {
                            try
                            {
                                int id = dataHandler.packageHandler.ChoosePackage();
                                if ( id == 0)
                                {
                                    throw new ArgumentException("No Package left");
                                }
                                else
                                { 
                                    DataUser dataUser = dataHandler.userHandler.RetrieveUser(request.token);
                                    if (dataUser.Coins <= 0)
                                    {
                                        response.WriteResponse(412, "Not enough money", "");
                                    }
                                    else
                                    {
                                        DataPackage dataPackage = dataHandler.packageHandler.RetrievePackage(id);
                                        List<DataCard> cards = dataHandler.cardHandler.GetPackageById(dataPackage.Id);
                                        for (int i = 0; i < 5; i++)
                                        {
                                           DataStack temp = new DataStack(dataUser.Id, cards[i].Id, "Stack");
                                            dataHandler.stackHandler.CreateStack(temp);
                                        }
                                        dataPackage.Status = "Sold";
                                        dataHandler.packageHandler.UpdatePackage(dataPackage);
                                        dataUser.Coins -= 5;
                                        dataHandler.userHandler.UpdateUser(dataUser);
                                        response.WriteResponse(201, "", "");
                                    }
                                }
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
