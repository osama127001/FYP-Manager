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
    public partial class FacultAddStudent : Form
    {
        int Fac_ID = -1;
        String Disp = "NULL";
        public FacultAddStudent(int F_ID, String D)
        {
            InitializeComponent();
            Fac_ID = F_ID;
            Disp = D;

        }
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_Assigns_His_Unassigned_Project", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.VarChar).Value = Fac_ID;
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                CMD.Parameters.AddWithValue("@S_Reg", SqlDbType.Int).Value = textBox2.Text.Trim(); ;
                CMD.Parameters.AddWithValue("@Disc", SqlDbType.Int).Value = Disp;

                CMD.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Project not Added due to the Error: " + Exp.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
