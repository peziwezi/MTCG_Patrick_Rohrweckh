﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    public class SpellCard : Card
    {
        public SpellCard(string id, string name, double damage) : base(id, name, damage)
        {
        }
    }
}
