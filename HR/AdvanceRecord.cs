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
    public partial class AdvanceRecord : Form
    {
        public AdvanceRecord()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter da;

        private void Form10_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection(conn.str);
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void Form10_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";
            cmd = new MySqlCommand("SELECT Employee_Name FROM employee ;", con);
            try
            {
                con.Close();
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
                        dataGridView1.DataSource = dt;
                        comboBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                        con.Close();

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                    }
                }
                if (radioButton2.Checked)
                {
                    da = new MySqlDataAdapter("SELECT Delegate_Name FROM delegate WHERE Delegate_ID = '" + textBox1.Text + "';", con);
                    try
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        comboBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                        con.Close();

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("" + ee);
                    }
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                da = new MySqlDataAdapter("SELECT Employee_ID FROM employee WHERE Employee_Name = '" + comboBox1.Text + "';", con);
                try
                {
                    con.Close();
                    con.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    con.Close();

                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }
            if (radioButton2.Checked)
            {
                da = new MySqlDataAdapter("SELECT Delegate_ID FROM delegate WHERE Delegate_Name = '" + comboBox1.Text + "';", con);
                try
                {
                    con.Close();
                    con.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    con.Close();

                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Double.Parse(textBox2.Text);
                if (radioButton1.Checked)
                {
                    string insert = "INSERT INTO Loans (Employee_ID,Worker_Name,Loan_Type,Loan_Date,Loan) VALUES (@Employee_ID,@Worker_Name,@Loan_Type,@Loan_Date,@Loan)";

                    con.Close();
                    con.Open();
                    cmd = new MySqlCommand(insert, con);

                    cmd.Parameters.Add("@Employee_ID", MySqlDbType.Int32, 11);
                    cmd.Parameters["@Employee_ID"].Value = textBox1.Text;
                    cmd.Parameters.Add("@Worker_Name", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Worker_Name"].Value = comboBox1.Text;
                    cmd.Parameters.Add("@Loan_Type", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Loan_Type"].Value = "سلفة";
                    cmd.Parameters.Add("@Loan_Date", MySqlDbType.Date, 0);
                    cmd.Parameters["@Loan_Date"].Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@Loan", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Loan"].Value = x;
                }
                if (radioButton2.Checked)
                {
                    string insert = "INSERT INTO Loans (Delegate_ID,Worker_Name,Loan_Type,Loan_Date,Loan) VALUES (@Delegate_ID,@Worker_Name,@Loan_Type,@Loan_Date,@Loan)";

                    con.Close();
                    con.Open();
                    cmd = new MySqlCommand(insert, con);

                    cmd.Parameters.Add("@Delegate_ID", MySqlDbType.Int32, 11);
                    cmd.Parameters["@Delegate_ID"].Value = textBox1.Text;
                    cmd.Parameters.Add("@Worker_Name", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Worker_Name"].Value = comboBox1.Text;
                    cmd.Parameters.Add("@Loan_Type", MySqlDbType.VarChar, 255);
                    cmd.Parameters["@Loan_Type"].Value = "سلفة";
                    cmd.Parameters.Add("@Loan_Date", MySqlDbType.Date, 0);
                    cmd.Parameters["@Loan_Date"].Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@Loan", MySqlDbType.Decimal, 10);
                    cmd.Parameters["@Loan"].Value = x;
                }
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
}
