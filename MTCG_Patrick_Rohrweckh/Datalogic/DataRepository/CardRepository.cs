﻿using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using MTCG_Patrick_Rohrweckh.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataRepository
{
    public class CardRepository(string connectionString)
    {
        private readonly string connectionString = connectionString;
        internal void Add(DataCard card)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = "INSERT INTO cards (id, name, damage, packid) " +
                "VALUES (@id, @name, @damage, @packid)";
            AddParameterWithValue(command, "id", DbType.String, card.Id ?? (object)DBNull.Value);
            AddParameterWithValue(command, "name", DbType.String, card.Name ?? (object)DBNull.Value);
            AddParameterWithValue(command, "damage", DbType.Double, card.Damage);
            AddParameterWithValue(command, "packid", DbType.Int32, card.Packid ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
        }
        internal IEnumerable<DataCard> GetAll()
        {
            List<DataCard> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, name, damage, packid FROM cards";

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataCard()
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Damage = reader.GetFloat(2),
                        Packid = reader.GetInt32(3),
                    });
                }
            return result;
        }

        internal IEnumerable<DataCard> GetPackage(int? packid)
        {
            List<DataCard> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, name, damage, packid FROM cards where packid=@packid";
            AddParameterWithValue(command, "packid", DbType.Int32, packid ?? (object)DBNull.Value);
            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataCard()
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Damage = reader.GetFloat(2),
                        Packid = reader.GetInt32(3),
                    });
                }
            return result;
        }

        internal DataCard? GetById(string? id)
        {
            if (id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT  id, name, damage, packid FROM cards WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.String, id);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataCard()
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Damage = reader.GetFloat(2),
                    Packid = reader.GetInt32(3),
                };
            }
            return null;
        }

        internal void Delete(DataCard card)
        {
            if (card.Id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "DELETE FROM cards WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.String, card.Id);
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
