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
            txtStudentNo.KeyPress += txtStudentNo_KeyPress;
            txtFirstName.KeyPress += txtName_KeyPress;
            txtLastName.KeyPress += txtName_KeyPress;
            txtMiddleName.KeyPress += txtName_KeyPress;
            txtAge.KeyPress += txtAge_KeyPress;
            txtAge.TextChanged += txtAge_TextChanged;
            txtContactNo.KeyPress += txtContactNo_KeyPress;
            txtContactNo.TextChanged += txtContactNo_TextChanged;
        }

        // We add some validations for better system's flow
        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers 
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters and Roman numerals for last,first and middle names
            if (!char.IsLetter(e.KeyChar) && !IsRomanNumeral(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            // Limit to 3 digits cause no one has reach thousand
            if (txtAge.Text.Length > 3)
            {
                txtAge.Text = txtAge.Text.Substring(0, 3);
                txtAge.SelectionStart = txtAge.Text.Length;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers cause there is no a letters contact
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            // Limit to 11 digits
            if (txtContactNo.Text.Length > 11)
            {
                txtContactNo.Text = txtContactNo.Text.Substring(0, 11);
                txtContactNo.SelectionStart = txtContactNo.Text.Length;
            }
        }

        private bool IsRomanNumeral(char c)
        {
            // Check if the character is a Roman numeral for names who has number
            return "IVXLCDM".IndexOf(char.ToUpper(c)) >= 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (ValidateFields())
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
            else
            {
                MessageBox.Show("Please fill out all fields correctly before proceeding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check if fields are valid
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
            {
                MessageBox.Show("Middle Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a program.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAge.Text) || txtAge.Text.Length > 3)
            {
                MessageBox.Show("Please enter a valid age (up to 3 digits).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNo.Text) || txtContactNo.Text.Length != 11)
            {
                MessageBox.Show("Contact Number must be exactly 11 digits.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentNo.Text))
            {
                MessageBox.Show("Student Number is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}

