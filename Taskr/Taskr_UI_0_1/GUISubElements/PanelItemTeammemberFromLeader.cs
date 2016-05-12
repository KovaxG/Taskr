using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemTeamMemberFromLeader : PanelItemUser
    {

        private System.Windows.Forms.Button buttonAssignTask;

        public PanelItemTeamMemberFromLeader(DatabaseHandler d, UserData userData, ProjectData projectData, TeamLeader teamLeader) :base(d,userData,projectData,teamLeader)
        {

            this.buttonAssignTask = new System.Windows.Forms.Button();

            this.Controls.Add(this.buttonAssignTask);

            //
            //assign
            //
            this.buttonAssignTask.Location = new System.Drawing.Point(textWidth + 10, 60);
            this.buttonAssignTask.Name = "buttonAssignTask";
            this.buttonAssignTask.Size = new System.Drawing.Size(120, 35);
            this.buttonAssignTask.TabIndex = 2;
            this.buttonAssignTask.Text = "Assign Task";
            this.buttonAssignTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignTask.UseVisualStyleBackColor = true;
            this.buttonAssignTask.Click += new System.EventHandler(this.buttonAssignTask_Click);

            

            if (userData.ActiveTask != 0)
            {
                this.buttonAssignTask.Enabled = false;
                this.BackColor = Color.DarkOrange;
                this.labelStatus.Text += "\nTackling\n \"" +d.GetActiveTaskForUser(userData).Title+"\"";
            }
            else
            {
                
            }
        }

        private void buttonAssignTask_Click(object sender, EventArgs e)
        {
            if (d.GetTasksForProject(projectData).FindAll(t => t.CompletedBy == DBDefaults.DefaultId && d.GetUserWorkingOnTask(t) == null).Any())
            {
                new AsignTaskWindows(d, teamLeader, projectData, userData).ShowDialog();
            }
            else
            {
                //MessageBox.Show("There are no free tasks to assign","No tasks");
            }
        }
    }
}
