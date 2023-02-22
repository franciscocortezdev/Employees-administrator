using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAdministrator.DataLayer
{
    public class Employee
    {

        public List<BusinessLayer.Employee> GetEmployees()
        {
            List<BusinessLayer.Employee> listEmployees = new List<BusinessLayer.Employee>();
            string query = "SELECT * FROM Employees";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                listEmployees.Add(new BusinessLayer.Employee
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    LastName= reader.GetString(2),
                                    Email= reader.GetString(3),
                                    Photo = !reader.IsDBNull(4) ? (byte[])reader.GetValue(4) : null
                                });
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.StackTrace} Message: {ex.Message}");
                    }
                }
            }
            return listEmployees;
        }

        public void InsertEmployee(BusinessLayer.Employee employee)
        {
            string query = "INSERT INTO Employees (Name, LastName, Email, Photo) VALUES (@Name, @LastName, @Email, @Photo)";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Name", employee.Name));
                        command.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
                        command.Parameters.Add(new SqlParameter("@Email", employee.Email));

                        command.Parameters.Add("@Photo", SqlDbType.Image).Value = (object)employee.Photo ?? DBNull.Value;

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message} Route: {ex.StackTrace}");
                    }
                }
            }
        }

        public void UpdateEmployee(BusinessLayer.Employee employee)
        {
            string query = "UPDATE Employees SET Name = @Name WHERE Id = @Id";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Name", employee.Name));
                        command.Parameters.Add(new SqlParameter("@Id", employee.Id));
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteEmployee(BusinessLayer.Employee employee)
        {
            string query = "DELETE FROM Employees WHERE Id=@Id";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Id", employee.Id));
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message}");
                    }
                }
            }
        }

    }
}
