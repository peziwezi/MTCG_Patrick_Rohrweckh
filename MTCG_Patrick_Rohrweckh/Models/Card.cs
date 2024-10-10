using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    enum Element 
    { 
        water,
        fire,
        normal
    };
    internal abstract class Card
    {
        public Card(string name, int amount, Element type) {
            Name = name;
            Damage = amount;
            ElementType = type;
        }
        public readonly int Damage;
        public readonly string Name;
        public readonly Element ElementType;
    }
}
