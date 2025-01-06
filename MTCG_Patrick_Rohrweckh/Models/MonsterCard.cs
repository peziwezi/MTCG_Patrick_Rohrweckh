using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public enum Monster
    {
        Goblin,
        Dragon,
        Wizzard,
        Ork,
        Knight,
        Kraken,
        Elf,
        Else
    }
    public class MonsterCard : Card
    {
        public MonsterCard(string id, string name, float amount) : base(id, name, amount)
        {
            CardType = Type.monster;
            if(Name.Contains("Goblin"))
            {
                MonsterType = Monster.Goblin;
            }
            else if(Name.Contains("Dragon"))
            {
                MonsterType = Monster.Dragon;
            }
            else if (Name.Contains("Wizzard"))
            {
                MonsterType = Monster.Wizzard;
            }
            else if (Name.Contains("Ork"))
            {
                MonsterType = Monster.Ork;
            }
            else if (Name.Contains("Knight"))
            {
                MonsterType = Monster.Knight;
            }
            else if (Name.Contains("Kraken"))
            {
                MonsterType = Monster.Kraken;
            }
            else if (Name.Contains("Elf"))
            {
                MonsterType = Monster.Elf;
            }
            else
            {
                MonsterType = Monster.Else;
            }
        }
        public readonly Type CardType;
        public readonly Monster MonsterType;

    }
}
