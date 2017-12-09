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
        static string connStr = @"Data Source=EUGENEPC;Initial Catalog=StoreDB;Integrated Security=True";
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
                        pl.id = reader.GetInt32(0);
                        pl.name = reader.GetString(1);
                        pl.price = reader.GetDouble(2);
                        pl.description = reader.GetString(3);
                        pl.ammount = reader.GetInt32(4);
                        pl.category = reader.GetString(5);
                        pl.nameProducer = reader.GetString(6);
                        ProductsList.prodList.Add(pl);
                    }
                }
                reader.Close();

            }
        }

        public void getAllEmployee()
        {
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

               EmployeeList el = new EmployeeList();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                    el.id = reader.GetInt32(0);
                    el.name = reader.GetString(1);
                    el.surname = reader.GetString(2);
                    el.post = reader.GetString(3);
                    el.login = reader.GetString(4);
                    el.password = reader.GetString(5);
                    el.salary = reader.GetDouble(6);

                    EmployeeList.emplList.Add(el);
                    }
                }
                reader.Close();

            
        }

        public void addEmploye(string nameEmpl, string surnameEmpl, string post,string log, string pass, double salary)
        {
            using (SqlCommand cmd = new SqlCommand("addNewEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name_employee", nameEmpl);
                cmd.Parameters.AddWithValue("@surname_employee", surnameEmpl);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.ExecuteNonQuery();
            }

        }
    }
}



