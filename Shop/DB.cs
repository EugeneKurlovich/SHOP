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
                         
                if (reader.HasRows)
                {
                    ProductsList.prodList.Clear();
                    while (reader.Read())
                    {
                        ProductsList pl = new ProductsList(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3),
                        reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
                        ProductsList.prodList.Add(pl);
                    }
                }
                reader.Close();

            }
        }

        public void getAllEmployee()
        {
            using (SqlCommand cmd = new SqlCommand("selectEmployee", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    EmployeeList.emplList.Clear();
                    while (reader.Read())
                    {
                        EmployeeList el = new EmployeeList(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetDouble(6));
                        EmployeeList.emplList.Add(el);
                    }
                }
                reader.Close();
            }            
        }

        public void deleteEmplId(int id)
        {
            using (SqlCommand cmd = new SqlCommand("deleteEmployeeId", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void updateEmployee(int id, string name, string surname, string post, string log, string pass, double salary)
        {
            using (SqlCommand cmd = new SqlCommand("updateEmployeeId", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@name_employee", name);
                cmd.Parameters.AddWithValue("@surname_employee", surname);
                cmd.Parameters.AddWithValue("@post", post);
                cmd.Parameters.AddWithValue("@empl_login", log);
                cmd.Parameters.AddWithValue("@empl_passw", pass);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.ExecuteNonQuery();
            }
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



