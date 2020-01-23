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
    public partial class StudentViewUnassignedProjects : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        
        public StudentViewUnassignedProjects()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_Search_Unassigned_Projects", Connection);
                CMD.Parameters.Add("@Disc", SqlDbType.NVarChar).Value = "CE";
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView_1.DataSource = DT;
                Connection.Close();

            }
            catch (Exception E)
            {
                MessageBox.Show("Could not View Unassigned Projects Due to Error: " + E.Message);
            }
        }

        private void dataGridView_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
