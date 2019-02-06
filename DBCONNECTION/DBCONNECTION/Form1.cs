using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DBCONNECTION
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        int id;
        string name;
        int salary;
        string email;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             id = Int32.Parse(empid.Text);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             name = empname.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            salary = Int32.Parse(empsalary.Text);
        }

        private void empemail_TextChanged(object sender, EventArgs e)
        {
            email = empemail.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = string.Format("insert into emp values({0},'{1}',{2},'{3}')", id, name, salary, email);
            cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Added Successfully!");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string command = "select * from emp where id = " + id;
            cmd = new SqlCommand(command, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                empname.Text = dr[1].ToString();
                empsalary.Text = dr[2].ToString();
                empemail.Text = dr[3].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string command = "delete from emp where id = " + id;
            cmd = new SqlCommand(command, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Details deleted.!");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string command = "update emp set name = '" + name + "', salary = " + salary + ", email = '" + email + "' where id = " + id;
            cmd = new SqlCommand(command, con);
            con.Open();

            if (cmd.ExecuteNonQuery() > 0)
                MessageBox.Show("Employee Details updated.!");
            else
                MessageBox.Show("Employee not found");
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void display_Click(object sender, EventArgs e)
        {
            SqlCommand c = new SqlCommand("listEmp",con);
            c.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = c.ExecuteReader();
            if(dr.Read())
            {
                dataGridView1.DataSource = dr;
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
