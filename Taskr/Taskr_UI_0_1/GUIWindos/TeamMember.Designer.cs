namespace Taskr_UI_0_1
{
    partial class TeamMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamMember));
            this.panelTeamMemberSide = new System.Windows.Forms.Panel();
            this.buttonExitTeamMember = new System.Windows.Forms.Button();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.labelTeamMemberDisplayName = new System.Windows.Forms.Label();
            this.pictureBoxTeamMemberAvatar = new System.Windows.Forms.PictureBox();
            this.tabControlTeamMember = new System.Windows.Forms.TabControl();
            this.tabActiveTasks = new System.Windows.Forms.TabPage();
            this.buttonLeaveProject = new System.Windows.Forms.Button();
            this.flowLayoutPanelActiveTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMyTasks = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelNextTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelActiveTask = new System.Windows.Forms.Panel();
            this.buttonFinalizeTask = new System.Windows.Forms.Button();
            this.buttonExtendTaskDeadline = new System.Windows.Forms.Button();
            this.buttonDropTask = new System.Windows.Forms.Button();
            this.buttonRefreshTasks = new System.Windows.Forms.Button();
            this.panelTeamMemberSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamMemberAvatar)).BeginInit();
            this.tabControlTeamMember.SuspendLayout();
            this.tabActiveTasks.SuspendLayout();
            this.tabMyTasks.SuspendLayout();
            this.panelActiveTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTeamMemberSide
            // 
            this.panelTeamMemberSide.Controls.Add(this.buttonExitTeamMember);
            this.panelTeamMemberSide.Controls.Add(this.buttonEditProfile);
            this.panelTeamMemberSide.Controls.Add(this.labelTeamMemberDisplayName);
            this.panelTeamMemberSide.Controls.Add(this.pictureBoxTeamMemberAvatar);
            this.panelTeamMemberSide.Location = new System.Drawing.Point(13, 13);
            this.panelTeamMemberSide.Name = "panelTeamMemberSide";
            this.panelTeamMemberSide.Size = new System.Drawing.Size(167, 547);
            this.panelTeamMemberSide.TabIndex = 0;
            // 
            // buttonExitTeamMember
            // 
            this.buttonExitTeamMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitTeamMember.Location = new System.Drawing.Point(48, 491);
            this.buttonExitTeamMember.Name = "buttonExitTeamMember";
            this.buttonExitTeamMember.Size = new System.Drawing.Size(75, 38);
            this.buttonExitTeamMember.TabIndex = 3;
            this.buttonExitTeamMember.Text = "Exit";
            this.buttonExitTeamMember.UseVisualStyleBackColor = true;
            this.buttonExitTeamMember.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(14, 290);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(137, 35);
            this.buttonEditProfile.TabIndex = 2;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // labelTeamMemberDisplayName
            // 
            this.labelTeamMemberDisplayName.AutoSize = true;
            this.labelTeamMemberDisplayName.Font = new System.Drawing.Font("Mistral", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamMemberDisplayName.Location = new System.Drawing.Point(28, 154);
            this.labelTeamMemberDisplayName.Name = "labelTeamMemberDisplayName";
            this.labelTeamMemberDisplayName.Size = new System.Drawing.Size(112, 26);
            this.labelTeamMemberDisplayName.TabIndex = 1;
            this.labelTeamMemberDisplayName.Text = "DisplayName";
            // 
            // pictureBoxTeamMemberAvatar
            // 
            this.pictureBoxTeamMemberAvatar.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxTeamMemberAvatar.Name = "pictureBoxTeamMemberAvatar";
            this.pictureBoxTeamMemberAvatar.Size = new System.Drawing.Size(161, 148);
            this.pictureBoxTeamMemberAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTeamMemberAvatar.TabIndex = 0;
            this.pictureBoxTeamMemberAvatar.TabStop = false;
            // 
            // tabControlTeamMember
            // 
            this.tabControlTeamMember.Controls.Add(this.tabActiveTasks);
            this.tabControlTeamMember.Controls.Add(this.tabMyTasks);
            this.tabControlTeamMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlTeamMember.Location = new System.Drawing.Point(186, 12);
            this.tabControlTeamMember.Name = "tabControlTeamMember";
            this.tabControlTeamMember.SelectedIndex = 0;
            this.tabControlTeamMember.Size = new System.Drawing.Size(713, 561);
            this.tabControlTeamMember.TabIndex = 1;
            // 
            // tabActiveTasks
            // 
            this.tabActiveTasks.Controls.Add(this.buttonLeaveProject);
            this.tabActiveTasks.Controls.Add(this.flowLayoutPanelActiveTasks);
            this.tabActiveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabActiveTasks.Location = new System.Drawing.Point(4, 29);
            this.tabActiveTasks.Name = "tabActiveTasks";
            this.tabActiveTasks.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabActiveTasks.Size = new System.Drawing.Size(705, 528);
            this.tabActiveTasks.TabIndex = 0;
            this.tabActiveTasks.Text = "Active Tasks";
            this.tabActiveTasks.UseVisualStyleBackColor = true;
            // 
            // buttonLeaveProject
            // 
            this.buttonLeaveProject.Location = new System.Drawing.Point(248, 478);
            this.buttonLeaveProject.Name = "buttonLeaveProject";
            this.buttonLeaveProject.Size = new System.Drawing.Size(184, 41);
            this.buttonLeaveProject.TabIndex = 1;
            this.buttonLeaveProject.Text = "Leave Project";
            this.buttonLeaveProject.UseVisualStyleBackColor = true;
            this.buttonLeaveProject.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanelActiveTasks
            // 
            this.flowLayoutPanelActiveTasks.AutoScroll = true;
            this.flowLayoutPanelActiveTasks.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanelActiveTasks.Location = new System.Drawing.Point(0, 6);
            this.flowLayoutPanelActiveTasks.Name = "flowLayoutPanelActiveTasks";
            this.flowLayoutPanelActiveTasks.Size = new System.Drawing.Size(698, 458);
            this.flowLayoutPanelActiveTasks.TabIndex = 0;
            // 
            // tabMyTasks
            // 
            this.tabMyTasks.Controls.Add(this.flowLayoutPanelNextTasks);
            this.tabMyTasks.Controls.Add(this.panelActiveTask);
            this.tabMyTasks.Location = new System.Drawing.Point(4, 29);
            this.tabMyTasks.Name = "tabMyTasks";
            this.tabMyTasks.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabMyTasks.Size = new System.Drawing.Size(705, 528);
            this.tabMyTasks.TabIndex = 1;
            this.tabMyTasks.Text = "My Tasks";
            this.tabMyTasks.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelNextTasks
            // 
            this.flowLayoutPanelNextTasks.AutoScroll = true;
            this.flowLayoutPanelNextTasks.Location = new System.Drawing.Point(6, 390);
            this.flowLayoutPanelNextTasks.Name = "flowLayoutPanelNextTasks";
            this.flowLayoutPanelNextTasks.Size = new System.Drawing.Size(692, 134);
            this.flowLayoutPanelNextTasks.TabIndex = 1;
            // 
            // panelActiveTask
            // 
            this.panelActiveTask.BackColor = System.Drawing.Color.LightGray;
            this.panelActiveTask.Controls.Add(this.buttonFinalizeTask);
            this.panelActiveTask.Controls.Add(this.buttonExtendTaskDeadline);
            this.panelActiveTask.Controls.Add(this.buttonDropTask);
            this.panelActiveTask.Location = new System.Drawing.Point(6, 6);
            this.panelActiveTask.Name = "panelActiveTask";
            this.panelActiveTask.Size = new System.Drawing.Size(692, 378);
            this.panelActiveTask.TabIndex = 0;
            // 
            // buttonFinalizeTask
            // 
            this.buttonFinalizeTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizeTask.Location = new System.Drawing.Point(325, 317);
            this.buttonFinalizeTask.Name = "buttonFinalizeTask";
            this.buttonFinalizeTask.Size = new System.Drawing.Size(110, 47);
            this.buttonFinalizeTask.TabIndex = 2;
            this.buttonFinalizeTask.Text = "Finalize";
            this.buttonFinalizeTask.UseVisualStyleBackColor = true;
            this.buttonFinalizeTask.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonExtendTaskDeadline
            // 
            this.buttonExtendTaskDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtendTaskDeadline.Location = new System.Drawing.Point(441, 317);
            this.buttonExtendTaskDeadline.Name = "buttonExtendTaskDeadline";
            this.buttonExtendTaskDeadline.Size = new System.Drawing.Size(114, 47);
            this.buttonExtendTaskDeadline.TabIndex = 1;
            this.buttonExtendTaskDeadline.Text = "Extend";
            this.buttonExtendTaskDeadline.UseVisualStyleBackColor = true;
            this.buttonExtendTaskDeadline.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonDropTask
            // 
            this.buttonDropTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDropTask.Location = new System.Drawing.Point(561, 317);
            this.buttonDropTask.Name = "buttonDropTask";
            this.buttonDropTask.Size = new System.Drawing.Size(119, 47);
            this.buttonDropTask.TabIndex = 0;
            this.buttonDropTask.Text = "Drop";
            this.buttonDropTask.UseVisualStyleBackColor = true;
            this.buttonDropTask.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonRefreshTasks
            // 
            this.buttonRefreshTasks.Location = new System.Drawing.Point(694, 0);
            this.buttonRefreshTasks.Name = "buttonRefreshTasks";
            this.buttonRefreshTasks.Size = new System.Drawing.Size(182, 35);
            this.buttonRefreshTasks.TabIndex = 2;
            this.buttonRefreshTasks.Text = "Refresh Tasks";
            this.buttonRefreshTasks.UseVisualStyleBackColor = true;
            this.buttonRefreshTasks.Click += new System.EventHandler(this.buttonRefreshTasks_Click);
            // 
            // TeamMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 572);
            this.Controls.Add(this.buttonRefreshTasks);
            this.Controls.Add(this.tabControlTeamMember);
            this.Controls.Add(this.panelTeamMemberSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeamMember";
            this.Text = "TeamMember";
            this.panelTeamMemberSide.ResumeLayout(false);
            this.panelTeamMemberSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamMemberAvatar)).EndInit();
            this.tabControlTeamMember.ResumeLayout(false);
            this.tabActiveTasks.ResumeLayout(false);
            this.tabMyTasks.ResumeLayout(false);
            this.panelActiveTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTeamMemberSide;
        private System.Windows.Forms.Button buttonExitTeamMember;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Label labelTeamMemberDisplayName;
        private System.Windows.Forms.PictureBox pictureBoxTeamMemberAvatar;
        private System.Windows.Forms.TabControl tabControlTeamMember;
        private System.Windows.Forms.TabPage tabActiveTasks;
        private System.Windows.Forms.Button buttonLeaveProject;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelActiveTasks;
        private System.Windows.Forms.TabPage tabMyTasks;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNextTasks;
        private System.Windows.Forms.Panel panelActiveTask;
        private System.Windows.Forms.Button buttonFinalizeTask;
        private System.Windows.Forms.Button buttonExtendTaskDeadline;
        private System.Windows.Forms.Button buttonDropTask;
        private System.Windows.Forms.Button buttonRefreshTasks;
    }
}

