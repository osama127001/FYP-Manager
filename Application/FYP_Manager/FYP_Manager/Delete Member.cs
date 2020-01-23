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
    public partial class Delete_Member : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID;
        public Delete_Member(int F_ID)
        {
            InitializeComponent();
            Fac_ID = F_ID;
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
                SqlCommand CMD = new SqlCommand("sp_Faculty_Delete_Members_From_Assigned_Project", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.VarChar).Value = Fac_ID;
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                CMD.Parameters.AddWithValue("@S_Reg", SqlDbType.Int).Value = textBox2.Text.Trim(); ;
               
                CMD.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Group Member Could not be deleted due to error error: " + Exp.Message);
            }

        }
    }
}
