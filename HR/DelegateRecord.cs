using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace HR
{
    public partial class DelegateRecord : Form
    {
        public DelegateRecord()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlCommand cmd;

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.Image = Image.FromFile(opf.FileName);

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          //  con = new MySqlConnection(conn.str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] img = null;

            //if (pictureBox1.Image != null)
            //{
            //    MemoryStream ms = new MemoryStream();
            //    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            //    img = ms.ToArray();
            //}
            double x, y;

            if (textBox5.Text == "")
            {
                x = 0;
            }
            else
            {
                x = Double.Parse(textBox5.Text);
            }
            if (textBox6.Text == "")
            {
                y = 0;
            }
            else
            {
                y = Double.Parse(textBox6.Text);
            }

            string insert = "INSERT INTO delegate (Delegate_Name,Delegate_Phone,Delegate_Address,Delegate_Info,Delegate_Qualification,Delegate_Start,Delegate_Target,Delegate_Birth,Delegate_Salary,Delegate_Mail,Delegate_Branch,Delegate_Photo,National_ID,Social_Status,Job_Hours) VALUES (@Delegate_Name,@Delegate_Phone,@Delegate_Address,@Delegate_Info,@Delegate_Qualification,@Delegate_Start,@Delegate_Target,@Delegate_Birth,@Delegate_Salary,@Delegate_Mail,@Delegate_Branch,@Delegate_Photo,@National_ID,@Social_Status,@Job_Hours)";

            try
            {
                con.Open();
                cmd = new MySqlCommand(insert, con);

                cmd.Parameters.Add("@Delegate_Name", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Name"].Value = textBox1.Text;
                cmd.Parameters.Add("@Delegate_Phone", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Phone"].Value = textBox2.Text;
                cmd.Parameters.Add("@Delegate_Address", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Address"].Value = textBox3.Text;
                cmd.Parameters.Add("@Delegate_Qualification", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Qualification"].Value = textBox4.Text;
                cmd.Parameters.Add("@Delegate_Start", MySqlDbType.Date, 0);
                cmd.Parameters["@Delegate_Start"].Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@Delegate_Target", MySqlDbType.Decimal, 10);
                cmd.Parameters["@Delegate_Target"].Value = x;
                cmd.Parameters.Add("@Delegate_Salary", MySqlDbType.Decimal, 10);
                cmd.Parameters["@Delegate_Salary"].Value = y;
                cmd.Parameters.Add("@Delegate_Birth", MySqlDbType.Date, 0);
                cmd.Parameters["@Delegate_Birth"].Value = dateTimePicker2.Value;
                cmd.Parameters.Add("@Delegate_Mail", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Mail"].Value = textBox7.Text;
                cmd.Parameters.Add("@Delegate_Branch", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Branch"].Value = textBox8.Text;
                cmd.Parameters.Add("@Delegate_Info", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Delegate_Info"].Value = textBox9.Text;
                cmd.Parameters.Add("@Delegate_Photo", MySqlDbType.Blob);
                cmd.Parameters["@Delegate_Photo"].Value = img;
                cmd.Parameters.Add("@National_ID", MySqlDbType.VarChar, 255);
                cmd.Parameters["@National_ID"].Value = textBox10.Text;
                cmd.Parameters.Add("@Social_Status", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Social_Status"].Value = textBox11.Text;
                cmd.Parameters.Add("@Job_Hours", MySqlDbType.VarChar, 255);
                cmd.Parameters["@Job_Hours"].Value = comboBox1.Text;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("تم ادخال البيانات بنجاح");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    

                   // pictureBox1.Image = null;
                }

                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(""+ee);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            //this.Hide();
            //f2.Show();
        }
    }
}
