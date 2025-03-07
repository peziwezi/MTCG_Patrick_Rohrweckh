using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataModel
{
    class DataPackage
    {
        public DataPackage()
        {

        }
        public DataPackage(string? cardId1, string? cardId2, string? cardId3, string? cardId4, string? cardId5)
        {
            CardId1 = cardId1;
            CardId2 = cardId2;
            CardId3 = cardId3;
            CardId4 = cardId4;
            CardId5 = cardId5;
        }
        public int? Id { get; set; }
        public string? CardId1 { get; set; }
        public string? CardId2 { get; set; }
        public string? CardId3 { get; set; }
        public string? CardId4 { get; set; }
        public string? CardId5 { get; set; }

        public override string ToString()
        {
            return $"Package: Id={Id}, CardId1={CardId1}, CardId2={CardId2}, CardId3={CardId3}, CardId4={CardId4}, CardId5={CardId5}";
        }
    }
}
