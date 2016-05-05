using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    public partial class TaskView : Form
    {
        DatabaseHandler d;
        UserAppS us;
        ProjectData pd;
        public TaskView(ProjectData pd,  DatabaseHandler d, UserAppS us)
        {
            this.us = us;
            this.d = d;
            this.pd = pd;
            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            iterateTask(pd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void iterateTask(ProjectData pd)
        {

           /* d.resetTaskIterator();
                    TaskData td;// = new ProjectData();
                    td = new TaskData();
                    td = d.getNextTaskData();
                    while (td != null)
                    {
                        this.flowLayoutPanel1.Controls.Add(new PanelItemTasks(td).getPanel());
                        td = d.getNextTaskData();
                    }*/
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            int err = (d.ProjectJoinRequest(pd)?0:1);
            switch (err)
            {
                case 0:
                    MessageBox.Show("Project Request Sent");
                    us.reInitializeContents();
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Please try restarting the application. \nIf the error persists, please contact the support team",
                        "Unlabeled error " + err);
                    break;
            }
        }
    }
}
