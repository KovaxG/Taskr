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
using MessageBox = System.Windows.Forms.MessageBox;

namespace Taskr_UI_0_1
{
    public partial class TaskView : Form
    {
     
        DatabaseHandler d;
        FreeLancer us;
        ProjectData pd;
        private List<TaskData> tdl;
        public TaskView(ProjectData pd,  DatabaseHandler d, FreeLancer us)
        {
           
           tdl = d.GetTasksForProject(pd);

            if (!tdl.Any())
                throw new Exception("The are no available tasks for this project");
           this.us = us;
           this.d = d;
           this.pd = pd;
           InitializeComponent();
            
        }

        protected override void OnShown(EventArgs e)
        {
            if (tdl != null)
            {
                base.OnShown(e);
                foreach (TaskData td in tdl)
                {
                    PanelItemTasks item = new PanelItemTasks(td);
                    this.flowLayoutPanel1.Controls.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
