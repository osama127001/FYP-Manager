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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectionForm SelectionForm1 = new SelectionForm();
            this.Hide();
            SelectionForm1.Show();      
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
