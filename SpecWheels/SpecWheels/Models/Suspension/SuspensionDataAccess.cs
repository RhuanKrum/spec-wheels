using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.Suspension
{
    public class SuspensionDataAccess
    {
        public string connectionString;

        public SuspensionDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (SuspensionModel model)
        {
            String sql = "insert into [Suspension] (brand, Name) values (@Brand, @Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public SuspensionModel Read (int id)
        {
            SuspensionModel model = null;

            String sql = "select brand, Name from [Suspension] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new SuspensionModel();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [Suspension] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (SuspensionModel model)
        {
            String sql = "Update [Suspension] set Brand=@Brand, Name=@Name where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Brand", model.Brand);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<SuspensionModel> List()
        {
            List<SuspensionModel> SuspensionList = new List<SuspensionModel>();

            String sql = "select Id, Brand, Name from [Suspension]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    SuspensionModel model = new SuspensionModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Name = reader["Name"].ToString();
                    model.Brand = reader["brand"].ToString();

                    SuspensionList.Add(model);
                }

                return SuspensionList;
            }
        }
    }
}