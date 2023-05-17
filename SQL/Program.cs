using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace SQL
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
            if (sqlConnection.State == ConnectionState.Open)
            {
                Console.WriteLine("Козырно");
            }
            Console.WriteLine(sqlConnection.Database);
            string sqlQuery1 = "SELECT * FROM CPU";

             sqlConnection.Open();

            SqlCommand command = new SqlCommand(sqlQuery1, sqlConnection);
            SqlDataReader reader =  command.ExecuteReader();

            if(reader.HasRows)
            {
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);
                string columnName4 = reader.GetName(3);
                string columnName5 = reader.GetName(4);
                string columnName6 = reader.GetName(5);


                Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}\t{columnName4}\t{columnName5}\t{columnName6}");

                while (reader.Read())
                {
                    object ID_CPU = reader.GetValue(0);
                    object ID_Manufacturer = reader.GetValue(1);
                    object Name = reader.GetValue(2);
                    object Number_of_Cores = reader.GetValue(3);
                    object Core_Frequency = reader.GetValue(4);
                    object Number_of_Threads = reader.GetValue(5);

                    Console.WriteLine($"{ID_CPU} \t {ID_Manufacturer} \t {Name} \t {Number_of_Cores} \t {Core_Frequency} \t {Number_of_Threads}");
                }
            }

        }
    }
}
