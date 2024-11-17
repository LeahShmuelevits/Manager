using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.Design;

namespace Manager
{
    internal class DataAccess
    {
       

  string response;
        public int insertDataProduct(string connectionString)
        {
            string response = "y";
            int rowsAffected = 0;
            string ProductName, Description, Image, Price, Category_id;
            bool flag = true;
            while (response == "y")
            {
                Console.WriteLine("insert ProductName");
                ProductName = Console.ReadLine();
                Console.WriteLine("insert Description");
                Description = Console.ReadLine();
                Console.WriteLine("insert Category_id");
                Category_id = Console.ReadLine();
                Console.WriteLine("insert Price");
                Price = Console.ReadLine();
                Console.WriteLine("insert Image");
                Image = Console.ReadLine();

                Console.WriteLine("do you want to contuine");
                response = Console.ReadLine();
                string query = "INSERT INTO Product(ProductName,Description,Category_id,Price,Image)" +
                    "VALUES(@ProductName,@Description,@Category_id,@Price,@Image)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {

                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                    cmd.Parameters.Add("@Category_id", SqlDbType.VarChar).Value = Category_id;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = Price;
                    cmd.Parameters.Add("@Image", SqlDbType.VarChar).Value = Image;


                    cn.Open();
                     rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();
                    flag = response == "y" ? true : false;
                }
            }
            return rowsAffected;

        }


        public int insertDataCategory(string connectionString)
        {
            string response = "y";
            int rowsAffected = 0;
            string CategoryName;
            bool flag = true;
            while (response == "y")
            {
                Console.WriteLine("insert CategoryName");
                CategoryName = Console.ReadLine();
                Console.WriteLine("do you want to contuine");
                response = Console.ReadLine();
                string query = "INSERT INTO Category(CategoryName)" +
                "VALUES(@CategoryName)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = CategoryName;

                    cn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();
                    flag = response == "y" ? true : false;

                }
            }
            return rowsAffected;
        }

        internal void readDataProduct(string connectionString)
        {
            string queryString = "select * from Product";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }

        internal void readDataCategory(string connectionString)
        {
            string queryString = "select * from Category";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
