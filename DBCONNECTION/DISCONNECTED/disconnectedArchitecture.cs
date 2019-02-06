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

namespace DISCONNECTED
{
    public partial class disconnectedArchitecture : Form
    {
        int id;
        int salary;
        string name;
        string email;
        SqlConnection con;
        DataSet ds = new DataSet();
        SqlCommandBuilder mySqlCommandBuilder;
        SqlDataAdapter da = new SqlDataAdapter();

        public disconnectedArchitecture()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM emp", con);
            mySqlCommandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand = cmd;
            da.Fill(ds);

            DataColumn[] columns = new DataColumn[1];
            columns[0] = ds.Tables[0].Columns["id"];
            ds.Tables[0].PrimaryKey = columns;

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void empid_TextChanged(object sender, EventArgs e)
        {
            id = Int32.Parse(empid.Text);
        }

        private void empname_TextChanged(object sender, EventArgs e)
        {
            name = empname.Text;
        }

        private void empsalary_TextChanged(object sender, EventArgs e)
        {
            salary = Int32.Parse(empsalary.Text);
        }
        private void empemail_TextChanged(object sender, EventArgs e)
        {
            email = empemail.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = id;
            dr[1] = name;
            dr[2] = salary;
            dr[3] = email;
            ds.Tables[0].Rows.Add(dr);
            MessageBox.Show("Added a new employee..!");
            da.Update(ds);


        }

        private void delete_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows.Find(id).Delete();
            da.Update(ds);
            MessageBox.Show("deleted Employee : " + id);
        }

        private void display_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[0]; 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables[0].Rows.Find(id);
            dr[1] = name;
            dr[2] = salary;
            dr[3] = email;
            da.Update(ds);

        }
    }
}
