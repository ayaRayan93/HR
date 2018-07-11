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
                this.HRMainForm = HRMainForm;
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
            try
            {
                HRMainForm.bindRecordEmployeesForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)(((GridView)gridControl1.MainView).GetRow(((GridView)gridControl1.MainView).GetSelectedRows()[0]));
                HRMainForm.bindUpdateEmployeesForm(row, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                       
                        if (setRow[0].ToString() == "موظف")
                        {
                            string Query = "delete from employee where Employee_ID=" + setRow[1].ToString();
                            MySqlCommand MyCommand = new MySqlCommand(Query, dbconnection);
                            MyCommand.ExecuteNonQuery();

                            string query = "ALTER TABLE employee AUTO_INCREMENT = 1;";
                            MySqlCommand com = new MySqlCommand(query, dbconnection);
                            com.ExecuteNonQuery();
                            UserControl.UserRecord("employee", "حذف", setRow[1].ToString(), DateTime.Now, dbconnection);
                        }
                        else
                        {
                            string Query = "delete from delegate where Delegate_ID=" + setRow[1].ToString();
                            MySqlCommand MyCommand = new MySqlCommand(Query, dbconnection);
                            MyCommand.ExecuteNonQuery();

                            string query = "ALTER TABLE delegate AUTO_INCREMENT = 1;";
                            MySqlCommand com = new MySqlCommand(query, dbconnection);
                            com.ExecuteNonQuery();
                            UserControl.UserRecord("delegate", "حذف", setRow[1].ToString(), DateTime.Now, dbconnection);
                        }
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                HRMainForm.bindReportEmployeesForm(gridControl1);
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
            decimal xa = 00;
            string query = "select 'موظف' as 'x', Employee_ID as 'id', Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف',Employee_Taraget as 'الهدف الشهري',Employee_Phone as 'رقم الهاتف',Employee_Address as 'عنوان السكن',Employee_Mail as 'البريد الالكتروني',Employee_Birth_Date as 'تاريخ الميلاد',Employee_Qualification as 'المؤهل العلمي',SocialInsuranceNumber as 'رقم التامين الاجتماعي',National_ID as 'الرقم القومي',Social_Status as 'الحالة الاجتماعية',Employee_Start_Date as 'تاريخ التعيين',Branch_Name as 'الفرع',Employee_Job as 'الوظيفة',Employee_Department as 'مكان العمل',Employee_Salary as 'الراتب الاساسي',Employee_Photo as 'الصورة',EmploymentType as 'نوع التوظيف',ExperienceYears as 'عدد سنوات الخبرة',Employee_Info as 'ملاحظات' from employee inner join branch on employee.Employee_Branch_ID=branch.Branch_ID";      
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet1 = new DataSet();
            adapter.Fill(dataSet1);
           
            query = "select 'مندوب'as 'x', Delegate_ID as 'id', Delegate_Number as 'الرقم الوظيفي',Delegate_Name as 'اسم الموظف',Delegate_Taraget as 'الهدف الشهري',Delegate_Phone as 'رقم الهاتف',Delegate_Address as 'عنوان السكن',Delegate_Mail as 'البريد الالكتروني',Delegate_Birth_Date as 'تاريخ الميلاد',Delegate_Qualification as 'المؤهل العلمي',SocialInsuranceNumber as 'رقم التامين الاجتماعي',National_ID as 'الرقم القومي',Social_Status as 'الحالة الاجتماعية',Delegate_Start_Date as 'تاريخ التعيين',Branch_Name as 'الفرع',Delegate_Job as 'الوظيفة',Delegate_Department as 'مكان العمل',Delegate_Salary as 'الراتب الاساسي',Delegate_Photo as 'الصورة',EmploymentType as 'نوع التوظيف',ExperienceYears as 'عدد سنوات الخبرة',Delegate_Info as 'ملاحظات' from Delegate inner join branch on Delegate.Delegate_Branch_ID=branch.Branch_ID";
            adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet2 = new DataSet();
            adapter.Fill(dataSet2);
            DataSet dataSet3 = new DataSet();

            dataSet3 = dataSet1.Copy();
            dataSet3.Merge(dataSet2, true);

            gridControl1.DataSource = dataSet3.Tables[0];
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
        }

    }

}
