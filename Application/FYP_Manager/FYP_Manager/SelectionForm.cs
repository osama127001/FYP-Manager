using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_Manager
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
        }

        Form1 F1 = new Form1();
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            F1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacherlogin teacherlogin = new Teacherlogin();
            this.Hide();
            teacherlogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentLogin studentLogin = new StudentLogin();
            this.Hide();
            studentLogin.Show();
        }
    }
}
