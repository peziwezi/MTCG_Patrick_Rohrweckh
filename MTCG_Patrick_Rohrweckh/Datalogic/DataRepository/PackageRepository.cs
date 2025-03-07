using MTCG_Patrick_Rohrweckh.Datalogic.DataModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_Patrick_Rohrweckh.Datalogic.DataRepository
{
    class PackageRepository(string connectionString)
    {
        private readonly string connectionString = connectionString;
        internal void Add(DataPackage package)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = "INSERT INTO packages (cardid1, cardid2, cardid3, cardid4, cardid5) " +
                "VALUES (@cardid1, @cardid2, @cardid3, @cardid4, @cardid5) RETURNING id";
            AddParameterWithValue(command, "cardid1", DbType.String, package.CardId1 ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid2", DbType.String, package.CardId2 ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid3", DbType.String, package.CardId3 ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid4", DbType.String, package.CardId4 ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid5", DbType.String, package.CardId5 ?? (object)DBNull.Value);
            object? result = command.ExecuteScalar();
            package.Id = result != null ? Convert.ToInt32(result) : 0;
        }
        internal IEnumerable<DataPackage> GetAll()
        {
            List<DataPackage> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, cardid1, cardid2, cardid3, cardid4, cardid5 FROM packages";

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataPackage()
                    {
                        Id = reader.GetInt32(0),
                        CardId1 = reader.GetString(1),
                        CardId2 = reader.GetString(1),
                        CardId3 = reader.GetString(1),
                        CardId4 = reader.GetString(1),
                        CardId5 = reader.GetString(1),
                    });
                }
            return result;
        }

        internal DataPackage? GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, cardid1, cardid2, cardid3, cardid4, cardid5 FROM packages WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, id);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataPackage()
                {
                    Id = reader.GetInt32(0),
                    CardId1 = reader.GetString(1),
                    CardId2 = reader.GetString(1),
                    CardId3 = reader.GetString(1),
                    CardId4 = reader.GetString(1),
                    CardId5 = reader.GetString(1),
                };
            }
            return null;
        }

        internal void Delete(DataPackage package)
        {
            if (package.Id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "DELETE FROM packages WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, package.Id);
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
