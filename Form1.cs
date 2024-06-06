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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=RMSdb;Integrated Security=True;Encrypt=False");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            SqlCommand cmd = new SqlCommand("select Username,Password from Logintab where Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Invalid username and password");
            }
            con.Close();
        }
    }
}
