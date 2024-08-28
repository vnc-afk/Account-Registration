using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountRegistration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            StudentInfoClass.FirstName = txtFirstName.Text.ToString();
            StudentInfoClass.LastName = txtLastName.Text.ToString();
            StudentInfoClass.MiddleName = txtMiddleName.Text.ToString();
            StudentInfoClass.Address = txtAddress.Text.ToString();
            StudentInfoClass.Program = comboBoxProgram.Text.ToString();
            StudentInfoClass.Age = long.Parse(txtAge.Text.ToString());
            StudentInfoClass.ContactNo = long.Parse(txtContactNo.Text.ToString());
            StudentInfoClass.StudentNo = long.Parse(txtStudentNo.Text.ToString());

            FrmConfirm confirmForm = new FrmConfirm();
            var result = confirmForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleName.Clear();
                txtAddress.Clear();
                comboBoxProgram.SelectedIndex = -1;
                txtAge.Clear();
                txtContactNo.Clear();
                txtStudentNo.Clear();
            }
        }
    }
}

