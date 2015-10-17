using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetIntro
{
    class Program
    {
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\Users\Thomas\Git Repositories\Github\FH-Hagenberg\C-Sharp\20151017_lab_4\uebung04_dataaccess\PhoneTariff.mdf;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                // Open connection 
                dbConnection.Open();

                SqlCommand cmd = new SqlCommand("select * from Tariff", dbConnection);
                
                // Returns a reader which allows iteration over resultset
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Name"]);
                    }
                }

            } // calls dispose before block leaves
            
        }
    }
}
