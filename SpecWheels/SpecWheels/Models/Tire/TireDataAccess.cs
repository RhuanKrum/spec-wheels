using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Tire
{
    public class TireDataAccess
    {
        public string connectionString;

        public TireDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (TireModel model)
        {
            String sql = "insert into [Tire] (brand, Name, Size) values (@Brand, @Name, @Size)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
               
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public TireModel Read (int id)
        {
            TireModel model = null;

            String sql = "select brand, Name, Size from [Tire] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new TireModel();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Tire] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (TireModel model)
        {
            String sql = "Update [TIre] set Brand=@Brand, Name=@Name, Size=@Size where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
               
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<TireModel> List()
        {
            List<TireModel> tireList = new List<TireModel>();

            String sql = "select Id, Brand, Name, size from [Tire]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    TireModel model = new TireModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    

                    tireList.Add(model);
                }

                return tireList;
            }
        }

    }
}