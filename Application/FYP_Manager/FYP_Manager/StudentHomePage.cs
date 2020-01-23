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
    public partial class StudentHomePage : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Proj_ID = -1;
        int Reg;
        public StudentHomePage(String Name, int Registration, String Degree, String Discipline, int P_ID)
        {
            InitializeComponent();

            label4.Text = Name.ToString();
            label6.Text = Degree.ToString();
            label5.Text = Discipline.ToString();
            label9.Text = Convert.ToString(Registration);

            Reg = Registration;
            Proj_ID = P_ID;
            if (Proj_ID == -1) { label1.Text = "Not assigned any Project"; }
            //View Current Tasks On Data Grid View
            try
            {
                Connection.Open();
                SqlCommand CMD = new SqlCommand("sp_Student_See_Tasks", Connection);
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.Int).Value = Proj_ID;
                CMD.CommandType = CommandType.StoredProcedure;
                DataTable DT = new DataTable();
                DT.Load(CMD.ExecuteReader());
                dataGridView1.DataSource = DT;
                Connection.Close();
            }
            catch(Exception Exp)
            {
                MessageBox.Show("Error: " + Exp.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentViewUnassignedProjects SVUP = new StudentViewUnassignedProjects();
            SVUP.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentViewMyProject SVMP = new StudentViewMyProject(Reg);
            SVMP.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            StudentLogin SLogin = new StudentLogin();
            this.Close();
            SLogin.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_Chat SC = new Student_Chat(Proj_ID, Reg);
            SC.ShowDialog();
        }
    }
}
