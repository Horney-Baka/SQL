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
            string sqlQuery2 = "SELECT * FROM VideoCard";

            sqlConnection.Open();

            SqlCommand command = new SqlCommand(sqlQuery1, sqlConnection);
            SqlCommand command1 = new SqlCommand(sqlQuery2, sqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
            {




                string columnName1 = reader.GetName(0);
                string columnName4 = reader.GetName(2);




                Console.WriteLine($"{columnName1}\t\t{columnName4}");

                for (int i = 0; reader.Read(); i++)
                {

                    for (int j = 0; j < 1; j++)
                    {
                        CPU[i, j] = Convert.ToString(reader.GetInt32(0));
                        CPU[i, j + 1] = reader.GetString(2);
                        Console.WriteLine(CPU[i, j] + "\t\t" + CPU[i, j + 1]);
                    }

                }
                Console.WriteLine("Я валера");
            }
            using (SqlDataReader reader = command1.ExecuteReader())
            {
                string[,] arr1 = new string[2, 2];
                Console.WriteLine("Введите первую видеокарту");
                arr1[0, 1] = Console.ReadLine();
                Console.WriteLine("Введите первую видеокарту");
                arr1[1, 1] = Console.ReadLine();



                for (int i = 0; reader.Read(); i++)
                {
                    if (reader.GetString(2) == arr1[0, 1])
                    {
                        arr1[0, 0] = Convert.ToString(reader.GetInt32(0));
                    }
                    if (reader.GetString(2) == arr1[1, 1])
                    {
                        arr1[1, 0] = Convert.ToString(reader.GetInt32(0));
                    }
                }
                Console.WriteLine(arr1[0, 0] + " " + arr1[1, 0]);
                if(Convert.ToInt32(arr1[0, 0]) < Convert.ToInt32(arr1[1, 0]))
                {
                    Console.WriteLine(arr1[0, 1]);
                }
                else
                {
                    Console.WriteLine(arr1[1,1]);
                }
            }
               


            

        }
        
    }
}
