using System;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace SQL_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Отримати об'єкт Connection пфдключений до DB
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //Закрити з'єднання
                conn.Close();
                //Знищити об'єкт, звільнити ресурс
                conn.Dispose();
            }
            Console.Read();
        }

        public static void QueryEmployee(MySqlConnection conn)
        {
            string id, name, country;
            string sql = "Select Code, Name, Continent from country";

            //Створити об'єкт Command
            MySqlCommand cmd = new MySqlCommand();

            //Поєднувати Command з Connection
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["Code"].ToString();
                        name = reader["Name"].ToString();
                        country = reader["Continent"].ToString();
                        Console.WriteLine("___________________________________");
                        Console.WriteLine("Код: " + id + " Назва: " + name + " Континент: " + country);
                        Console.WriteLine("___________________________________");
                    }
                }
            }
        }
    }
}