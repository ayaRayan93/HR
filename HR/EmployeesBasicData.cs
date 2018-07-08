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
    public partial class EmployeesBasicData : Form
    {
        MySqlConnection dbconnection;
        public EmployeesBasicData()
        {
            InitializeComponent();
            dbconnection = new MySqlConnection(connection.connectionString);
        }

        private void EmployeesBasicData_Load(object sender, EventArgs e)
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

        //function
        //display all employee
        public void displayEmployee()
        {
            string query = "select Employee_ID, Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف',Employee_Start_Date as 'تاريخ بدءالعمل',Branch_Name as 'الفرع',Employee_Job as 'الوظيفة',Employee_Department as 'مكان العمل',EmploymentType as 'نوع التوظيف' from employee inner join branch on employee.Employee_Branch_ID=branch.Branch_ID";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            gridControl1.DataSource = dataSet.Tables[0];
            gridView1.Columns[0].Visible = false;
        }
    }
}
