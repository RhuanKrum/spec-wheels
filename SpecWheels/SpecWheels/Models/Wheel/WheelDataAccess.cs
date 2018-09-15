using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Wheel
{
    public class WheelDataAccess
    {
        public string connectionString;

        public WheelDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (WheelModel model)
        {
            String sql = "insert into [Wheel] (brand, Name, Size, Color) values (@Brand, @Name, @Size, @Color)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
                command.Parameters.AddWithValue("@Color", model.Color);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public WheelModel Read (int id)
        {
            WheelModel model = null;

            String sql = "select brand, Name, Size, Color from [Wheel] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new WheelModel();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Color = reader["Color"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Wheel] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (WheelModel model)
        {
            String sql = "Update [Wheel] set Brand=@Brand, Name=@Name, Size=@Size, Color=@Color where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Size", model.Size);
                command.Parameters.AddWithValue("@Color", model.Color);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<WheelModel> List()
        {
            List<WheelModel> WheelList = new List<WheelModel>();

            String sql = "select Id, Brand, Name, size, Color from [Wheel]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    WheelModel model = new WheelModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Color = reader["Color"].ToString();

                    WheelList.Add(model);
                }

                return WheelList;
            }
        }

    }
}