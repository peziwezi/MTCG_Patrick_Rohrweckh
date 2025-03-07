using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Datalogic.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    class StackHandler
    {
        public StackHandler()
        {
            StackRepository = new StackRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb");
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
        public void RetrieveAllById(int? userid)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            StackRepository.GetAllById(userid).ToList().ForEach(p => Console.WriteLine(p));
        }
        public DataStack RetrieveUser(int userid, string cardid)
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
