using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentInfoClass;

namespace AccountRegistration
{
    public delegate string DelegateText();
    public delegate long DelegateNumber();

    public partial class FrmConfirm : Form
    {
        private DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;
        private DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        public FrmConfirm()
        {
            InitializeComponent();

            DelProgram = new DelegateText(StudentInfoClass.GetProgram);
            DelLastName = new DelegateText(StudentInfoClass.GetLastName);
            DelFirstName = new DelegateText(StudentInfoClass.GetFirstName);
            DelMiddleName = new DelegateText(StudentInfoClass.GetMiddleName);
            DelAddress = new DelegateText(StudentInfoClass.GetAddress);
            DelNumAge = new DelegateNumber(StudentInfoClass.GetAge);
            DelNumContactNo = new DelegateNumber(StudentInfoClass.GetContactNo);
            DelStudNo = new DelegateNumber(StudentInfoClass.GetStudentNo);
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            lblProgram.Text = "Program: " + DelProgram();
            lblLastName.Text = "Last Name: " + DelLastName();
            lblFirstName.Text = "First Name: " + DelFirstName();
            lblMiddleName.Text = "Middle Name: " + DelMiddleName();
            lblAddress.Text = "Address: " + DelAddress();
            lblAge.Text = "Age:" + DelNumAge().ToString();
            lblContactNo.Text = "Contact No: " +DelNumContactNo().ToString();
            lblStudentNo.Text = "Student No: " +DelStudNo().ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }

    public static class StudentInfoClass
    {
        public static string FirstName = " ";
        public static string LastName = " ";
        public static string MiddleName = " ";
        public static string Address = " ";
        public static string Program = " ";
        public static long Age = 0;
        public static long ContactNo = 0;
        public static long StudentNo = 0;

        public static string GetFirstName() => FirstName;
        public static string GetLastName() => LastName;
        public static string GetMiddleName() => MiddleName;
        public static string GetAddress() => Address;
        public static string GetProgram() => Program;
        public static long GetAge() => Age;
        public static long GetContactNo() => ContactNo;
        public static long GetStudentNo() => StudentNo;
    }
}
