using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public class Package
    {
        public List<Card> Packages { get; set; }
        public Package(List<Card> cards) 
        {
            Packages = new List<Card>();
            for (int i = 0; i < PackageMax; i++)
            {
                Packages.Add(cards[i]);
            }
        }
        public const int PackageMax = 5;
    }
}
