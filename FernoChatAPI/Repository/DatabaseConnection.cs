using System.Data.SqlClient;

namespace FernoChatAPI.Repository
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PrimaryConnection");
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
