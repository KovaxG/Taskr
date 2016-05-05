using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    class PanelItemActiveProjects
    {
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonViewTasks;
        private System.Windows.Forms.Button buttonJoinProjects;
        private System.Windows.Forms.PictureBox pictureProject;

        private ProjectData pd;
        private DatabaseHandler d;

        Taskr_UI_0_1.UserAppS us;

        public System.Windows.Forms.Panel getPanel()
        {
            return this.panel;
        }

        public PanelItemActiveProjects( ProjectData pd, DatabaseHandler d,UserAppS us)
        {
            this.us = us;   
            this.pd = pd;
            this.d = d;
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAppS));
            //
            //initialize component classes
            //
            this.panel = new System.Windows.Forms.Panel();
            this.pictureProject = new System.Windows.Forms.PictureBox();
            this.buttonJoinProjects = new System.Windows.Forms.Button();
            this.buttonViewTasks = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();

            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkGray;
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.textBoxTitle);
            this.panel.Controls.Add(this.buttonViewTasks);
            this.panel.Controls.Add(this.buttonJoinProjects);
            this.panel.Controls.Add(this.pictureProject);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(722, 157);
            this.panel.TabIndex = 1;
            // 
            // pictureProject
            // 

            this.pictureProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProject.ErrorImage = ((System.Drawing.Image)(resources.GetObject("resources/X.png")));
            this.pictureProject.Location = new System.Drawing.Point(15, 14);
            this.pictureProject.Name = "pictureProject";
            this.pictureProject.Size = new System.Drawing.Size(128, 128);
            this.pictureProject.TabIndex = 0;
            this.pictureProject.TabStop = false;
            try {
                this.pictureProject.Load(pd.imageURL);
            }
            catch
            {
                this.pictureProject.Image = this.pictureProject.ErrorImage;
            }
            // 
            // buttonJoinProjects
            // 
            this.buttonJoinProjects.Location = new System.Drawing.Point(613, 107);
            this.buttonJoinProjects.Name = "buttonJoinProjects";
            this.buttonJoinProjects.Size = new System.Drawing.Size(95, 35);
            this.buttonJoinProjects.TabIndex = 1;
            this.buttonJoinProjects.Text = "Join Project";
            this.buttonJoinProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJoinProjects.UseVisualStyleBackColor = true;
            this.buttonJoinProjects.Click += new System.EventHandler(this.buttonJoinProjects_Click);
            // 
            // buttonViewTasks
            // 
            this.buttonViewTasks.Location = new System.Drawing.Point(613, 55);
            this.buttonViewTasks.Name = "buttonViewTasks";
            this.buttonViewTasks.Size = new System.Drawing.Size(95, 35);
            this.buttonViewTasks.TabIndex = 2;
            this.buttonViewTasks.Text = "View Tasks";
            this.buttonViewTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            this.buttonViewTasks.UseVisualStyleBackColor = true;
            this.buttonViewTasks.Click += new System.EventHandler(this.buttonViewTaks_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(149, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = pd.Title;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(319, 34);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(150, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = pd.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(457, 87);
            this.textBoxDescription.TabIndex = 5;

            this.panel.ResumeLayout();
            this.panel.PerformLayout();
        }

        private void buttonViewTaks_Click(object sender, EventArgs e)
        {
            TaskView TasksForm = new TaskView(pd, d,us);
           
            TasksForm.Show();
        }
        private void buttonJoinProjects_Click(object sender, EventArgs e)
        {
            int err = (d.ProjectJoinRequest(pd)?0:1);
            switch (err)
            {
                case 0:
                    MessageBox.Show("Project Request Sent");
                    us.reInitializeContents();
                    break;
                default:
                    MessageBox.Show("Please try restarting the application. \nIf the error persists, please contact the support team",
                        "Unlabeled error " + err);
                    break;
            }
        }
        /*override public string ToString()
        {
            return pd.getID().ToString()+ pd.title;
            
        }*/
    }
}

