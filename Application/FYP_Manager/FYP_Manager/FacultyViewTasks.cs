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
    public partial class FacultyViewTasks : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID = -1;
        public FacultyViewTasks(int F_ID)
        {
            InitializeComponent();
            Fac_ID = F_ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            { MessageBox.Show("Please Enter Project ID."); }
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Faculty_See_Tasks", Connection);
                try { CMD.Parameters.Add("@P_ID", SqlDbType.Int).Value = int.Parse(textBox1.Text.ToString()); }
                catch (Exception E) { MessageBox.Show("Please Enter Project ID as a Number. \n" + E.Message); }
                CMD.Parameters.Add("@F_ID", SqlDbType.Int).Value = Fac_ID;
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView1.DataSource = DT;
                Connection.Close();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Chat Could not be displayed due to error: " + Exp.Message);
                Connection.Close();
            }

        }
    }
}
