using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    class PanelItemActiveProjects : System.Windows.Forms.Panel
    {
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonViewTasks;
        private System.Windows.Forms.Button buttonJoinProjects;
        private System.Windows.Forms.Button buttonCancelJoinProject;
        private System.Windows.Forms.PictureBox pictureProject;

        private ProjectData pd;
        private DatabaseHandler d;

        private bool HasAlreadyRequestedJoin;

        // this is necessary to do interface calls from instantiator object, such as
        // refreshing the interface in the main GUI
        Taskr_UI_0_1.FreeLancer us;

        /// <summary>
        /// Item that will be used to populate flowLayoutPanels. They should be 
        /// put into a List or other collection
        /// </summary>
        /// <param name="pd">The project that the item will represent</param>
        /// <param name="d">The databasehandler wich contains the projects and the data of the user</param>
        /// <param name="us">The window from which it is instantiated. Necessary to call refresh from said window</param>
        public PanelItemActiveProjects( ProjectData pd, DatabaseHandler d,FreeLancer us)
        {
            this.us = us;   
            this.pd = pd;
            this.d = d;

            HasAlreadyRequestedJoin = d.HasAlreadyRequestedJoin(pd);
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
            //
            //initialize component classes
            //
            this.pictureProject = new System.Windows.Forms.PictureBox();
            this.buttonJoinProjects = new System.Windows.Forms.Button();
            this.buttonCancelJoinProject = new System.Windows.Forms.Button();
            this.buttonViewTasks = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            if (HasAlreadyRequestedJoin)
            {
                this.BackColor = System.Drawing.Color.Aquamarine;
            }
            else
            {
                this.BackColor = System.Drawing.Color.DarkGray;
            }
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonViewTasks);
            this.Controls.Add(this.buttonJoinProjects);
            this.Controls.Add(this.buttonCancelJoinProject);
            this.Controls.Add(this.pictureProject);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "panel";
            this.Size = new System.Drawing.Size(722, 157);
            this.TabIndex = 1;
            // 
            // pictureProject
            // 
            this.pictureProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProject.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureProject.Location = new System.Drawing.Point(15, 14);
            this.pictureProject.Name = "pictureProject";
            this.pictureProject.Size = new System.Drawing.Size(128, 128);
            this.pictureProject.TabIndex = 0;
            this.pictureProject.TabStop = false;

            new Thread(() =>
            {
                try
                {
                    this.pictureProject.Load(pd.ImageURL);
                }
                catch
                {
                    this.pictureProject.Image = this.pictureProject.ErrorImage;
                }
            }).Start();

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
            if (HasAlreadyRequestedJoin)
            {
                this.buttonJoinProjects.Enabled = false;
                this.buttonJoinProjects.Visible = false;
            }
            // 
            // buttonCancelJoinProject
            // 
            this.buttonCancelJoinProject.Location = new System.Drawing.Point(613, 107);
            this.buttonCancelJoinProject.Name = "buttonCancelJoinProject";
            this.buttonCancelJoinProject.Size = new System.Drawing.Size(95, 35);
            this.buttonCancelJoinProject.TabIndex = 1;
            this.buttonCancelJoinProject.Text = "Rescind";
            this.buttonCancelJoinProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelJoinProject.UseVisualStyleBackColor = true;
            this.buttonCancelJoinProject.Click += new System.EventHandler(this.buttonCancelJoinProject_Click);
            if (!HasAlreadyRequestedJoin)
            {
                this.buttonCancelJoinProject.Enabled = false;
                this.buttonCancelJoinProject.Visible = false;
            }
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
            this.textBoxTitle.ReadOnly = true;
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
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Location = new System.Drawing.Point(150, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = pd.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(457, 87);
            this.textBoxDescription.TabIndex = 5;

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void buttonViewTaks_Click(object sender, EventArgs e)
        {
            try
            {
                TaskView taskView = new TaskView(pd, d, us);
                taskView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not load tasks");
            }

        }

        /// <summary>
        /// Attempts to join the project
        /// </summary>
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

        private void buttonCancelJoinProject_Click(object sender, EventArgs e)
        {
            if (d.CancelProjectJoinRequest(pd))
            {
                MessageBox.Show("Project Join Request succesfully rescinded", "Success");
                us.reInitializeContents();
            }
            else
            {
                MessageBox.Show("Could not rescind Request. Try refreshing project list or restarting the application","Error");
            }
        }
        public override string ToString()
        {
            return textBoxTitle.Text;
        }
    }
}

