using Angular.NET.Enums;
using Npgsql;
using System.Data.Common;
using System.Data.SqlClient;

namespace Angular.NET.Data
{
    public class ConnectionFactory
    {
        public static Logger<ConnectionFactory> _logger;

        public ConnectionFactory(Logger<ConnectionFactory> logger)
        {
            _logger = logger;
        }

        public static DbConnection GetConnection(ConnectionTypes type, String connectionString)
        {
            DbConnection _connection;

            if (type == ConnectionTypes.POSTGRESQL)
            {
                _connection = new NpgsqlConnection(connectionString);
            }
            else if (type == ConnectionTypes.SQLSERVER)
            {
                _connection = new SqlConnection(connectionString);
            }
            else
            {
                _connection = null;
            }

            return _connection;
        }
        public static DbCommand GetCommandCom(string query, DbConnection conn)
        {
            DbCommand cmd;
            if (conn is NpgsqlConnection nc)
            {
                cmd = new NpgsqlCommand(query, nc);
                return cmd;
            }
            else if (conn is SqlConnection sc)
            {
                cmd = new SqlCommand(query, sc);
                return cmd;
            }
            else
            {
                return null;
            }
        }
        public static int CloseConnection(DbConnection conn)
        {
            conn.Close();
            return (0);
        }

        public static int OpenConnection(DbConnection conn)
        {
            conn.Open();
            return (1);
        }
    }
}
