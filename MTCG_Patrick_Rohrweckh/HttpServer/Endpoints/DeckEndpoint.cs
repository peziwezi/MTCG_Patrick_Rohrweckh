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
                    else if(request.method == "PUT")
                    {
                        if (request.token != "" && request.token != null)
                        {
                            try
                            {
                                DataUser dataUser = dataHandler.userHandler.RetrieveUser(request.token);
                                Deck deck = JsonConvert.DeserializeObject<Deck>(request.content);

                                for(int i = 0; i < deck.DeckMax; i++)
                                {
                                    if(dataHandler.stackHandler.CountDeck(dataUser.Id) < 4)
                                    {
                                        DataStack stack = dataHandler.stackHandler.RetrieveStack(dataUser.Id, deck.Cards[i].Id);
                                        dataHandler.stackHandler.UpdateStack(stack);
                                    }
                                    else
                                    {
                                        throw new ArgumentException("Deck Full");
                                    }
                                }
                                response.WriteResponse(200, "", "");
                            }
                            catch (ArgumentException)
                            {
                                response.WriteResponse(409, "Unable to fill Deck ", "");
                            }
                            catch (Npgsql.NpgsqlException)
                            {
                                response.WriteResponse(503, "Unable to connect to database ", "");
                            }
                            catch (JsonReaderException)
                            {
                                response.WriteResponse(400, "Bad Request", "");
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
