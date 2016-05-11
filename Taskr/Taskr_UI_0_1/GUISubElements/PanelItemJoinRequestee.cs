using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBase;
using System.Windows.Markup;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemJoinRequestee :PanelItemUser
    {

        private System.Windows.Forms.Button buttonAcceptJoinRequest;


        public PanelItemJoinRequestee(DatabaseHandler d, UserData userData, ProjectData projectData,
            TeamLeader teamLeader) : base(d, userData, projectData, teamLeader)
        {
            this.buttonAcceptJoinRequest = new System.Windows.Forms.Button();

            this.Controls.Add(this.buttonAcceptJoinRequest);

            //
            //Accept
            //
            this.buttonAcceptJoinRequest.Location = new System.Drawing.Point(textWidth + 10, 60);
            this.buttonAcceptJoinRequest.Name = "buttonAcceptJoinRequest";
            this.buttonAcceptJoinRequest.Size = new System.Drawing.Size(120, 35);
            this.buttonAcceptJoinRequest.TabIndex = 2;
            this.buttonAcceptJoinRequest.Text = "Accept Request";
            this.buttonAcceptJoinRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcceptJoinRequest.UseVisualStyleBackColor = true;
            this.buttonAcceptJoinRequest.Click += new System.EventHandler(this.buttonAcceptJoinRequest_Click);

            base.ResumeLayout();
            base.PerformLayout();
        }

        private void buttonAcceptJoinRequest_Click(object sender, EventArgs e)
        {

            if (d.AcceptUserProjectRequest(userData))
            {
                MessageBox.Show(userData.DisplayName + " is now part of " + projectData.Title, "Join request accepted");
                teamLeader.InitializeTeamMemberList();
                teamLeader.InitializeJoinRequests();
            }
            else
            {
                MessageBox.Show("Could not accept join request", "Request rejected");
            }
        }
    }
}
