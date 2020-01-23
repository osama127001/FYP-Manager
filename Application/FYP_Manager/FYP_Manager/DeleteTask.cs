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
    public partial class DeleteTask : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        int Fac_ID = -1;
        public DeleteTask(int F_ID)
        {
            InitializeComponent();
            Fac_ID = F_ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_Delete_Task", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.NVarChar).Value = Fac_ID;
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
                CMD.Parameters.AddWithValue("@Task", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
                CMD.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception Exp)
            {
                Connection.Close();
                MessageBox.Show("Task Could not be deleted due to the Error: " + Exp.Message + "\n" + "Please Check Task Name and Project ID and Try Again.!");
                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
