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
    public partial class FacultyAddTask : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID = -1;
        public FacultyAddTask(int F_ID)
        {
            InitializeComponent();
            Fac_ID = F_ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_Add_Tasks_To_Assigned_Project", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.Int).Value = Fac_ID;
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.Int).Value = int.Parse(textBox2.Text.Trim());
                CMD.Parameters.AddWithValue("@Task", SqlDbType.NVarChar).Value = textBox1.Text.Trim(); ;
                CMD.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dateTimePicker1.Text.Trim();

                CMD.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Task not Added due to the Error: " + Exp.Message);
                Connection.Close();
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
