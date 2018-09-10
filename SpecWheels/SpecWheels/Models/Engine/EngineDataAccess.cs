using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Engine
{
    public class EngineDataAccess
    {
        public string connectionString;

        public EngineDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (EngineModel model)
        {
            String sql = "insert into [Engine] (brand, Name, horsePower) values (@Brand, @Name, @HorsePower)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@HorsePower", model.HorsePower);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public EngineModel Read (int id)
        {
            EngineModel model = null;

            String sql = "select Name,brand,HorsePower from [Engine] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new EngineModel();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.HorsePower = reader["HorsePower"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Engine] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (EngineModel model)
        {
            String sql = "Update [Engine] set Name=@Name,Brand=@Brand,HorsePower=@HorsePower where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@HorsePower", model.HorsePower);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<EngineModel> List()
        {
            List<EngineModel> EngineList = new List<EngineModel>();

            String sql = "select Id, Name, Brand, HorsePower from [Engine]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    EngineModel model = new EngineModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["Brand"].ToString();
                    model.HorsePower = reader["HorsePower"].ToString();

                    EngineList.Add(model);
                }

                return EngineList;
            }
        }
    }
}