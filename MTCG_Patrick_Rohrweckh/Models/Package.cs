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
                Card temp;
                if (cards[i].CardType == CardType.spell)
                {
                    temp = new SpellCard(cards[i].Id, cards[i].Name, cards[i].Damage);
                }
                else
                {
                    temp = new MonsterCard(cards[i].Id,cards[i].Name, cards[i].Damage);
                }
                Packages.Add(temp);
            }
        }
        public const int PackageMax = 5;
    }
}
