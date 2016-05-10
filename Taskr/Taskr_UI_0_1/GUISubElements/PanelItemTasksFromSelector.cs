using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemTasksFromSelector : PanelItemTasksFromLeader
    {

        private UserData teamMember;
        private AsignTaskWindows asignTaskWindows;

        /// <summary>
        /// This is meant to be used for task selection
        /// </summary>
        /// <param name="d"></param>
        /// <param name="td"></param>
        /// <param name="teamLeader">for refresh calls</param>
        /// <param name="teamMember">the user to asign the task to</param>
        public PanelItemTasksFromSelector(DatabaseHandler d, TaskData taskData, TeamLeader teamLeader, UserData teamMember, AsignTaskWindows asignTaskWindows) :base(d,taskData,teamLeader)
        {
            this.teamMember = teamMember;
            this.asignTaskWindows = asignTaskWindows;

           // base.InitializeComponents();
            EnableTaskAssignmentMode();
        }

        public void EnableTaskAssignmentMode()
        {
            this.Size = new System.Drawing.Size(600, 157);
            this.Click += new System.EventHandler(Panel_Click);
            this.pictureTask.Click += new System.EventHandler(Panel_Click);
            this.textBoxTitle.Click += new System.EventHandler(Panel_Click);
            this.textBoxDescription.Click += new System.EventHandler(Panel_Click);
        }

        public void Panel_Click(object sender, EventArgs e)
        {
            int activeTask = teamMember.ActiveTask;
            teamMember.ActiveTask = taskData.ID;
            if (d.GrantTask(taskData, teamMember))
            {
                MessageBox.Show(taskData.Title + " assigned to " + teamMember.DisplayName, "Assigment successful");

            }
            else
            {
                MessageBox.Show("Failed to assigned task", "Error");
                teamMember.ActiveTask = activeTask;
            }

            asignTaskWindows.DialogResult = DialogResult.OK;
            asignTaskWindows.Close();
            asignTaskWindows.Dispose();
            teamLeader.InitializeTaskList();
            teamLeader.InitializeTeamMemberList();
        }
    }
}
