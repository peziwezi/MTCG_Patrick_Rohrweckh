﻿using MTCG_Patrick_Rohrweckh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh
{
    internal class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Deck = new Deck();
            Stack = new Stack();
            Coins = 20;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public Deck Deck { get; set; }
        public Stack Stack { get; set; }
        public int Coins { get; set; }
    }

}
