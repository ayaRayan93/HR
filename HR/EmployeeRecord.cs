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
        Employees employees;
        public EmployeeRecord(Employees employees)
        {
            try
            {
                InitializeComponent();
                dbconnection = new MySqlConnection(connection.connectionString);
                this.employees = employees;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }


        private void EmployeeRecord_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from branch";
                MySqlDataAdapter da = new MySqlDataAdapter(query, dbconnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comBranch.DataSource = dt;
                comBranch.DisplayMember = dt.Columns["Branch_Name"].ToString();
                comBranch.ValueMember = dt.Columns["Branch_ID"].ToString();
                comBranch.Text = "";

                VScrollBar myScrollBar = new VScrollBar();

                myScrollBar.Height = panel1.Height;

                myScrollBar.Left = panel1.Width - myScrollBar.Width;

                myScrollBar.Top = 0;

                myScrollBar.Enabled = false;

                panel2.Controls.Add(myScrollBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
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

                if (txtSalary.Text == "")
                {
                    x = 0;
                }
                else
                {
                    x = Double.Parse(txtSalary.Text);
                }

                dbconnection.Open();
                if (rEmployee.Checked)
                {
                    #region Add New Employee
                    string insert = "INSERT INTO Employee (Employee_Number,Employee_Name,Employee_Phone,Employee_Address,Employee_Info,Employee_Qualification,Employee_Start_Date,Employee_Job,Employee_Department,Employee_Birth_Date,Employee_Salary,Employee_Mail,Employee_Branch_ID,Employee_Photo,National_ID,Social_Status,SocialInsuranceNumber,EmploymentType,ExperienceYears) VALUES (@Employee_Number,@Employee_Name,@Employee_Phone,@Employee_Address,@Employee_Info,@Employee_Qualification,@Employee_Start,@Employee_Job,@Employee_Department,@Employee_Birth,@Employee_Salary,@Employee_Mail,@Employee_Branch_ID,@Employee_Photo,@National_ID,@Social_Status,@SocialInsuranceNumber,@EmploymentType,@ExperienceYears)";
                    MySqlCommand cmd = new MySqlCommand(insert, dbconnection);
                    cmd.Parameters.Add("@Employee_Number", MySqlDbType.Int16);
                    if (txtEmployeeNumber.Text != "")
                    {
                        cmd.Parameters["@Employee_Number"].Value = Convert.ToInt16(txtEmployeeNumber.Text);
                        labNumberReqired.Visible = false;
                    }
                    else
                    {
                        txtEmployeeNumber.Focus();
                        labNumberReqired.Visible = true;
                        dbconnection.Close();
                        return;
                    }
                    cmd.Parameters.Add("@Employee_Name", MySqlDbType.VarChar, 255);
                    if (txtEmployeeName.Text != "")
                    {
                        cmd.Parameters["@Employee_Name"].Value = txtEmployeeName.Text;
                        labName.Visible = false;
                    }
                    else
                    {
                        txtEmployeeName.Focus();
                        labName.Visible = true;
                        dbconnection.Close();
                        return;
                    }

                    cmd.Parameters.Add("@National_ID", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@National_ID"].Value = txtNationalID.Text;
                    cmd.Parameters.Add("@Employee_Phone", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Phone"].Value = txtPhone.Text;
                    cmd.Parameters.Add("@Employee_Address", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Address"].Value = txtAddress.Text;
                    cmd.Parameters.Add("@Employee_Qualification", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Qualification"].Value = txtQualification.Text;
                    cmd.Parameters.Add("@Employee_Start", MySqlDbType.Date, 0);
                    cmd.Parameters["@Employee_Start"].Value = dateTimePickerStartDate.Value;
                    cmd.Parameters.Add("@Employee_Job", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Job"].Value = txtJob.Text;
                    cmd.Parameters.Add("@Employee_Salary", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Employee_Salary"].Value = x;
                    cmd.Parameters.Add("@Employee_Birth", MySqlDbType.Date, 0);
                    cmd.Parameters["@Employee_Birth"].Value = dateTimePickerBirthDate.Value;
                    cmd.Parameters.Add("@Employee_Mail", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Mail"].Value = txtMail.Text;
                    cmd.Parameters.Add("@Employee_Branch_ID", MySqlDbType.Int16);
                    cmd.Parameters["@Employee_Branch_ID"].Value = comBranch.SelectedValue;
                    cmd.Parameters.Add("@Employee_Department", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Department"].Value = txtDepartment.Text;
                    cmd.Parameters.Add("@Employee_Info", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Employee_Info"].Value = txtNotes.Text;
                    cmd.Parameters.Add("@Employee_Photo", MySqlDbType.Blob);
                    cmd.Parameters["@Employee_Photo"].Value = img;
                    cmd.Parameters.Add("@Social_Status", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Social_Status"].Value = txtSocialStatus.Text;

                    cmd.Parameters.Add("@SocialInsuranceNumber", MySqlDbType.Int16);
                    if (txtSocialInsuranceNumber.Text != "")
                        cmd.Parameters["@SocialInsuranceNumber"].Value = Convert.ToInt16(txtSocialInsuranceNumber.Text);
                    else
                        cmd.Parameters["@SocialInsuranceNumber"].Value = 0;

                    cmd.Parameters.Add("@EmploymentType", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@EmploymentType"].Value = txtWorkType.Text;
                    cmd.Parameters.Add("@ExperienceYears", MySqlDbType.Int16);
                    if (txtExperienceYears.Text != "")
                        cmd.Parameters["@ExperienceYears"].Value = Convert.ToInt16(txtExperienceYears.Text);
                    else
                        cmd.Parameters["@ExperienceYears"].Value = 0;
                    #endregion

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        employees.displayEmployee();
                        clear();
                    }
                }
                else if (rDelegate.Checked)
                {
                    #region Add New Delegate
                    string insert = "INSERT INTO Delegate (Delegate_Number,Delegate_Name,Delegate_Phone,Delegate_Address,Delegate_Info,Delegate_Qualification,Delegate_Start_Date,Delegate_Job,Delegate_Department,Delegate_Birth_Date,Delegate_Salary,Delegate_Mail,Delegate_Branch_ID,Delegate_Photo,National_ID,Social_Status,SocialInsuranceNumber,EmploymentType,ExperienceYears,Delegate_Taraget) VALUES (@Delegate_Number,@Delegate_Name,@Delegate_Phone,@Delegate_Address,@Delegate_Info,@Delegate_Qualification,@Delegate_Start,@Delegate_Job,@Delegate_Department,@Delegate_Birth,@Delegate_Salary,@Delegate_Mail,@Delegate_Branch_ID,@Delegate_Photo,@National_ID,@Social_Status,@SocialInsuranceNumber,@EmploymentType,@ExperienceYears,@Delegate_Taraget)";
                    MySqlCommand cmd = new MySqlCommand(insert, dbconnection);
                    cmd.Parameters.Add("@Delegate_Number", MySqlDbType.Int16);
                    if (txtEmployeeNumber.Text != "")
                    {
                        cmd.Parameters["@Delegate_Number"].Value = Convert.ToInt16(txtEmployeeNumber.Text);
                        labNumberReqired.Visible = false;
                    }
                    else
                    {
                        txtEmployeeNumber.Focus();
                        labNumberReqired.Visible = true;
                        dbconnection.Close();
                        return;
                    }
                    cmd.Parameters.Add("@Delegate_Name", MySqlDbType.VarChar, 255);
                    if (txtEmployeeName.Text != "")
                    {
                        cmd.Parameters["@Delegate_Name"].Value = txtEmployeeName.Text;
                        labName.Visible = false;
                    }
                    else
                    {
                        txtEmployeeName.Focus();
                        labName.Visible = true;
                        dbconnection.Close();
                        return;
                    }

                    cmd.Parameters.Add("@National_ID", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@National_ID"].Value = txtNationalID.Text;
                    cmd.Parameters.Add("@Delegate_Phone", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Phone"].Value = txtPhone.Text;
                    cmd.Parameters.Add("@Delegate_Address", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Address"].Value = txtAddress.Text;
                    cmd.Parameters.Add("@Delegate_Qualification", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Qualification"].Value = txtQualification.Text;
                    cmd.Parameters.Add("@Delegate_Start", MySqlDbType.Date, 0);
                    cmd.Parameters["@Delegate_Start"].Value = dateTimePickerStartDate.Value;
                    cmd.Parameters.Add("@Delegate_Job", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Job"].Value = txtJob.Text;
                    cmd.Parameters.Add("@Delegate_Salary", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Delegate_Salary"].Value = x;
                    cmd.Parameters.Add("@Delegate_Birth", MySqlDbType.Date, 0);
                    cmd.Parameters["@Delegate_Birth"].Value = dateTimePickerBirthDate.Value;
                    cmd.Parameters.Add("@Delegate_Mail", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Mail"].Value = txtMail.Text;
                    cmd.Parameters.Add("@Delegate_Branch_ID", MySqlDbType.Int16);
                    cmd.Parameters["@Delegate_Branch_ID"].Value = comBranch.SelectedValue;
                    cmd.Parameters.Add("@Delegate_Department", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Department"].Value = txtDepartment.Text;
                    cmd.Parameters.Add("@Delegate_Info", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Delegate_Info"].Value = txtNotes.Text;
                    cmd.Parameters.Add("@Delegate_Photo", MySqlDbType.Blob);
                    cmd.Parameters["@Delegate_Photo"].Value = img;
                    cmd.Parameters.Add("@Social_Status", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Social_Status"].Value = txtSocialStatus.Text;
                    cmd.Parameters.Add("@Delegate_Taraget", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Delegate_Taraget"].Value = Convert.ToDouble(txtTaraget.Text);

                    cmd.Parameters.Add("@SocialInsuranceNumber", MySqlDbType.Int16);
                    if (txtSocialInsuranceNumber.Text != "")
                        cmd.Parameters["@SocialInsuranceNumber"].Value = Convert.ToInt16(txtSocialInsuranceNumber.Text);
                    else
                        cmd.Parameters["@SocialInsuranceNumber"].Value = 0;

                    cmd.Parameters.Add("@EmploymentType", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@EmploymentType"].Value = txtWorkType.Text;
                    cmd.Parameters.Add("@ExperienceYears", MySqlDbType.Int16);
                    if (txtExperienceYears.Text != "")
                        cmd.Parameters["@ExperienceYears"].Value = Convert.ToInt16(txtExperienceYears.Text);
                    else
                        cmd.Parameters["@ExperienceYears"].Value = 0;
                    #endregion

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        employees.displayEmployee();
                        clear();

                    }
                }
              
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
            dbconnection.Close();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
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

        //function
        //clear
        public void clear()
        {
            foreach (Control item in this.Controls["panel1"].Controls["panel2"].Controls)
            {
                if (item is TextBox)
                    item.Text = "";
                else if (item is ComboBox)
                    item.Text = "";
            }
            ImageBox.Image = null;
        }

       

        private void rDelegate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                label19.Visible = true;
                txtTaraget.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rEmployee_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                label19.Visible = false;
                txtTaraget.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
