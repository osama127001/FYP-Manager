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
    public partial class Student_Chat : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        int Pr_ID = -1;
        int Reg_No;
        public Student_Chat(int P_ID, int Reg)
        {
            InitializeComponent();
            Pr_ID = P_ID;
            Reg_No = Reg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Pr_ID == -1) { MessageBox.Show("You are not assigned to any Project"); return; }
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_See_Chat", Connection);
                try { CMD.Parameters.Add("@P_ID", SqlDbType.Int).Value = Pr_ID; }
                catch (Exception E) { MessageBox.Show("Please Enter Project ID as a Number. \n" + E.Message); }                
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pr_ID == -1) { MessageBox.Show("You are not assigned to any Project"); return; }
            if (textBox2.Text == "") { MessageBox.Show("No Message Entered!"); return; }          
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_Send_Message", Connection);
                CMD.Parameters.Add("@Msg", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
                try { CMD.Parameters.Add("@P_ID", SqlDbType.Int).Value = Pr_ID; }
                catch (Exception E) { MessageBox.Show("Please Enter Project ID as a Number. \n" + E.Message); }
                CMD.Parameters.Add("@S_reg", SqlDbType.Int).Value = Reg_No;
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView1.DataSource = DT;
                Connection.Close();
                textBox2.Clear();
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Chat Could not be displayed due to error: " + Exp.Message);
                Connection.Close();
            }

            //Student Can see message after sending.
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_See_Chat", Connection);
                try { CMD.Parameters.Add("@P_ID", SqlDbType.Int).Value = Pr_ID; }
                catch (Exception E) { MessageBox.Show("Please Enter Project ID as a Number. \n" + E.Message); }
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
