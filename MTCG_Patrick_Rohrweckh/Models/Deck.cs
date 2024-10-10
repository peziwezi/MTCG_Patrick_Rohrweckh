﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Models
{
    internal class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck() 
        {
            Cards = new List<Card>();
        }
        public const int DeckMax = 4;
    }
}
