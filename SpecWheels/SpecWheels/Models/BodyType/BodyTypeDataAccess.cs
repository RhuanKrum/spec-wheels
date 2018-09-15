using System;
using System.Linq;
using System.Data.SqlClient;

using System.Web;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Collections.Generic;

namespace SpecWheels.Models.BodyType
{
    public class BodyTypeDataAccess
    {
        public string connectionString;

        public BodyTypeDataAccess()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["SpecWheelsConnection"];

            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new NullReferenceException("Fatal error: missing connecting string in web.config file");

            connectionString = mySetting.ConnectionString;
        }

        public bool Create (BodyTypeModel model)
        {
            String sql = "insert into [BodyType] (Description) values (@Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public BodyTypeModel Read (int id)
        {
            BodyTypeModel model = null;

            String sql = "select Description from [BodyType] where Id=@Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    model = new BodyTypeModel();
                    model.Id = id;
                    model.Description = reader["Description"].ToString();
                }
            }

            return model;
        }

        public void Delete (int id)
        {
            String sql = "delete from [BodyType] where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update (BodyTypeModel model)
        {
            String sql = "Update [BodyType] set Description=@Description where Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<BodyTypeModel> List()
        {
            List<BodyTypeModel> BodyTypeList = new List<BodyTypeModel>();

            String sql = "select Id, Description from [BodyType]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    BodyTypeModel model = new BodyTypeModel();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Description = reader["Description"].ToString();

                    BodyTypeList.Add(model);
                }

                return BodyTypeList;
            }
        }

    }
}