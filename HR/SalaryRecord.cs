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
    public partial class SalaryRecord : Form
    {
        public SalaryRecord()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection(conn.str);

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            cmd = new MySqlCommand("SELECT Employee_Name FROM employee ;", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetString("Employee_Name"));
                }
                dr.Close();
                con.Close();
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedItem.ToString();

            if (radioButton1.Checked)
            {

                da = new MySqlDataAdapter("SELECT Employee_ID FROM employee WHERE Employee_Name = '" + s + "';", con);
                try
                {
                    con.Close();
                    con.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    textBox1.Text = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value);

                    con.Close();
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }

            else if (radioButton2.Checked)
            {
                da = new MySqlDataAdapter("SELECT Delegate_ID FROM delegate WHERE Delegate_Name = '" + s + "';", con);
                try
                {
                    con.Close();
                    con.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    textBox1.Text = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value);

                    con.Close();
                }

                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton1.Checked)
                {
                    da = new MySqlDataAdapter("SELECT Employee_Name FROM employee WHERE Employee_ID = '" + textBox1.Text + "';", con);
                    try
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        comboBox1.Text = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value);
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                    }
                }
                else if (radioButton2.Checked)
                {
                    da = new MySqlDataAdapter("SELECT Delegate_Name FROM delegate WHERE Delegate_ID = '" + textBox1.Text + "';", con);
                    try
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        comboBox1.Text = Convert.ToString(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value);
                        con.Close();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                    }
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
                textBox8.Text = (Double.Parse(textBox2.Text) + Double.Parse(textBox3.Text) + Double.Parse(textBox4.Text) + Double.Parse(textBox5.Text) + Double.Parse(textBox6.Text) + Double.Parse(textBox7.Text)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string insert = "INSERT INTO Salary (Employee_ID,Salary,Stimulus,Company_Bonus,Proficiency,Transition,Annual_Stimulus,Total,Worker_Name) VALUES (@Employee_ID,@Salary,@Stimulus,@Company_Bonus,@Proficiency,@Transition,@Annual_Stimulus,@Total,@Worker_Name)";

                try
                {
                    con.Open();
                    cmd = new MySqlCommand(insert, con);

                    cmd.Parameters.Add("@Employee_ID", MySqlDbType.Int32, 11);
                    cmd.Parameters["@Employee_ID"].Value = textBox1.Text;
                    cmd.Parameters.Add("@Salary", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Salary"].Value = textBox2.Text;
                    cmd.Parameters.Add("@Stimulus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Stimulus"].Value = textBox3.Text;
                    cmd.Parameters.Add("@Company_Bonus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Company_Bonus"].Value = textBox4.Text;
                    cmd.Parameters.Add("@Proficiency", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Proficiency"].Value = textBox5.Text;
                    cmd.Parameters.Add("@Transition", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Transition"].Value = textBox6.Text;
                    cmd.Parameters.Add("@Annual_Stimulus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Annual_Stimulus"].Value = textBox7.Text;
                    cmd.Parameters.Add("@Total", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Total"].Value = textBox8.Text;
                    cmd.Parameters.Add("@Worker_Name", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Worker_Name"].Value = comboBox1.Text;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                    }

                    con.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }

            else if (radioButton2.Checked)
            {
                string insert = "INSERT INTO Salary (Delegate_ID,Salary,Stimulus,Company_Bonus,Proficiency,Transition,Annual_Stimulus,Total,Worker_Name) VALUES (@Delegate_ID,@Salary,@Stimulus,@Company_Bonus,@Proficiency,@Transition,@Annual_Stimulus,@Total,@Worker_Name)";

                try
                {
                    con.Open();
                    cmd = new MySqlCommand(insert, con);

                    cmd.Parameters.Add("@Delegate_ID", MySqlDbType.Int32, 11);
                    cmd.Parameters["@Delegate_ID"].Value = textBox1.Text;
                    cmd.Parameters.Add("@Salary", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Salary"].Value = textBox2.Text;
                    cmd.Parameters.Add("@Stimulus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Stimulus"].Value = textBox3.Text;
                    cmd.Parameters.Add("@Company_Bonus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Company_Bonus"].Value = textBox4.Text;
                    cmd.Parameters.Add("@Proficiency", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Proficiency"].Value = textBox5.Text;
                    cmd.Parameters.Add("@Transition", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Transition"].Value = textBox6.Text;
                    cmd.Parameters.Add("@Annual_Stimulus", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Annual_Stimulus"].Value = textBox7.Text;
                    cmd.Parameters.Add("@Total", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Total"].Value = textBox8.Text;
                    cmd.Parameters.Add("@Worker_Name", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Worker_Name"].Value = comboBox1.Text;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم ادخال البيانات بنجاح");
                    }

                    con.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";

            cmd = new MySqlCommand("SELECT Employee_Name FROM employee ;", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetString("Employee_Name"));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }

            comboBox1.Visible = true;
            textBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";
            cmd = new MySqlCommand("SELECT Delegate_Name FROM delegate ;", con);
            try
            {
                con.Close();
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetString("Delegate_Name"));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }

            comboBox1.Visible = true;
            textBox1.Visible = true;
        }
    }
}
