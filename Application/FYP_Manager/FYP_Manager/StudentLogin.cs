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
    public partial class StudentLogin : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        public StudentLogin()
        {
            InitializeComponent();
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            Close();
            selectionForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String StudentName = "NULL";
            int StudentRegistration = -1;
            String StudentDegree = "NULL";
            String StudentDiscipline = "NULL";
            int StudentProjectID = -1;
            try
            {
                SqlCommand CMD = new SqlCommand("sp_Student_Login", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add("@S_Email", SqlDbType.NVarChar, 50).Value = textBox1.Text.Trim();
                CMD.Parameters.Add("@S_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();

                //Setting @reg as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@reg", SqlDbType.Int));
                CMD.Parameters["@reg"].Direction = ParameterDirection.Output;

                //Setting @Deg as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@Deg", SqlDbType.NVarChar, 10));
                CMD.Parameters["@Deg"].Direction = ParameterDirection.Output;

                //Setting @Disc as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 3));
                CMD.Parameters["@Disc"].Direction = ParameterDirection.Output;

                //Setting @name as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
                CMD.Parameters["@name"].Direction = ParameterDirection.Output;

                //Setting @p_id as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@p_id", SqlDbType.Int));
                CMD.Parameters["@p_id"].Direction = ParameterDirection.Output;

                Connection.Open();
                SqlDataReader rdr = CMD.ExecuteReader();
                rdr.Close();

                try
                {
                    StudentProjectID = (int)CMD.Parameters["@p_id"].Value;
                }
                catch(Exception E)
                {
                    MessageBox.Show("You are not Assigned to any project yet.");
                }
                StudentRegistration = (int)CMD.Parameters["@reg"].Value;
                StudentDegree = Convert.ToString(CMD.Parameters["@Deg"].Value);
                StudentDiscipline = Convert.ToString(CMD.Parameters["@Disc"].Value);
                StudentName = Convert.ToString(CMD.Parameters["@name"].Value);
                
                CMD.ExecuteNonQuery();
                Connection.Close();

                if (StudentDegree != "NULL" && StudentDiscipline != "NULL")
                {
                    StudentHomePage SHomePage = new StudentHomePage(StudentName, StudentRegistration, StudentDegree, StudentDiscipline, StudentProjectID);
                    this.Hide();
                    SHomePage.Show();
                }
        }
        catch (Exception E)
        {
            MessageBox.Show("Could Not Login Due to the Error: " + E.Message + "\n" + "Please Check Your Email and Password and Try Again.");
            Connection.Close();
            textBox1.Clear();
            textBox2.Clear();
        }

        }
    }
}
