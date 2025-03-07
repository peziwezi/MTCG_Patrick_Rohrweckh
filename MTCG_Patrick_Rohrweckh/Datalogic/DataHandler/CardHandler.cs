using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Datalogic.DataRepository;
using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    class CardHandler
    {
        public CardHandler()
        {
            CardRepository = new CardRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb");
        }
        public CardRepository CardRepository;
        public void CreateCard(DataCard card)
        {
            // Create:
            Console.WriteLine("Create:");
            if (CardRepository.GetById(card.Id) != null)
            {
                throw new ArgumentException("Card already exists");
            }
            else
            {
                CardRepository.Add(card);
                Console.WriteLine(card);
            }
        }
        public void RetrieveAll()
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            CardRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));
        }
        public DataCard RetrieveCardbyId(string? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Id does not exist");
            }
            else
            {
                return CardRepository.GetById(id);
            }
        }
        public List<DataCard> GetPackageById(int? packid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            return CardRepository.GetPackage(packid).ToList();
        }
        public void DeleteCard(DataCard card)
        {
            // Delete:
            Console.WriteLine("Delete:");
            CardRepository.Delete(card);
        }
    }
}
