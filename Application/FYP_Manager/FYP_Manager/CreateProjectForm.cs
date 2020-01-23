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

namespace FYP_Manager
{
    public partial class CreateProjectForm : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID;
        public CreateProjectForm(int F_ID)
        {
            InitializeComponent();

            Fac_ID = F_ID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_Add_Project", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@P_Name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                CMD.Parameters.AddWithValue("@P_Details", SqlDbType.VarChar).Value = textBox2.Text.Trim();
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.Int).Value = Fac_ID;
                CMD.ExecuteNonQuery();
                MessageBox.Show("Project Successfully Added to Unassigned Projects.");
                Connection.Close();
            }
            catch(Exception Exp)
            {
                MessageBox.Show("Project not Added due to the Error: " + Exp.Message);
            }
        }
    }
}
