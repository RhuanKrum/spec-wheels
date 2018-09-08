using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Color
{
    public class ColorDataAccess
    {
        public string connectionString;

        public ColorDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (ColorModel model)
        {
            String sql = "insert into [Color] (Name) values (@Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public ColorModel Read (int id)
        {
            ColorModel model = null;

            String sql = "select Name from [Color] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new ColorModel();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Color] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (ColorModel model)
        {
            String sql = "Update [Color] set Name=@Name where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<ColorModel> List()
        {
            List<ColorModel> ColorList = new List<ColorModel>();

            String sql = "select Id, Name from [Color]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    ColorModel model = new ColorModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();

                    ColorList.Add(model);
                }

                return ColorList;
            }
        }
    }
}