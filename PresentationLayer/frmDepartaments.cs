using EmployeeAdministrator.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAdministrator.PresentationLayer
{
    public partial class frmDepartaments : Form
    {
        Departament _businessLayerDepartament;
        public frmDepartaments()
        {
            InitializeComponent();
            _businessLayerDepartament= new Departament();
        }

        #region Events of Form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDepartamentName.Text == string.Empty)
            {
                ErrorNotification.SetError(txtDepartamentName, "Empty data is not allowed");
                return;
            }
            var newDepartament = getDataForm();
            _businessLayerDepartament.InsertDepartaments(newDepartament);
            PopulateDataGrid();
            CleanForm();
        }

        private void frmDepartaments_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var DepartamentSelected = getDataForm();
            _businessLayerDepartament.DeleteDepartaments(DepartamentSelected);
            PopulateDataGrid();
            CleanForm();
            SaveMode();

        }

        private void dgvDepartaments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = dgvDepartaments.Rows[dgvDepartaments.CurrentRow.Index].Cells[0].Value.ToString();
            txtDepartamentName.Text = dgvDepartaments.Rows[dgvDepartaments.CurrentRow.Index].Cells[1].Value.ToString();
            EditMode();
        }
     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveMode();
            CleanForm();
        }

        #endregion



        private void PopulateDataGrid()
        {
            List<Departament> ListDepartaments = _businessLayerDepartament.GetDepartaments();
            dgvDepartaments.DataSource = ListDepartaments;
        }

        private Departament getDataForm()
        {
            Departament newDepartament = new Departament();
            newDepartament.Id = txtCode.Text != string.Empty? int.Parse(txtCode.Text): default;
            newDepartament.Name = txtDepartamentName.Text;
            return newDepartament;
        }

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
            txtDepartamentName.Text = string.Empty;
            ErrorNotification.Clear();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var newDepartament = getDataForm();
            _businessLayerDepartament.UpdateDepartaments(newDepartament);
            PopulateDataGrid();
            CleanForm();
            SaveMode();
        }
    }
}
