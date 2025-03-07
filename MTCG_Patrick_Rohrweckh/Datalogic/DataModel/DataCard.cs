﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataModel
{
    class DataCard
    {
        public DataCard()
        {

        }
        public DataCard(string? id, string name, double damage, int? packid)
        {
            Id = id;
            Name = name;
            Damage = damage;
            Packid = packid;
        }
        public string? Id { get; set; }
        public string Name { get; set; } = "";
        public double Damage { get; set; }
        public int? Packid { get; set; }
        public override string ToString()
        {
            return $"Card: Id={Id}, Name={Name}, Damage={Damage}";
        }
    }
}
