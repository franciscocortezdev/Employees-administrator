using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdministrator.BusinessLayer
{
    public class Employee
    {
        DataLayer.Employee _dataLayerEmployee;

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Departament { get; set; }
        public byte[] Photo { get; set; }

        public Employee()
        {
            _dataLayerEmployee = new DataLayer.Employee();
        }


        public List<Employee> GetEmployees()
        {
            return _dataLayerEmployee.GetEmployees();
        }

        public void InsertDepartaments(Employee employee)
        {
            _dataLayerEmployee.InsertEmployee(employee);
        }
        public void UpdateDepartaments(Employee employee)
        {
            _dataLayerEmployee.UpdateEmployee(employee);
        }
        public void DeleteDepartaments(Employee employee)
        {
            _dataLayerEmployee.DeleteEmployee(employee);
        }
    }
}
