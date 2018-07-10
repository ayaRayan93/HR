using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR
{
    public partial class EmployeeConnectionInfo : Form
    {
        MySqlConnection dbconnection;
        HRMainForm HRMainForm;
        public EmployeeConnectionInfo(HRMainForm HRMainForm)
        {
            try
            {
                InitializeComponent();
                dbconnection = new MySqlConnection(connection.connectionString);
                this.HRMainForm = HRMainForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void EmployeeConnectionInfo_Load(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                displayEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbconnection.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                HRMainForm.bindReport3EmployeesForm(gridControl1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //function
        //display all employee
        public void displayEmployee()
        {
            string query = "select Employee_ID, Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف',Employee_Phone as 'التلفون',Employee_Address as 'العنوان',Employee_Mail as 'البريد الالكتروني' from employee ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            gridControl1.DataSource = dataSet.Tables[0];
            gridView1.Columns[0].Visible = false;
        }

      
    }
}
