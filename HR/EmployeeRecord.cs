using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace HR
{
    public partial class EmployeeRecord : Form
    {
        MySqlConnection dbconnection;

        public EmployeeRecord()
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;

                if (ImageBox.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ImageBox.Image.Save(ms, ImageBox.Image.RawFormat);
                    img = ms.ToArray();
                }
                double x;

                if (txtDepartment.Text == "")
                {
                    x = 0;
                }
                else
                {
                    x = Double.Parse(txtDepartment.Text);
                }

                string insert = "INSERT INTO Employee (Employee_Number,Employee_Name,Employee_Phone,Employee_Address,Employee_Info,Employee_Qualification,Employee_Start,Employee_Job,Employee_Department,Employee_Birth,Employee_Salary,Employee_Mail,Employee_Branch,Employee_Photo,National_ID,Social_Status,Job_Hours) VALUES (@Employee_Number,@Employee_Name,@Employee_Phone,@Employee_Address,@Employee_Info,@Employee_Qualification,@Employee_Start,@Employee_Job,@Employee_Department,@Employee_Birth,@Employee_Salary,@Employee_Mail,@Employee_Branch,@Employee_Photo,@National_ID,@Social_Status,@Job_Hours)";

                dbconnection.Open();
                MySqlCommand cmd = new MySqlCommand(insert, dbconnection);

                cmd.Parameters.Add("@Employee_Number", MySqlDbType.Int16);
                cmd.Parameters["@Employee_Number"].Value = txtEmployeeNumber.Text;
                cmd.Parameters.Add("@Employee_Name", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Name"].Value = txtEmployeeName.Text;
                cmd.Parameters.Add("@National_ID", MySqlDbType.VarChar, 255);
                cmd.Parameters["@National_ID"].Value = txt.Text;
                cmd.Parameters.Add("@Employee_Phone", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Phone"].Value = txtNationalID.Text;
                cmd.Parameters.Add("@Employee_Address", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Address"].Value = txtSocialInsuranceNumber.Text;
                cmd.Parameters.Add("@Employee_Qualification", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Qualification"].Value = txtJob.Text;
                cmd.Parameters.Add("@Employee_Start", MySqlDbType.Date, 0);
                cmd.Parameters["@Employee_Start"].Value = dateTimePickerStartDate.Value;
                cmd.Parameters.Add("@Employee_Job", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Job"].Value = txtWorkType.Text;
                cmd.Parameters.Add("@Employee_Salary", MySqlDbType.Decimal, 10);
                cmd.Parameters["@Employee_Salary"].Value = x;
                cmd.Parameters.Add("@Employee_Birth", MySqlDbType.Date, 0);
                cmd.Parameters["@Employee_Birth"].Value = dateTimePicker2.Value;
                cmd.Parameters.Add("@Employee_Mail", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Mail"].Value = textBox7.Text;
                cmd.Parameters.Add("@Employee_Branch", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Branch"].Value = textBox10.Text;
                cmd.Parameters.Add("@Employee_Department", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Department"].Value = txtQualification.Text;
                cmd.Parameters.Add("@Employee_Info", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Employee_Info"].Value = txtNotes.Text;
                cmd.Parameters.Add("@Employee_Photo", MySqlDbType.Blob);
                cmd.Parameters["@Employee_Photo"].Value = img;
                
                cmd.Parameters.Add("@Social_Status", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Social_Status"].Value = textBox11.Text;
                cmd.Parameters.Add("@Job_Hours", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Job_Hours"].Value = comBranch.Text;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("تم ادخال البيانات بنجاح");

                    txtEmployeeName.Clear();
                    txtNationalID.Clear();
                    txtSocialInsuranceNumber.Clear();
                    txtJob.Clear();
                    txtWorkType.Clear();
                    txtDepartment.Clear();
                    textBox7.Clear();
                    txtQualification.Clear();
                    txtNotes.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    txt.Clear();

                    ImageBox.Image = null;
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
            dbconnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    ImageBox.Image = Image.FromFile(opf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }

    

    }
}
