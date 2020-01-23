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
    public partial class StudentViewMyProject : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Reg;
        public StudentViewMyProject(int R)
        {
            InitializeComponent();
            Reg = R;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_Search_Assigned_Projects", Connection);
                CMD.Parameters.Add("@S_Reg", SqlDbType.Int).Value = Reg;
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView_1.DataSource = DT;
                Connection.Close();

            }
            catch (Exception E)
            {
                MessageBox.Show("Could not View Project Due to Error: " + E.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
