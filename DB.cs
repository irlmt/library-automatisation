using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace curse
{
    class DB
    {
        static private string GetCon()
        {
            try
            {
                // Укажите путь к файлу с вашей строкой подключения
                string filePath = "C:\\Users\\User\\Desktop\\labs\\db\\WindowsFormsApp3\\WindowsFormsApp3\\db.config";

                string connectionString = File.ReadAllText(filePath);
                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return "";
            }
        }

        MySqlConnection connection = new MySqlConnection(GetCon());
        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed) {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
