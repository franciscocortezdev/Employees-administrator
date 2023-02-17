using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAdministrator.DataLayer
{
    public class Departament
    {
        public List<BusinessLayer.Departament> GetDepartaments()
        {
            List<BusinessLayer.Departament> listDepartaments = new List<BusinessLayer.Departament>();
            string query = "SELECT * FROM Departaments";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();

                        using (var reader = command.ExecuteReader())
                        {

                            while(reader.Read()) 
                            {
                                listDepartaments.Add(new BusinessLayer.Departament
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                });
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message}");
                    }
                }
            }
            return listDepartaments;
        }

        public void InsertDepartament(BusinessLayer.Departament departament)
        {
            string query = "INSERT INTO Departaments (Name) VALUES (@Name)";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Name", departament.Name));
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message}");
                    }
                }
            }
        }

        public void UpdateDepartament(BusinessLayer.Departament departament)
        {
            string query = "UPDATE Departaments SET Name = @Name WHERE Id = @Id";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Name", departament.Name));
                        command.Parameters.Add(new SqlParameter("@Id", departament.Id));
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: {ex.Message}");
                    }
                }
            }
        }

        public void DeleteDepartament(BusinessLayer.Departament departament)
        {
            string query = "DELETE FROM Departaments WHERE Id=@Id";

            using (SqlConnection ConnetionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, ConnetionDB))
                {
                    try
                    {
                        ConnetionDB.Open();
                        command.Parameters.Add(new SqlParameter("@Id", departament.Id));
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
