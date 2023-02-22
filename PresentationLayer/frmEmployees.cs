using EmployeeAdministrator.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAdministrator.PresentationLayer
{
    public partial class frmEmployees : Form
    {
        Employee _businessLayerEmployee;
        Departament _businessLayerDepartament;

        public frmEmployees()
        {
            InitializeComponent();
            _businessLayerEmployee = new Employee();
            _businessLayerDepartament = new Departament();

        }

        #region Events of Form
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
            PopulateComboBox();

           
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee employee = dgvEmployee.CurrentRow.DataBoundItem as Employee;
            ImageConverter imgConverter = new ImageConverter();

            txtCode.Text = employee.Id.ToString();
            txtName.Text = employee.Name;
            txtLastName.Text = employee.LastName;
            txtEmail.Text = employee.Email;
            picPhoto.Image = employee.Photo != null ? (Image)imgConverter.ConvertFrom(employee.Photo) : null;

            EditMode();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode();
            CleanForm();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdPhoto.ShowDialog() == DialogResult.OK)
            {
                picPhoto.Image = new Bitmap(ofdPhoto.FileName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                ErrorProvEmployee.SetError(txtName, "Empty data is not allowed");
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                ErrorProvEmployee.SetError(txtName, "Empty data is not allowed");
                return;
            }

            var newEmployee = getDataForm();
            _businessLayerEmployee.InsertEmployee(newEmployee);
            PopulateDataGrid();
            CleanForm();
        }


        #endregion

        

        private void EditMode()
        {
            btnAdd.Enabled = false;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void SaveMode()
        {
            btnAdd.Enabled = true;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void CleanForm()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbxDepartament.SelectedIndex = -1;
            picPhoto.Image= null;
        }

        private void PopulateDataGrid()
        {
            List<Employee> ListEmployees = _businessLayerEmployee.GetEmployees();
            dgvEmployee.DataSource = ListEmployees;
        }

        private void PopulateComboBox()
        {
            List<Departament> ListDepartaments = _businessLayerDepartament.GetDepartaments();

            cbxDepartament.DataSource = ListDepartaments;
            cbxDepartament.ValueMember = "id";
            cbxDepartament.DisplayMember = "Name";
            cbxDepartament.SelectedItem = null;
        }

        private Employee getDataForm()
        {
            ImageConverter imgConverter = new ImageConverter();
            Employee newEmployee = new Employee();
            newEmployee.Id = txtCode.Text != string.Empty ? int.Parse(txtCode.Text) : default;
            newEmployee.Name = txtName.Text;
            newEmployee.LastName = txtLastName.Text;
            newEmployee.Email = txtEmail.Text;
            newEmployee.Photo = picPhoto.Image != null ? (byte[])imgConverter.ConvertTo(picPhoto.Image, typeof(byte[])) : null;


            return newEmployee;
        }


       


    }
}
