using EmployeeAdministrator.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAdministrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDepartaments departaments= new frmDepartaments();
            departaments.ShowDialog();
            this.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployees employees = new frmEmployees();
            employees.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
