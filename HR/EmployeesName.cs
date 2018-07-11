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
    public partial class EmployeesName : Form
    {
        MySqlConnection dbconnection;
        HRMainForm HRMainForm;
        public EmployeesName(HRMainForm HRMainForm)
        {
            InitializeComponent();
            dbconnection = new MySqlConnection(connection.connectionString);
            this.HRMainForm = HRMainForm;
        }

        private void EmployeesName_Load(object sender, EventArgs e)
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
                HRMainForm.bindReport2EmployeesForm(gridControl1);
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
            string query = "select Employee_ID  as 'id', Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف' from employee ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet1 = new DataSet();
            adapter.Fill(dataSet1);

            query = "select Delegate_ID as 'id', Delegate_Number as 'الرقم الوظيفي',Delegate_Name as 'اسم الموظف'from Delegate ";
            adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet2 = new DataSet();
            adapter.Fill(dataSet2);
            DataSet dataSet3 = new DataSet();

            dataSet3 = dataSet1.Copy();
            dataSet3.Merge(dataSet2, true);

            gridControl1.DataSource = dataSet3.Tables[0];
            gridView1.Columns[0].Visible = false;
        }

     
    }
}
