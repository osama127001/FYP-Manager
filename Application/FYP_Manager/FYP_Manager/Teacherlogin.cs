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
    public partial class Teacherlogin : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");

        public Teacherlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectionForm selectionForm = new SelectionForm();
            Close();
            selectionForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TeacherID = -1;
            String TeacherName = "NULL";
            String TeacherDesignation = "NULL";
            String TeacherDiscipline = "NULL";
            try
            {
                SqlCommand CMD = new SqlCommand("sp_Faculty_Login", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.Add("@F_Email", SqlDbType.NVarChar, 50).Value = textBox1.Text.Trim();
                CMD.Parameters.Add("@F_Pass", SqlDbType.NVarChar, 50).Value = textBox2.Text.Trim();
                
                //Setting @name as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                CMD.Parameters["@id"].Direction = ParameterDirection.Output;

                //Setting @name as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
                CMD.Parameters["@name"].Direction = ParameterDirection.Output;

                //Setting @Disc as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@Disc", SqlDbType.NVarChar, 3));
                CMD.Parameters["@Disc"].Direction = ParameterDirection.Output;

                //Setting @Desig as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@Desig", SqlDbType.NVarChar, 20));
                CMD.Parameters["@Desig"].Direction = ParameterDirection.Output;

                Connection.Open();
                SqlDataReader rdr = CMD.ExecuteReader();
                rdr.Close();

                TeacherID = (int)CMD.Parameters["@id"].Value;
                TeacherName = Convert.ToString(CMD.Parameters["@name"].Value);
                TeacherDesignation = Convert.ToString(CMD.Parameters["@Desig"].Value);
                TeacherDiscipline = Convert.ToString(CMD.Parameters["@Disc"].Value);
          
                CMD.ExecuteNonQuery();
                Connection.Close();

                if(TeacherName != "NULL" && TeacherDesignation != "NULL" && TeacherDiscipline != "NULL")
                {
                    TeacherHomePage THomePage = new TeacherHomePage(TeacherID, TeacherName, TeacherDiscipline, TeacherDesignation);
                    this.Hide();
                    THomePage.ShowDialog();
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("Could Not Login Due to the Error: " + E.Message + "\n" + "Please Check Your Email and Password and Try Again.");
                Connection.Close();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
