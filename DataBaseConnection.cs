using System.Data.Common;
using System.Data.SqlClient;


namespace Autotests
{
    public class DataBaseConnection
    {
        private static readonly string connectionString = "Server = 13.233.48.253; Database = MPulseERP; User Id = mpulse; password = MPul53p@$$";

        private DbConnection _connection;
        public DbConnection Connection => _connection;

        public DataBaseConnection()
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
