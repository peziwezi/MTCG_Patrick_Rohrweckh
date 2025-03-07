using MTCG_Patrick_Rohrweckh.Businesslogic;
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
        internal int? Add(DataPackage package)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = "INSERT INTO packages (status) " +
                "VALUES (@status) RETURNING id";
            AddParameterWithValue(command, "status", DbType.String, package.Status ?? (object)DBNull.Value);
            object? result = command.ExecuteScalar();
            package.Id = result != null ? Convert.ToInt32(result) : 0;
            return package.Id;
        }
        internal int ReturnId()
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = @"SELECT id FROM packages where status = 'Available'";
            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            return 0;
        }
        internal IEnumerable<DataPackage> GetAll()
        {
            List<DataPackage> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT id, status FROM packages";

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataPackage()
                    {
                        Id = reader.GetInt32(0),
                        Status = reader.GetString(1),
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
            command.CommandText = @"SELECT id, status FROM packages WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, id);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataPackage()
                {
                    Id = reader.GetInt32(0),
                    Status = reader.GetString(1),
                };
            }
            return null;
        }
        internal void Update(DataPackage package)
        {
            if (package.Id == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "UPDATE packages SET status=@status WHERE id=@id";
            AddParameterWithValue(command, "id", DbType.Int32, package.Id);
            AddParameterWithValue(command, "status", DbType.String, package.Status ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
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
