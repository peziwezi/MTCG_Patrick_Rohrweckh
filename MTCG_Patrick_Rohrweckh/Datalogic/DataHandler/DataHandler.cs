using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataHandler
{
    class DataHandler
    {
        public DataHandler()
        {
            userHandler = new UserHandler();
            packageHandler = new PackageHandler();
            cardHandler = new CardHandler();
            stackHandler = new StackHandler();
        }
        public UserHandler userHandler { get; set; }
        public PackageHandler packageHandler { get; set; }
        public CardHandler cardHandler { get; set; }
        public StackHandler stackHandler { get; set; }
    }
}
