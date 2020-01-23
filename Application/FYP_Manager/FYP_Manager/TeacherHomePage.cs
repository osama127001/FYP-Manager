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
    public partial class TeacherHomePage : Form
    {
        int Teacher_ID = -1;
        String Disp;
        public TeacherHomePage(int ID, String Name, String T_Disc, String T_Desigg)
        {
            InitializeComponent();
            label7.Text = ID.ToString();
            label6.Text = T_Desigg.ToString();
            label5.Text = T_Disc.ToString();
            label4.Text = Name.ToString();

            Teacher_ID = ID;
            Disp = T_Disc;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateProjectForm createProjectForm = new CreateProjectForm(Teacher_ID);
            createProjectForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAssignedProjects VAssignedProjects = new ViewAssignedProjects(Teacher_ID);
            VAssignedProjects.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {                       
            ViewUnassignedProjects VunAssignedProjects = new ViewUnassignedProjects(Teacher_ID);
            VunAssignedProjects.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteProject DProject = new DeleteProject(Teacher_ID);
            DProject.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewMyProjects viewMyProjects = new ViewMyProjects(Teacher_ID);
            viewMyProjects.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewDepartmentProjects VDepartmentProjects = new ViewDepartmentProjects();
            VDepartmentProjects.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TeacherHomePage_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FacultAddStudent FAStudent = new FacultAddStudent(Teacher_ID, Disp);
            FAStudent.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddGroupMember AGMember = new AddGroupMember(Teacher_ID, Disp);
            AGMember.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Delete_Member DMember = new Delete_Member(Teacher_ID);
            DMember.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FacultyAddTask FATask = new FacultyAddTask(Teacher_ID);
            FATask.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeleteTask DTask = new DeleteTask(Teacher_ID);
            DTask.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Teacherlogin TLogin = new Teacherlogin();
            this.Close();
            TLogin.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Faculty_Chat FC = new Faculty_Chat(Teacher_ID);
            FC.ShowDialog();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            FacultyViewTasks VTasks = new FacultyViewTasks(Teacher_ID);
            VTasks.ShowDialog();
        }
    }
}
