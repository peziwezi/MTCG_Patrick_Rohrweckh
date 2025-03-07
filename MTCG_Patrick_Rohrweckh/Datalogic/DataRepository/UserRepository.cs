// See https://aka.ms/new-console-template for more information
using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using Npgsql;
using System;
using System.Data;
namespace MTCG_Patrick_Rohrweckh.Datalogic.DataRepository
{
    internal class UserRepository(string connectionString)
    {
        private readonly string connectionString = connectionString;

        internal void Add(DataUser user)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = "INSERT INTO users (username, password, elo, coins) " +
                "VALUES (@username, @password, @elo, @coins) RETURNING id";
            AddParameterWithValue(command, "username", DbType.String, user.Username ?? (object)DBNull.Value);
            AddParameterWithValue(command, "password", DbType.String, user.Password ?? (object)DBNull.Value);
            AddParameterWithValue(command, "elo", DbType.Int32, user.ELO);
            AddParameterWithValue(command, "coins", DbType.Int32, user.Coins);
            object? result = command.ExecuteScalar();
            user.Id = result != null ? Convert.ToInt32(result) : 0;
        }
        internal IEnumerable<DataUser> GetAll()
        {
            List<DataUser> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, username, password, elo, coins FROM users";

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataUser()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        ELO = reader.GetInt32(3),
                        Coins = reader.GetInt32(4)
                    });
                }
            return result;
        }

        internal DataUser? GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, username, password, elo, coins FROM users WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, id);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataUser()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    ELO = reader.GetInt32(3),
                    Coins = reader.GetInt32(4)
                };
            }
            return null;
        }

        internal DataUser? GetByUsername(string? username)
        {
            if (username == null)
                throw new ArgumentException("Username must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, username, password, elo, coins FROM users WHERE username=@username";
            AddParameterWithValue(command, "username", DbType.String, username);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataUser()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    ELO = reader.GetInt32(3),
                    Coins = reader.GetInt32(4)
                };
            }
            return null;
        }

        internal void Update(DataUser user)
        {
            if (user.Id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "UPDATE users SET username=@username, password=@password, elo=@elo, coins=@coins WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, user.Id);
            AddParameterWithValue(command, "username", DbType.String, user.Username);
            AddParameterWithValue(command, "password", DbType.String, user.Password);
            AddParameterWithValue(command, "elo", DbType.Int32, user.ELO);
            AddParameterWithValue(command, "coins", DbType.Int32, user.Coins);
            command.ExecuteNonQuery();
        }

        internal void Delete(DataUser user)
        {
            if (user.Id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "DELETE FROM users WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, user.Id);
            command.ExecuteNonQuery();
        }


        public static void AddParameterWithValue(IDbCommand command, string parameterName, DbType type, object value)
        {
            var parameter = command.CreateParameter();
            parameter.DbType = type;
            parameter.ParameterName = parameterName;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}