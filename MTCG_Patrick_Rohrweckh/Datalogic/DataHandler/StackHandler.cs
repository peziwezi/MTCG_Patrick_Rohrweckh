using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Datalogic.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    public class StackHandler
    {
        public StackHandler(StackRepository stackRepository)
        {
            StackRepository = stackRepository;
        }
        public StackRepository StackRepository;
        public void CreateStack(DataStack stack)
        {
            // Create:
            Console.WriteLine("Create:");
            if (StackRepository.GetByIds(stack.UserId, stack.CardId) != null)
            {
                throw new ArgumentException("User already exists");
            }
            else
            {
               StackRepository.Add(stack);
                Console.WriteLine(stack);
            }
        }
        public void RetrieveAll()
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            StackRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));
        }
        public List<DataStack> RetrieveAllById(int? userid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            return StackRepository.GetAllById(userid).ToList();
        }
        public DataStack RetrieveStack(int? userid, string cardid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            if (StackRepository.GetByIds(userid, cardid) == null)
            {
                throw new ArgumentException("Stack does not exist");
            }
            else
            {
                return StackRepository.GetByIds(userid, cardid);
            }
        }
        public List<DataStack> RetrieveDeck(int? userid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            return StackRepository.GetDeckById(userid).ToList();
        }
        public int? CountDeck(int? userid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            return StackRepository.DeckAmount(userid);
        }
        public void UpdateStack(DataStack stack)
        {
            // Update:
            Console.WriteLine("Update:");
            StackRepository.Update(stack);
            Console.WriteLine(StackRepository.GetByIds(stack.UserId, stack.CardId));
        }
        public void DeleteStack(DataStack stack)
        {
            // Delete:
            Console.WriteLine("Delete:");
            StackRepository.Delete(stack);
        }
    }
}
