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

namespace RMS
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into paymenttab values(@Pid,@CustomerName,@Food1,@Food2,@Food3,@PaymentMethod,@Amount)", con);
            cmd.Parameters.AddWithValue("@PId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("CustomerName", textBox2.Text);
            cmd.Parameters.AddWithValue("Food1", textBox3.Text);
            cmd.Parameters.AddWithValue("Food2", textBox4.Text);
            cmd.Parameters.AddWithValue("Food3", textBox5.Text);
            cmd.Parameters.AddWithValue("PaymentMethod", textBox6.Text);
            cmd.Parameters.AddWithValue("Amount", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from paymenttab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update paymenttab set customername-@customername,food1=@food1,food2=@food2,food3=@food3,paymentmethod=@paymentmethod,amount=@amount", con);
            cmd.Parameters.AddWithValue("@PId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("CustomerName", textBox2.Text);
            cmd.Parameters.AddWithValue("Food1", textBox3.Text);
            cmd.Parameters.AddWithValue("Food2", textBox4.Text);
            cmd.Parameters.AddWithValue("Food3", textBox5.Text);
            cmd.Parameters.AddWithValue("PaymentMethod", textBox6.Text);
            cmd.Parameters.AddWithValue("Amount", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete paymenttab where pid=@pid", con);
            cmd.Parameters.AddWithValue("@PId", int.Parse(textBox1.Text));
           
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from paymenttab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from paymenttab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
