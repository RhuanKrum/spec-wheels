using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SpecWheels.Models.TEMP_DELETE
{
    public class TemplateDataAccess
    {
        public string connectionString = ".\\SQLEXPRESS; Initial-Catalog=YourDBName; Integrated-Security=true";
        public void CreateSomething(TemplateModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "insert into Names values(@Name)";
                command.Parameters.AddWithValue("@Name", model.Name);
                command.ExecuteNonQuery();
            }
        }

        public TemplateModel FindSomething(int id)
        {
            var model = new TemplateModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "select * from Names where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                model.Id = id;
                model.Name = reader["Name"].ToString();
            }
            return model;
        }

        public void DeleteSomething(TemplateModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "delete from Names where Id=@Id";
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        public void EditSomething(TemplateModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "Update Names set Name=@Name where Id=@Id";
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}