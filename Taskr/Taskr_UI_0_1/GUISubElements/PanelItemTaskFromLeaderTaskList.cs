using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemTaskFromLeaderTaskList : PanelItemTasksFromLeader
    {
        private System.Windows.Forms.Button buttonEditTask;
        private System.Windows.Forms.Button buttonAssignMember;

        private System.Windows.Forms.Label labelStatus;


        public PanelItemTaskFromLeaderTaskList(DatabaseHandler d, TaskData taskData, TeamLeader teamLeader)
            : base(d, taskData, teamLeader)
        {

            this.buttonEditTask = new System.Windows.Forms.Button();
            this.buttonAssignMember = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();

            this.Controls.Add(this.buttonEditTask);
            this.Controls.Add(this.buttonAssignMember);
            this.Controls.Add(this.labelStatus);

            string taskStatus = d.TaskStatus(taskData);
            this.labelStatus.Text = taskStatus;
            switch (taskStatus)
            {
                case ("Completed"):
                    this.BackColor = Color.BurlyWood;
                    this.buttonAssignMember.Enabled = false;
                    break;
                case ("Overdue"):
                    this.BackColor = Color.DarkRed;
                    break;
                case ("Idle"):
                    this.BackColor = Color.Gainsboro;
                    break;
                case ("Tackled"):
                    this.buttonAssignMember.Enabled = false;
                    this.BackColor = Color.LawnGreen;
                    this.labelStatus.Text += " by \n" + d.GetUserWorkingOnTask(taskData).DisplayName;
                    break;
                case ("Requested"):
                    this.BackColor = Color.Chocolate;
                    break;
                default://Unhandled value
                    this.BackColor = Color.Aqua;
                    break;
            }
            //
            //edit button
            //
            this.buttonEditTask.Location = new System.Drawing.Point(textWidth + 10, 15);
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


            //
            //Label Status
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(textWidth + 25, 110);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 20);
            this.labelStatus.TabIndex = 4;

        }

        private void buttonEditTask_Click(object sender, EventArgs e)
        {
            new EditTaskDetails(d, taskData, teamLeader).Show();
        }

        private void buttonAssignMember_Click(object sender, EventArgs e)
        {
            teamLeader.TabControlVarious.SelectedTab = teamLeader.tabTeamMembers;
            teamLeader.TabControlVarious.SelectedTab.Focus();
            teamLeader.TabControlVarious.SelectedTab.Select();
        }
    }
}
