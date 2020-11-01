using SocialNetwork.Database;
using System;
using System.Data.SqlClient;

namespace TestingDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var datasource = @".\SQLEXPRESS";//your server
            var database = "SocialNetworkDB"; //your database name

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

                conn.Database.
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
