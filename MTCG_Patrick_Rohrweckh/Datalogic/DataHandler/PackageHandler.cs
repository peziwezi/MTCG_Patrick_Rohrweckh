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
    class PackageHandler
    {
        public PackageHandler()
        {
            PackageRepository = new PackageRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb");
        }
        public PackageRepository PackageRepository;
        public int? CreatePackage(string status)
        {
            // Create:
            Console.WriteLine("Create:");
            if (status  == null)
            {
                throw new ArgumentException("List is empty");
            }
            else
            {
                DataPackage package = new DataPackage(status);
                int? id = PackageRepository.Add(package);
                Console.WriteLine(package);
                return id;
            }
        }
        public DataPackage RetrievePackage(int? id)
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            if (PackageRepository.GetById(id) == null)
            {
                throw new ArgumentException("User already exists");
            }
            else
            {
                return PackageRepository.GetById(id);
            }
        }
        public void RetrieveAll()
        {
            // Retrieve:
            Console.WriteLine("Retrieve:");
            PackageRepository.GetAll().ToList().ForEach(p => Console.WriteLine(p));
        }
        public void UpdatePackage(DataPackage package)
        {
            // Update:
            Console.WriteLine("Update:");
            PackageRepository.Update(package);
            Console.WriteLine(PackageRepository.GetById(package.Id));
        }
        public int ChoosePackage()
        {
            Console.WriteLine("Retrieve:");
            int id = PackageRepository.ReturnId();
            return id;
        }
        public void DeletePackage(DataPackage package)
        {
            // Delete:
            Console.WriteLine("Delete:");
            PackageRepository.Delete(package);
        }
    }
}
