using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Commander.Entities
{
    class Database
    {
        internal static List<Item> LoadAll()
        {
            var quotes = new List<Item>();
            (MySqlDataReader dr, MySqlConnection conn) reader = Database1.ExecuteReader("SELECT * FROM smstest;");

            while (reader.dr.Read())
            {
                var q = new Item
                {
                    jobid = reader.dr.GetString("jobid"),
                    description = reader.dr.GetString("customer")
                };
                quotes.Add(q);
            }
            reader.dr.Close();
            reader.conn.Close();
            return quotes;
        }
    }
}
