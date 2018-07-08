using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Employees : Form
    {
        MySqlConnection dbconnection;
        HRMainForm HRMainForm;
        public Employees(HRMainForm HRMainForm)
        {
            try
            {
                InitializeComponent();
                dbconnection = new MySqlConnection(connection.connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dbconnection.Open();
                DataRowView setRow = (DataRowView)(((GridView)gridControl1.MainView).GetRow(((GridView)gridControl1.MainView).GetSelectedRows()[0]));

                if (setRow != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string Query = "delete from employee where Employee_ID=" + setRow[0].ToString();
                        MySqlCommand MyCommand = new MySqlCommand(Query, dbconnection);
                        MyCommand.ExecuteNonQuery();

                        string query = "ALTER TABLE employee AUTO_INCREMENT = 1;";
                        MySqlCommand com = new MySqlCommand(query, dbconnection);
                        com.ExecuteNonQuery();

                        // UserControl.UserRecord("store", "delete", setRow[0].ToString(), DateTime.Now, dbconnection);
                        displayEmployee();

                    }
                    else if (dialogResult == DialogResult.No)
                    { }

                }
                else
                {
                    MessageBox.Show("select row");
                }
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
            string query = "select Employee_ID, Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف',Employee_Phone as 'التلفون',Employee_Address as 'العنوان',Employee_Mail as 'البريد الالكتروني',Employee_Birth_Date as 'تاريخ الميلاد',Employee_Qualification as 'المؤهل العلمي',SocialInsuranceNumber as 'رقم التامين الاجتماعي',National_ID as 'الرقم القومي',Social_Status as 'الحالة الاجتماعية',Employee_Start_Date as 'تاريخ بدءالعمل',Branch_Name as 'الفرع',Employee_Job as 'الوظيفة',Employee_Department as 'مكان العمل',Employee_Salary as 'الراتب الاساسي',Employee_Photo as 'الصورة',EmploymentType as 'نوع التوظيف',ExperienceYears as 'عدد سنوات الخبرة',Employee_Info as 'ملاحظات' from employee inner join branch on employee.Employee_Branch_ID=branch.Branch_ID";      
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            gridControl1.DataSource = dataSet.Tables[0];
            gridView1.Columns[0].Visible = false;
        }

       
    }

  
}
