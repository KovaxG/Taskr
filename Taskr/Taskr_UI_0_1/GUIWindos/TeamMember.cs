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
using System.Threading;

namespace Taskr_UI_0_1
{
    public partial class TeamMember : Form
    {
        private DatabaseHandler d;
        private Delegate sp;
        private Delegate rp;
        private Delegate aw;
       
        //Default label for Active Task Panel
        Label lb = new Label();

        public TeamMember(DatabaseHandler d)
        {
            this.d = d;
            InitializeComponent();

            //Set default label for Active Task Panel
            lb.Text = "Current user has no active tasks";
            lb.Size = new System.Drawing.Size(300, 100);
            // End of set

            //Delegate of method SetPanel
            SetPanelPtr sp = new SetPanelPtr(SetPanel);
            this.sp = sp;
            //End

            //Delegate of method RemovePanel
            RemovePanelPtr rp = new RemovePanelPtr(RemovePanel);
            this.rp = rp;
            //End

            //Delegate to method AddWaiting
            AddWaitingPtr aw = new AddWaitingPtr(AddWaiting);
            this.aw = aw;
            //End

            reInitializeContent();
        }

        public delegate void SetPanelPtr();
        public delegate void RemovePanelPtr();
        public delegate void AddWaitingPtr();
        
        public void reInitializeContent()
        {
            disposeElements();
            
            loadAvatarArea();

            if (d.User.ActiveTask != 0)
            {
                SetPanel();
            }
            else
            {
                panelActiveTask.Controls.Add(lb);
            }

            AddWaiting();

            //TaskData td = new TaskData();
            List<TaskData> tdl = d.GetTasksForProject(d.GetCurrentProject());
            List<TaskData> tdr = d.GetRequestedTasks();

            if (tdl != null)
            {
                foreach (TaskData td in tdl)
                {
                    if (tdr.Contains(td))
                    {
                        PanelItem panelSomething = new PanelItem(flowLayoutPanelActiveTasks.Size.Width,
                            (int) (flowLayoutPanelActiveTasks.Size.Height/3), 3, 3, td, true, d, sp, aw, true);
                        flowLayoutPanelActiveTasks.Controls.Add(panelSomething.GetPanel());
                    }
                    else
                    {
                        PanelItem panelSomething = new PanelItem(flowLayoutPanelActiveTasks.Size.Width,
                            (int)(flowLayoutPanelActiveTasks.Size.Height / 3), 3, 3, td, true, d, sp, aw, false);
                        flowLayoutPanelActiveTasks.Controls.Add(panelSomething.GetPanel());
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (d.User.ActiveTask == 0)
            {
                MessageBox.Show("You have no task that is currently active!");
            }
            else
            {
                UploadFiles uf = new UploadFiles(d, sp, aw, rp);
                uf.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (d.User.ActiveTask == 0)
            {
                MessageBox.Show("You have no task that is currently active!");
            }
            else
            {
                ExtendTask et = new ExtendTask(d);
                et.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (d.User.ActiveTask == 0)
            {
                MessageBox.Show("You have no task that is currently active!");
            }
            else
            {
                DropTask dt = new DropTask(d, rp, sp, aw);
                dt.Show();
            }
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
                new FreeLancer(d).ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to drop task");
            }
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {

            EditUserData eu = new EditUserData(d);

            if (eu.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Your details have been successfully changed");
                loadAvatarArea();
            }
            else
            {
                //MessageBox.Show("Change cancelled");
            }
        }
        
        private void loadAvatarArea()
        {
            new Thread(() =>
            {
                try
                {
                    pictureBoxTeamMemberAvatar.Load(d.User.AvatarURL);
                }
                catch
                {
                    pictureBoxTeamMemberAvatar.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
                }
            }).Start();
            
            labelTeamMemberDisplayName.Size = new System.Drawing.Size(pictureBoxTeamMemberAvatar.Size.Width, 16);
            labelTeamMemberDisplayName.Text = d.User.DisplayName; //does not change size in current Build

        }

        private void buttonRefreshTasks_Click(object sender, EventArgs e)
        {
            reInitializeContent();
        }

        private void disposeElements()
        {
            foreach (System.Windows.Forms.Control cc in this.flowLayoutPanelActiveTasks.Controls)
            {
                cc.Dispose();
            }
            this.flowLayoutPanelActiveTasks.Controls.Clear();

            /*foreach (System.Windows.Forms.Control cc in this.flowLayoutPanelNextTasks.Controls)
            {
                cc.Dispose();
            }
            this.flowLayoutPanelNextTasks.Controls.Clear();

            panelActiveTask.Dispose();*/

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
        }

        public void SetPanel()
        {
            TaskData td = d.GetActiveTask();
           /* if (td == new TaskData())
            {
                panelActiveTask.Controls.Add(lb);
                lb.Text = "Current user has no active tasks";
            }
            else
            {*/

                panelActiveTask.Controls.Remove(lb);
                PanelItem panelSomething = new PanelItem((panelActiveTask.Size.Width + 20), (panelActiveTask.Size.Height - 5), 3, 3, td, false, aw, d);
                panelActiveTask.Controls.Add(panelSomething.GetPanel());
            
            //}
        }

        public void RemovePanel()
        {
            //MessageBox.Show("Reached RemovePanel");
            foreach (Control item in panelActiveTask.Controls.OfType<Control>())
            {
                if (item.Name == "ActiveTaskPanel")
                {
                    panelActiveTask.Controls.Remove(item);
                }
            }
            panelActiveTask.Controls.Add(lb);
        }

        public void AddWaiting()
        {
            List<TaskData> tdl = d.GetRequestedTasks();
            flowLayoutPanelNextTasks.Controls.Clear();

            if (tdl != null)
            {
                foreach (TaskData tdn in tdl)
                {
                    PanelItem panelSomething = new PanelItem(flowLayoutPanelNextTasks.Size.Width - 6, flowLayoutPanelNextTasks.Size.Height - 6, 3, 3, tdn, true, aw, d);
                    flowLayoutPanelNextTasks.Controls.Add(panelSomething.GetPanel());
                }
            }
        }
        
    }
}
