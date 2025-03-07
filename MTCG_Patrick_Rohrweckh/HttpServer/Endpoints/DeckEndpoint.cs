using MTCG_Patrick_Rohrweckh.Datalogic.DataHandler;
using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.HttpServer.Endpoints
{
    class DeckEndpoint
    {
        public DeckEndpoint(HttpRequest request, HttpResponse response, DataHandler dataHandler)
        {
            // ----- 2. Do the processing -----
            // .... 
            if (request != null)
            {
                if (request.content == null)
                {
                    if (request.method == "GET")
                    {
                        if (request.token != "" && request.token != null)
                        {
                            try
                            {
                                DataUser dataUser = dataHandler.userHandler.RetrieveUser(request.token);
                                List<DataStack> decks = dataHandler.stackHandler.RetrieveDeck(dataUser.Id);
                                List<DataCard> cards = new List<DataCard>();
                                foreach (DataStack deck in decks)
                                {
                                    cards.Add(dataHandler.cardHandler.RetrieveCardbyId(deck.CardId));
                                }
                                string json = JsonConvert.SerializeObject(cards);
                                response.WriteResponse(200, "", json);
                            }
                            catch (ArgumentException)
                            {
                                response.WriteResponse(409, "Unable to fetch ", "");
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
                else
                {
                    response.WriteResponse(400, "Bad Request", "");
                }
            }
        }
    }
}
