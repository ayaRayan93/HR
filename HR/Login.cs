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
    public partial class Login : Form
    {
        string connstr = connection.connectionString;
        MySqlConnection conn;
        Timer t;
        public Login()
        {
            InitializeComponent();
            conn = new MySqlConnection(connstr);
            txtName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = "select User_ID,User_Name from users where User_Name=@Name and Password=@Pass and (User_Type=0 or User_Type=1)";
                conn.Open();
                MySqlCommand comand = new MySqlCommand(query, conn);
                comand.Parameters.AddWithValue("@Name", txtName.Text);
                comand.Parameters.AddWithValue("@Pass", txtPassword.Text);
                MySqlDataReader result = comand.ExecuteReader();
               
                
                if (result != null)
                {
                    while (result.Read())
                    {
                        UserControl.userID = (int)result[0];
                        UserControl.userName = result[1].ToString();

                        HRMainForm f = new HRMainForm();
                        f.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("please try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string query = "select User_Name from users where User_Name=@Name ";
                    conn.Open();
                    MySqlCommand comand = new MySqlCommand(query, conn);
                    comand.Parameters.AddWithValue("@Name", txtName.Text);
                    var result = comand.ExecuteScalar();
                    conn.Close();

                    if (result != null)
                    {
                        txtPassword.Focus();
                    }
                    else
                    {
                        txtName.Focus();
                        
                        MessageBox.Show("Enter correct user name");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string query = "select User_Name from users where User_Name=@Name and Password=@Pass and (User_Type=0 or User_Type=1)";
                    conn.Open();
                    MySqlCommand comand = new MySqlCommand(query, conn);
                    comand.Parameters.AddWithValue("@Name", txtName.Text);
                    comand.Parameters.AddWithValue("@Pass", txtPassword.Text);
                    var result = comand.ExecuteScalar();
                    conn.Close();

                    if (result != null)
                    {
                        HRMainForm f = new HRMainForm();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        txtPassword.Focus();
                        MessageBox.Show("Enter correct password");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                t = new Timer();
                
                t.Interval = 2000; // specify interval time as you want
                t.Tick += new EventHandler(timer_Tick);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // this.FormBorderStyle = FormBorderStyle.Sizable;
             //   panel9.Visible = false;
                t.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }

    
        private void panel8_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panClose_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

    }
}
