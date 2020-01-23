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
    public partial class ViewDepartmentProjects : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        public ViewDepartmentProjects()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Dept = "";
            if (comboBox1.Text.Trim() == "Computer Engineering") { Dept = "CE"; }
            if (comboBox1.Text.Trim() == "Electrical Engineering") { Dept = "EE"; }
            if (comboBox1.Text.Trim() == "Mechanical Engineering") { Dept = "ME"; }
            if (comboBox1.Text.Trim() == "Mechatronics Engineering") { Dept = "MTS"; }
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_Search_All_Projects", Connection);
                CMD.Parameters.AddWithValue("@Disc", SqlDbType.VarChar).Value = Dept;
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView_1.DataSource = DT;
                Connection.Close();
            }
            catch(Exception Exp)
            {
                MessageBox.Show("Projects Could not be displayed due to the Error: " + Exp.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
