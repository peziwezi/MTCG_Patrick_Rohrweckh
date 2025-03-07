using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck() 
        {
            Cards = new List<Card>();
        }
        public Deck(List<Card> cards)
        {
            if(cards.Count == 4)
            {
                Cards = cards;
            }
            else
            {
                throw new ArgumentException("A deck needs exactly 4 elements");
            }
        }

        public readonly int DeckMax = 4;
    }
}
