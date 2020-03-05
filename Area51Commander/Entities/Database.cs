using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Entities
{
    class Database1
    {
        internal static (MySqlDataReader, MySqlConnection) ExecuteReader(string query)
        {
            MySqlConnection conn = GetDatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            try
            {
                return (cmd.ExecuteReader(), conn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        private static MySqlConnection GetDatabaseConnection()
        {
            string connectionString = "Server=localhost;Database=sms;Uid=solent_sms;Pwd=Ch8nG399*2019!";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
