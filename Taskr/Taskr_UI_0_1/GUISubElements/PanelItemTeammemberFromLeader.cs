using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemTeamMemberFromLeader : System.Windows.Forms.Panel
    {
        
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.PictureBox pictureTask;
        private System.Windows.Forms.Button buttonMoreInfo;
        private System.Windows.Forms.Button buttonAssignTask;

        private int zero = 0;
        private const int textWidth = 580;

        private DatabaseHandler d;
        private ProjectData projectData;
        private TeamLeader teamLeader;
        private UserData userData;

        public PanelItemTeamMemberFromLeader(DatabaseHandler d, UserData userData, TeamLeader teamLeader)
        {
            //
            //for resourecs
            //
            this.d = d;
            this.projectData = projectData;
            this.teamLeader = teamLeader;
            this.userData = userData;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
            //
            //initialize component classes
            //
            this.pictureTask = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonMoreInfo = new System.Windows.Forms.Button();
            this.buttonAssignTask = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureTask);
            this.Controls.Add(this.buttonMoreInfo);
            this.Controls.Add(this.buttonAssignTask);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "panel";
            this.Size = new System.Drawing.Size(720, 157);
            this.TabIndex = 1;
            // 
            // pictureTask
            // 

            this.pictureTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTask.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureTask.Location = new System.Drawing.Point(15, 14);
            this.pictureTask.Name = "pictureTask";
            this.pictureTask.Size = new System.Drawing.Size(128, 128);
            this.pictureTask.TabIndex = 0;
            this.pictureTask.TabStop = false;
            try
            {
                this.pictureTask.Load(this.userData.AvatarURL);
                zero = 150;
            }
            catch
            {
                //this.pictureTask.Image = this.pictureTask.ErrorImage;
                this.pictureTask.Enabled = false;
                this.pictureTask.Visible = false;
                zero = 15;
            }

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = true;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(zero, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = this.userData.DisplayName;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(textWidth - zero, 34);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = true;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Location = new System.Drawing.Point(zero, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = this.userData.Notes;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(textWidth - zero, 87);
            this.textBoxDescription.TabIndex = 5;

            //
            //View Details
            //
            this.buttonMoreInfo.Location = new System.Drawing.Point(textWidth + 10, 15);
            this.buttonMoreInfo.Name = "buttonMoreInfo";
            this.buttonMoreInfo.Size = new System.Drawing.Size(120, 35);
            this.buttonMoreInfo.TabIndex = 2;
            this.buttonMoreInfo.Text = "More Info";
            this.buttonMoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoreInfo.UseVisualStyleBackColor = true;
            this.buttonMoreInfo.Click += new System.EventHandler(this.buttonMoreInfo_Click);

            //
            //assign
            //
            this.buttonAssignTask.Location = new System.Drawing.Point(textWidth + 10, 60);
            this.buttonAssignTask.Name = "buttonAssignTask";
            this.buttonAssignTask.Size = new System.Drawing.Size(120, 35);
            this.buttonAssignTask.TabIndex = 2;
            this.buttonAssignTask.Text = "Assign Member";
            this.buttonAssignTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignTask.UseVisualStyleBackColor = true;
            this.buttonAssignTask.Click += new System.EventHandler(this.buttonAssignTask_Click);

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            EditUserData editor=new EditUserData(d,userData);
            editor.Show();
        }

        private void buttonAssignTask_Click(object sender, EventArgs e)
        {
            
        }


    }
}
