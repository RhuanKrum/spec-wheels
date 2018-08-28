using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace SpecWheels.Models.Break
{
    public class BreakDataAccess
    {
        public string appPath;
        public string connectionString;

        //public string connectionString = @".\SQLEXPRESS; Initial Catalog=SpecWheels; Integrated Security=true";

        public BreakDataAccess()
        {
            appPath = @"C:\Users\daian\source\repos\spec-wheels\SpecWheels\SpecWheels\App_Data";
            connectionString = @"Data Source=DAYAPC\SQLEXPRESS;AttachDbFilename=" + @appPath + @"\SpecWheels.mdf;Initial Catalog=SpecWheels;Integrated Security=True; User Instance=TRUE";

        }

        public bool Create (BreakModel model)
        {
            String sql = "insert into Break (brand, Name, Size, Type) values (@Brand, @Name, @Size, @Type)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
                command.Parameters.AddWithValue("@Type", model.Type);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public BreakModel Read (int id)
        {
            var model = new BreakModel();

            String sql = "select brand, Name, Size, Type from Break where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                model.Id = id;
                model.Name = reader["Name"].ToString();
                model.Brand = reader["brand"].ToString();
                model.Size = reader["Size"].ToString();
                model.Type = reader["Type"].ToString();
            }

            return model;
        }

        public void Delete (BreakModel model)
        {
            String sql = "delete from Break where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
               
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (BreakModel model)
        {
            String sql = "Update Break set Brand=@Brand, Name=@Name, Size=@Size, Type=@Type where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
                command.Parameters.AddWithValue("@Type", model.Type);
                command.ExecuteNonQuery();
            }
        }
    }
}