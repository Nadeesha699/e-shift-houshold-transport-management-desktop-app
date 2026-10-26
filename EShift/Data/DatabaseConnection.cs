
using System;
using MySql.Data.MySqlClient;

namespace EShift
{
    public class DatabaseConnection
    {
        private static readonly string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=eshift_db;" +
            "Uid=root;" +
            "Pwd=;" +
            "SslMode=None;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return connection.State ==
                           System.Data.ConnectionState.Open;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(
                    "Database connection failed: " + ex.Message, ex);
            }
        }
    }
}
