using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    class PanelItemTasks //: Panel
    {
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        //private System.Windows.Forms.Button buttonViewTasks;
        //private System.Windows.Forms.Button buttonJoinProjects;
        private System.Windows.Forms.PictureBox pictureTask;

        public System.Windows.Forms.Panel getPanel()
        {
            return this.panel;
        }
        
        public PanelItemTasks( TaskData td)
        {
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAppS));
            //
            //initialize component classes
            //
            this.panel = new System.Windows.Forms.Panel();
            this.pictureTask = new System.Windows.Forms.PictureBox();
            //this.buttonJoinProjects = new System.Windows.Forms.Button();
            //this.buttonViewTasks = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            //
            //add panel to tab
            //
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkGray;
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.textBoxTitle);
            //this.panel.Controls.Add(this.buttonViewTasks);
            //this.panel.Controls.Add(this.buttonJoinProjects);
            this.panel.Controls.Add(this.pictureTask);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(620, 157);
            this.panel.TabIndex = 1;
            // 
            // pictureTask
            // 

            this.pictureTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTask.ErrorImage = ((System.Drawing.Image)(resources.GetObject("X.png")));
            this.pictureTask.Location = new System.Drawing.Point(15, 14);
            this.pictureTask.Name = "pictureTask";
            this.pictureTask.Size = new System.Drawing.Size(128, 128);
            this.pictureTask.TabIndex = 0;
            this.pictureTask.TabStop = false;
            try {
                this.pictureTask.Load(td.imageURL);
            }
            catch
            {
                this.pictureTask.Image = this.pictureTask.ErrorImage;
            }
            // 
            // buttonJoinProjects
            // 
            //this.buttonJoinProjects.Location = new System.Drawing.Point(613, 107);
            //this.buttonJoinProjects.Name = "buttonJoinProjects";
            //this.buttonJoinProjects.Size = new System.Drawing.Size(95, 35);
            //this.buttonJoinProjects.TabIndex = 1;
            //this.buttonJoinProjects.Text = "Join Project";
            //this.buttonJoinProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.buttonJoinProjects.UseVisualStyleBackColor = true;
            //// 
            //// buttonViewTasks
            //// 
            //this.buttonViewTasks.Location = new System.Drawing.Point(613, 55);
            //this.buttonViewTasks.Name = "buttonViewTasks";
            //this.buttonViewTasks.Size = new System.Drawing.Size(95, 35);
            //this.buttonViewTasks.TabIndex = 2;
            //this.buttonViewTasks.Text = "View Tasks";
            //this.buttonViewTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            //this.buttonViewTasks.UseVisualStyleBackColor = true;
            //this.buttonViewTasks.Click += new System.EventHandler(this.buttonViewTasks_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(149, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = td.Title;
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
            this.textBoxDescription.Text = td.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(457, 87);
            this.textBoxDescription.TabIndex = 5;

            this.panel.ResumeLayout();
            this.panel.PerformLayout();
        }



    }
}
