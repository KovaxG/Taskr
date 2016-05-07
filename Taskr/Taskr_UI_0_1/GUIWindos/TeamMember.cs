using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DataBase;
using Taskr_UI_0_1;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TeamMember
{
    public partial class TeamMember : Form
    {
        private DatabaseHandler d;
        public TeamMember(DatabaseHandler d)
        {
            this.d = d;
            InitializeComponent();


            //TaskData td = new TaskData();
            List<TaskData> tdl = d.GetTasksForProject(d.GetCurrentProject());
            if (tdl != null)
            {
                foreach (TaskData td in tdl)
                {
                    PanelItem panelSomething = new PanelItem(flowLayoutPanel1.Size.Width, (int)(flowLayoutPanel1.Size.Height / 3), 3, 3, td);
                    flowLayoutPanel1.Controls.Add(panelSomething.GetPanel());
                }
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UploadFiles uf = new UploadFiles();
            uf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExtendTask et = new ExtendTask();
            et.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DropTask dt = new DropTask();
            dt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check if DB actually returns what like in other places!!!!
            if (d.LeaveProject())
            {
                //d.RefreshUser(d.User);
                this.Close();
                this.Dispose();
                new UserAppS(d).ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to drop task");
            }
        }
    }
}
