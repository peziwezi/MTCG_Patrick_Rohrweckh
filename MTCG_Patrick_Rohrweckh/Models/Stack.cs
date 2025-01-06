using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public class Stack
    {
        public List<Card> Cards { get; set; }
        public Stack() 
        {
            Cards = new List<Card>();
        }
    }
}
