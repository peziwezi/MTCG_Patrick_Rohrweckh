using MTCG_Patrick_Rohrweckh.Models;

namespace MTCG_Patrick_Rohrweckh.Datalogic
{
    internal class UserHandler
    {
        public UserHandler()
        {
            UserRepository = new UserRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb");
        }
        public UserRepository UserRepository;
        public void CreateUser(DataUser user)
        {
            // Create:
            Console.WriteLine("Create:");
            UserRepository.Add(user);
            Console.WriteLine(user);
        }
        public void RetrieveAll() {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            UserRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));
        }
        public void RetrieveUser(DataUser user)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            Console.WriteLine(UserRepository.GetByUsername(user.Username));
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
