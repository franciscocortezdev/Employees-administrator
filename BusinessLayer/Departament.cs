using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAdministrator.BusinessLayer
{
    public class Departament
    {
        DataLayer.Departament _dataLayerDepartament;
        public int Id { get; set; }
        public string Name { get; set; }

        public Departament()
        {
            _dataLayerDepartament= new DataLayer.Departament();
        }

        public List<Departament> GetDepartaments()
        {
            return _dataLayerDepartament.GetDepartaments();
        }

        public void InsertDepartaments(Departament dep)
        {
           _dataLayerDepartament.InsertDepartament(dep);
        }
        public void UpdateDepartaments(Departament dep)
        {
            _dataLayerDepartament.UpdateDepartament(dep);
        }
        public void DeleteDepartaments(Departament dep)
        {
            _dataLayerDepartament.DeleteDepartament(dep);
        }
    }
}
