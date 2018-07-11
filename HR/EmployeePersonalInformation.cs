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
    public partial class EmployeePersonalInformation : Form
    {
        MySqlConnection dbconnection;
        HRMainForm HRMainForm;
        public EmployeePersonalInformation(HRMainForm HRMainForm)
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

        private void EmployeePersonalInformation_Load(object sender, EventArgs e)
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
                HRMainForm.bindReport4EmployeesForm(gridControl1);
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
            string query = "select Employee_ID as 'id', Employee_Number as 'الرقم الوظيفي',Employee_Name as 'اسم الموظف',Employee_Qualification as 'المؤهل العلمي',SocialInsuranceNumber as 'رقم التامين الاجتماعي',National_ID as 'الرقم القومي',Employee_Start_Date as 'تاريخ بدءالعمل',Branch_Name as 'الفرع',Employee_Job as 'الوظيفة',Employee_Department as 'مكان العمل',EmploymentType as 'نوع التوظيف',ExperienceYears as 'عدد سنوات الخبرة' from employee inner join branch on employee.Employee_Branch_ID=branch.Branch_ID";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbconnection);
            DataSet dataSet1 = new DataSet();
            adapter.Fill(dataSet1);

            query = "select  Delegate_ID as 'id', Delegate_Number as 'الرقم الوظيفي',Delegate_Name as 'اسم الموظف',Delegate_Qualification as 'المؤهل العلمي',SocialInsuranceNumber as 'رقم التامين الاجتماعي',National_ID as 'الرقم القومي',Delegate_Start_Date as 'تاريخ التعيين',Branch_Name as 'الفرع',Delegate_Job as 'الوظيفة',Delegate_Department as 'مكان العمل',EmploymentType as 'نوع التوظيف',ExperienceYears as 'عدد سنوات الخبرة' from Delegate inner join branch on Delegate.Delegate_Branch_ID=branch.Branch_ID";
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
