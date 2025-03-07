using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Datalogic.DataRepository;
using MTCG_Patrick_Rohrweckh.Models;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    public class UserHandler
    {
        public UserHandler(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public UserRepository UserRepository;
        public void CreateUser(DataUser user)
        {
            // Create:
            Console.WriteLine("Create:");
            if(UserRepository.GetByUsername(user.Username) != null)
            {
                throw new ArgumentException("User already exists");
            }
            else 
            {
                UserRepository.Add(user);
                Console.WriteLine(user);
            }
        }
        public void RetrieveAll() {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            UserRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));
        }
        public DataUser RetrieveUser(string username)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            if (UserRepository.GetByUsername(username) != null)
            {
                return UserRepository.GetByUsername(username);
            }
            else
            { 
                throw new ArgumentException("User already exists"); 
            }
        }
        public void UpdateUser(DataUser user) {
            // Update:
            Console.WriteLine("Update:");
            UserRepository.Update(user);
            Console.WriteLine(UserRepository.GetById(user.Id));
        }
        public void DeleteUser(DataUser user)
        {
            // Delete:
            Console.WriteLine("Delete:");
            UserRepository.Delete(user);
        }
    }
}
