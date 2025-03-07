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
    public class StackRepository(string connectionString)
    {
        private readonly string connectionString = connectionString;

        internal void Add(DataStack stack)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();

            command.CommandText = "INSERT INTO stacks (userid, cardid, stacktype) " +
                "VALUES (@userid, @cardid, @stacktype)";
            AddParameterWithValue(command, "userid", DbType.Int32, stack.UserId ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid", DbType.String, stack.CardId ?? (object)DBNull.Value);
            AddParameterWithValue(command, "stacktype", DbType.String, stack.StackType ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
        }
        internal IEnumerable<DataStack> GetAll()
        {
            List<DataStack> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT userid, cardid, stacktype FROM stacks";

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataStack()
                    {
                        UserId = reader.GetInt32(0),
                        CardId = reader.GetString(1),
                        StackType = reader.GetString(2),
                    });
                }
            return result;
        }

        internal DataStack? GetByIds(int? userid, string cardid)
        {
            if (userid == null || cardid == null)
                throw new ArgumentException("Ids must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT userid, cardid, stacktype FROM stacks WHERE userid=@userid AND cardid=@cardid";
            AddParameterWithValue(command, "userid", DbType.Int32, userid ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid", DbType.String, cardid ?? (object)DBNull.Value);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new DataStack()
                {
                    UserId = reader.GetInt32(0),
                    CardId = reader.GetString(1),
                    StackType = reader.GetString(2),
                };
            }
            return null;
        }
        internal int? DeckAmount(int? userid)
        {
            if (userid == null)
                throw new ArgumentException("Id must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT COUNT(stacktype) FROM stacks WHERE userid=@userid AND stacktype = 'Deck'";
            AddParameterWithValue(command, "userid", DbType.Int32, userid ?? (object)DBNull.Value);

            using IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return null;
        }
        internal IEnumerable<DataStack> GetAllById(int? userid)
        {
            List<DataStack> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT userid, cardid, stacktype FROM stacks where userid=@userid";
            AddParameterWithValue(command, "userid", DbType.Int32, userid ?? (object)DBNull.Value);

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataStack()
                    {
                        UserId = reader.GetInt32(0),
                        CardId = reader.GetString(1),
                        StackType = reader.GetString(2),
                    });
                }
            return result;
        }
        internal IEnumerable<DataStack> GetDeckById(int? userid)
        {
            List<DataStack> result = [];

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = @"SELECT userid, cardid, stacktype FROM stacks where userid=@userid and stacktype = 'Deck'";
            AddParameterWithValue(command, "userid", DbType.Int32, userid ?? (object)DBNull.Value);

            using (IDataReader reader = command.ExecuteReader())
                while (reader.Read())
                {
                    result.Add(new DataStack()
                    {
                        UserId = reader.GetInt32(0),
                        CardId = reader.GetString(1),
                        StackType = reader.GetString(2),
                    });
                }
            return result;
        }

        internal void Update(DataStack stack)
        {
            if (stack.UserId == null || stack.CardId == null)
                throw new ArgumentException("Ids must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "UPDATE stacks SET userid=@userid, cardid=@cardid, stacktype=@stacktype WHERE userid=@userid and cardid=@cardid";
            AddParameterWithValue(command, "userid", DbType.Int32, stack.UserId ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid", DbType.String, stack.CardId ?? (object)DBNull.Value);
            AddParameterWithValue(command, "stacktype", DbType.String, stack.StackType ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
        }

        internal void Delete(DataStack stack)
        {
            if (stack.UserId == null || stack.CardId == null)
                throw new ArgumentException("Ids must not be null");

            using IDbConnection connection = new NpgsqlConnection(connectionString);
            using IDbCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "DELETE FROM stacks WHERE userid=@userid AND cardid=@cardid";
            AddParameterWithValue(command, "userid", DbType.Int32, stack.UserId ?? (object)DBNull.Value);
            AddParameterWithValue(command, "cardid", DbType.String, stack.CardId ?? (object)DBNull.Value);
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
