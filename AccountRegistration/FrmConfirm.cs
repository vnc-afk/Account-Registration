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
    public delegate string DelegateText(string input);
    public delegate long DelegateNumber(long input);

    public partial class FrmConfirm : Form
    {
          private DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;
        private DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
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
            lblProgram.Text = $"Program: {DelProgram(StudentInfoClass.Program)}";
            lblLastName.Text = $"Last Name: {DelLastName(StudentInfoClass.LastName)}";
            lblFirstName.Text = $"First Name: {DelFirstName(StudentInfoClass.FirstName)}";
            lblMiddleName.Text = $"Middle Name: {DelMiddleName(StudentInfoClass.MiddleName)}";
            lblAddress.Text = $"Address: {DelAddress(StudentInfoClass.Address)}";
            lblAge.Text = $"Age: {DelNumAge(StudentInfoClass.Age)}";
            lblContactNo.Text = $"Contact No: {DelNumContactNo(StudentInfoClass.ContactNo)}";
            lblStudentNo.Text = $"Student No: {DelStudNo(StudentInfoClass.StudentNo)}";
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
        public delegate long DelegateNumber(long number);
        public delegate string DelegateText(string txt);


        public static string FirstName = " ";
        public static string LastName = " ";
        public static string MiddleName = " ";
        public static string Address = " ";
        public static string Program = " ";
        public static long Age = 0;
        public static long ContactNo = 0;
        public static long StudentNo = 0;


        public static string GetProgram(string program) => program;
        public static string GetLastName(string lastName) => lastName;
        public static string GetFirstName(string firstName) => firstName;
        public static string GetMiddleName(string middleName) => middleName;
        public static string GetAddress(string address) => address;
        public static long GetAge(long age) => age;
        public static long GetContactNo(long contactNo) => contactNo;
        public static long GetStudentNo(long studentNo) => studentNo;
    }
}
