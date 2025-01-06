using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public enum Element 
    { 
        water,
        fire,
        normal
    };
    public enum CardType
    {
        monster,
        spell
    }
    public class Card
    {
        public Card(string id, string name, float amount)
        {

            Id = id;
            Name = name;
            Damage = amount;
            if(name.Contains("Fire"))
            {
                ElementType = Element.fire;
            }
            else if(name.Contains("Water"))
            {
                ElementType = Element.water;
            }
            else
            {
                ElementType = Element.normal;
            }
            if(name.Contains("Spell"))
            {
                CardType = CardType.spell;
            }
            else
            {
                CardType = CardType.monster;
            }
        }
        public readonly string Id;
        public readonly float Damage;
        public readonly string Name;
        public readonly CardType CardType;
        public readonly Element ElementType;
    }
}
