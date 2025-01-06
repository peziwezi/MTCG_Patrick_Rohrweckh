namespace MTCG_Patrick_Rohrweckh.Datalogic
{
    internal class DataUser
    {
        public DataUser()
        {
        }
        public DataUser(string username, string password, int elo, int coins) 
        { 
            Username = username;
            Password = password;
            ELO = elo;
            Coins = coins;
        }
        public int? Id { get; set; }
        public string Username { get; set; } = "";

        public string Password { get; set; } = "";

        public int ELO { get; set; }

        public int Coins { get; set; }

        public override string ToString()
        {
            return $"User: Id={Id}, Username={Username}, Password={Password}, ELO={ELO}, Coins={Coins}";
        }
    }
}