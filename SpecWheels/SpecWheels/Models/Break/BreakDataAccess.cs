using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Break
{
    public class BreakDataAccess
    {
        public string connectionString;

        public BreakDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (BreakModel model)
        {
            String sql = "insert into [Break] (brand, Name, Size, Type) values (@Brand, @Name, @Size, @Type)";

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

            String sql = "select brand, Name, Size, Type from [Break] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) { 
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Type = reader["Type"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Break] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (BreakModel model)
        {
            String sql = "Update [Break] set Brand=@Brand, Name=@Name, Size=@Size, Type=@Type where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
                command.Parameters.AddWithValue("@Type", model.Type);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<BreakModel> List()
        {
            List<BreakModel> breakList = new List<BreakModel>();

            String sql = "select Id, Brand, Name, size, type from [Break]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    BreakModel model = new BreakModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Type = reader["Type"].ToString();

                    breakList.Add(model);
                }

                return breakList;
            }
        }

    }
}