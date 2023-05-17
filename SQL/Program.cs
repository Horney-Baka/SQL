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
            string[,] CPU = new string[22, 2]; 
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
                string columnName4 = reader.GetName(2);
                

                

                Console.WriteLine($"{columnName1}\t\t{columnName4}");

                for(int i = 0; reader.Read();i++)
                {
                    
                    for(int j = 0; j<1;j++)
                    {
                        CPU[i, j] = Convert.ToString (reader.GetInt32(0));
                        CPU[i, j+1] = reader.GetString(2);
                        Console.WriteLine(CPU[i, j] + "\t\t" + CPU[i, j + 1]);
                    }
                    
                }
                Console.WriteLine("Я валера");
            }

        }
    }
}
