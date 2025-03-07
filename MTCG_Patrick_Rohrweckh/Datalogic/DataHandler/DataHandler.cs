using MTCG_Patrick_Rohrweckh.Datalogic.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    public class DataHandler
    {
        public DataHandler()
        {
            userHandler = new UserHandler(new UserRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb"));
            packageHandler = new PackageHandler(new PackageRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb"));
            cardHandler = new CardHandler(new CardRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb"));
            stackHandler = new StackHandler(new StackRepository(
                "Host=localhost;Username=postgres;Password=password;Database=mtcgdb"));
        }
        public DataHandler(string database)
        {
            userHandler = new UserHandler(new UserRepository(
                database));
            packageHandler = new PackageHandler(new PackageRepository(
                database));
            cardHandler = new CardHandler(new CardRepository(
                database));
            stackHandler = new StackHandler(new StackRepository(
                database));
        }
        public UserHandler userHandler { get; set; }
        public PackageHandler packageHandler { get; set; }
        public CardHandler cardHandler { get; set; }
        public StackHandler stackHandler { get; set; }
    }
}
