using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shop
{
    class DB
    {
        static string connStr = @"Data Source=EUGENEPC;Initial Catalog=SHOP;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(connStr);

        public void openConnection()
        {
            conn.Open();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public void getAllProducts()
        {
            using (SqlCommand cmd = new SqlCommand("selectProducts", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();
               
                ProductsList pl = new ProductsList();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pl.name = reader.GetString(0);
                        pl.price = reader.GetDouble(1);
                        pl.description = reader.GetString(2);
                        ProductsList.prodList.Add(pl);
                    }
                }
                reader.Close();
               
            }
        }

        public void addEmploye(string nameEmpl, string surnameEmpl, DateTime date, string post,string log, string pass)
        {
            using (SqlCommand cmd = new SqlCommand("addNewEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name_employee", nameEmpl);
                cmd.Parameters.AddWithValue("@surname_employee", surnameEmpl);
                cmd.Parameters.AddWithValue("@date_birthday", date);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.ExecuteNonQuery();
            }

        }
    }
}



