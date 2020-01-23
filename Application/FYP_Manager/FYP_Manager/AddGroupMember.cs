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
    public partial class AddGroupMember : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID = -1;
        String Disp = "NULL";
        public AddGroupMember(int F_ID, String D)
        {
            InitializeComponent();

            Fac_ID = F_ID;
            Disp = D;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand CMD = new SqlCommand("sp_Faculty_Add_GroupMembers_to_Assigned_Projectt", Connection);
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Parameters.AddWithValue("@F_ID", SqlDbType.VarChar).Value = Fac_ID;
                CMD.Parameters.AddWithValue("@P_ID", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                CMD.Parameters.AddWithValue("@S_Reg", SqlDbType.Int).Value = textBox2.Text.Trim(); ;
                CMD.Parameters.AddWithValue("@Disc", SqlDbType.Int).Value = Disp;

                //Setting @param as Output Parameter.
                CMD.Parameters.Add(new SqlParameter("@param", SqlDbType.Int));
                CMD.Parameters["@param"].Direction = ParameterDirection.Output;

                Connection.Open();
                SqlDataReader rdr = CMD.ExecuteReader();
                rdr.Close();

                int Limit = (int)CMD.Parameters["@param"].Value;

                CMD.ExecuteNonQuery();
                Connection.Close();
                if(Limit == 0) { MessageBox.Show("Cannot Add group Members More than 4."); }
            }
            catch (Exception Exp)
            {
                MessageBox.Show("Project not Added due to the Error: " + Exp.Message);
                Connection.Close();
                return;
            }            
        }
    }
}
