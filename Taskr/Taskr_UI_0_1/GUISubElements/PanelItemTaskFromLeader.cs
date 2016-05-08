using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1
{
    class PanelItemTasksFromLeader : Panel
    {
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.PictureBox pictureTask;
        private System.Windows.Forms.Button buttonEditTask;
        private System.Windows.Forms.Button buttonAssignMember;

        private int zero = 0;
        private const int textWidth = 580;

        private DatabaseHandler d;
        private TaskData td;
        private TeamLeader teamLeader;
        private UserData teamMember;
        private AsignTaskWindows asignTaskWindows;

        public PanelItemTasksFromLeader(DatabaseHandler d, TaskData td, TeamLeader teamLeader)
        {
            
            this.d = d;
            this.td = td;
            this.teamLeader = teamLeader;
            InitializeComponents();
        }

        /// <summary>
        /// This is meant to be used for task selection
        /// </summary>
        /// <param name="d"></param>
        /// <param name="td"></param>
        /// <param name="teamLeader">for refresh calls</param>
        /// <param name="teamMember">the user to asign the task to</param>
        public PanelItemTasksFromLeader(DatabaseHandler d, TaskData td, TeamLeader teamLeader, UserData teamMember,AsignTaskWindows asignTaskWindows)
        {

            this.d = d;
            this.td = td;
            this.teamLeader = teamLeader;
            this.teamMember = teamMember;
            this.asignTaskWindows = asignTaskWindows;

            InitializeComponents();
            EnableTaskAssignmentMode();
        }
        private void InitializeComponents()
        {
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
            //
            //initialize component classes
            //
            this.pictureTask = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonEditTask = new System.Windows.Forms.Button();
            this.buttonAssignMember= new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureTask);
            this.Controls.Add(this.buttonEditTask);
            this.Controls.Add(this.buttonAssignMember);
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
                this.pictureTask.Load(td.ImageURL);
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
            this.textBoxTitle.Text = td.Title;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(textWidth-zero, 34);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = true;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Location = new System.Drawing.Point(zero, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = td.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(textWidth - zero, 87);
            this.textBoxDescription.TabIndex = 5;

            //
            //edit button
            //
            this.buttonEditTask.Location = new System.Drawing.Point(textWidth+10, 15);
            this.buttonEditTask.Name = "buttonEditTask";
            this.buttonEditTask.Size = new System.Drawing.Size(120, 35);
            this.buttonEditTask.TabIndex = 2;
            this.buttonEditTask.Text = "Edit Task";
            this.buttonEditTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditTask.UseVisualStyleBackColor = true;
            this.buttonEditTask.Click += new System.EventHandler(this.buttonEditTask_Click);

            //
            //assign
            //
            this.buttonAssignMember.Location = new System.Drawing.Point(textWidth + 10, 60);
            this.buttonAssignMember.Name = "buttonAssignMember";
            this.buttonAssignMember.Size = new System.Drawing.Size(120, 35);
            this.buttonAssignMember.TabIndex = 2;
            this.buttonAssignMember.Text = "Assign Member";
            this.buttonAssignMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignMember.UseVisualStyleBackColor = true;
            this.buttonAssignMember.Click += new System.EventHandler(this.buttonAssignMember_Click);

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
            new EditTaskDetails(d,td,teamLeader).Show();
        }

        private void buttonAssignMember_Click(object sender, EventArgs e)
        {
            teamLeader.TabControlVarious.SelectedTab = teamLeader.tabTeamMembers;
            teamLeader.TabControlVarious.SelectedTab.Focus();
            teamLeader.TabControlVarious.SelectedTab.Select();
        }

        public void EnableTaskAssignmentMode()
        {
            buttonEditTask.Visible = false;
            buttonEditTask.Enabled = false;
            buttonAssignMember.Visible = false;
            buttonAssignMember.Enabled = false;
            this.Size = new System.Drawing.Size(600, 157);
            this.Click+=new System.EventHandler(Panel_Click);
        }

        public void Panel_Click(object sender, EventArgs e)
        {
            /*int activeTask = teamMember.ActiveTask;
            teamMember.ActiveTask = td.ID;
            if (d.UpdateUser(teamMember))
            {
                MessageBox.Show(td.Title + " assigned to " + teamMember.DisplayName, "Assigment successful");

            }
            else
            {
                MessageBox.Show("Failed to assigned task", "Error");
                teamMember.ActiveTask = activeTask;
            }*/
            
            asignTaskWindows.DialogResult = DialogResult.OK;
            asignTaskWindows.Close();
            asignTaskWindows.Dispose();
            teamLeader.InitializeTaskList();
            teamLeader.InitializeTeamMemberList();
        }
    }
}
