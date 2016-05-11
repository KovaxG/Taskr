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
            this.panelTeamMemberSide.Location = new System.Drawing.Point(17, 16);
            this.panelTeamMemberSide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTeamMemberSide.Name = "panelTeamMemberSide";
            this.panelTeamMemberSide.Size = new System.Drawing.Size(223, 673);
            this.panelTeamMemberSide.TabIndex = 0;
            // 
            // buttonExitTeamMember
            // 
            this.buttonExitTeamMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitTeamMember.Location = new System.Drawing.Point(64, 604);
            this.buttonExitTeamMember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExitTeamMember.Name = "buttonExitTeamMember";
            this.buttonExitTeamMember.Size = new System.Drawing.Size(100, 47);
            this.buttonExitTeamMember.TabIndex = 3;
            this.buttonExitTeamMember.Text = "Exit";
            this.buttonExitTeamMember.UseVisualStyleBackColor = true;
            this.buttonExitTeamMember.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(19, 357);
            this.buttonEditProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(183, 43);
            this.buttonEditProfile.TabIndex = 2;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // labelTeamMemberDisplayName
            // 
            this.labelTeamMemberDisplayName.AutoSize = true;
            this.labelTeamMemberDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamMemberDisplayName.Location = new System.Drawing.Point(37, 190);
            this.labelTeamMemberDisplayName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTeamMemberDisplayName.Name = "labelTeamMemberDisplayName";
            this.labelTeamMemberDisplayName.Size = new System.Drawing.Size(96, 18);
            this.labelTeamMemberDisplayName.TabIndex = 1;
            this.labelTeamMemberDisplayName.Text = "DisplayName";
            // 
            // pictureBoxTeamMemberAvatar
            // 
            this.pictureBoxTeamMemberAvatar.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxTeamMemberAvatar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxTeamMemberAvatar.Name = "pictureBoxTeamMemberAvatar";
            this.pictureBoxTeamMemberAvatar.Size = new System.Drawing.Size(215, 182);
            this.pictureBoxTeamMemberAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTeamMemberAvatar.TabIndex = 0;
            this.pictureBoxTeamMemberAvatar.TabStop = false;
            // 
            // tabControlTeamMember
            // 
            this.tabControlTeamMember.Controls.Add(this.tabActiveTasks);
            this.tabControlTeamMember.Controls.Add(this.tabMyTasks);
            this.tabControlTeamMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlTeamMember.Location = new System.Drawing.Point(248, 15);
            this.tabControlTeamMember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlTeamMember.Name = "tabControlTeamMember";
            this.tabControlTeamMember.SelectedIndex = 0;
            this.tabControlTeamMember.Size = new System.Drawing.Size(951, 690);
            this.tabControlTeamMember.TabIndex = 1;
            // 
            // tabActiveTasks
            // 
            this.tabActiveTasks.Controls.Add(this.buttonLeaveProject);
            this.tabActiveTasks.Controls.Add(this.flowLayoutPanelActiveTasks);
            this.tabActiveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabActiveTasks.Location = new System.Drawing.Point(4, 29);
            this.tabActiveTasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabActiveTasks.Name = "tabActiveTasks";
            this.tabActiveTasks.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabActiveTasks.Size = new System.Drawing.Size(943, 657);
            this.tabActiveTasks.TabIndex = 0;
            this.tabActiveTasks.Text = "Active Tasks";
            this.tabActiveTasks.UseVisualStyleBackColor = true;
            // 
            // buttonLeaveProject
            // 
            this.buttonLeaveProject.Location = new System.Drawing.Point(331, 588);
            this.buttonLeaveProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLeaveProject.Name = "buttonLeaveProject";
            this.buttonLeaveProject.Size = new System.Drawing.Size(245, 50);
            this.buttonLeaveProject.TabIndex = 1;
            this.buttonLeaveProject.Text = "Leave Project";
            this.buttonLeaveProject.UseVisualStyleBackColor = true;
            this.buttonLeaveProject.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanelActiveTasks
            // 
            this.flowLayoutPanelActiveTasks.AutoScroll = true;
            this.flowLayoutPanelActiveTasks.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanelActiveTasks.Location = new System.Drawing.Point(0, 7);
            this.flowLayoutPanelActiveTasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelActiveTasks.Name = "flowLayoutPanelActiveTasks";
            this.flowLayoutPanelActiveTasks.Size = new System.Drawing.Size(931, 564);
            this.flowLayoutPanelActiveTasks.TabIndex = 0;
            // 
            // tabMyTasks
            // 
            this.tabMyTasks.Controls.Add(this.flowLayoutPanelNextTasks);
            this.tabMyTasks.Controls.Add(this.panelActiveTask);
            this.tabMyTasks.Location = new System.Drawing.Point(4, 29);
            this.tabMyTasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMyTasks.Name = "tabMyTasks";
            this.tabMyTasks.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMyTasks.Size = new System.Drawing.Size(943, 657);
            this.tabMyTasks.TabIndex = 1;
            this.tabMyTasks.Text = "My Tasks";
            this.tabMyTasks.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelNextTasks
            // 
            this.flowLayoutPanelNextTasks.AutoScroll = true;
            this.flowLayoutPanelNextTasks.Location = new System.Drawing.Point(8, 480);
            this.flowLayoutPanelNextTasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelNextTasks.Name = "flowLayoutPanelNextTasks";
            this.flowLayoutPanelNextTasks.Size = new System.Drawing.Size(923, 165);
            this.flowLayoutPanelNextTasks.TabIndex = 1;
            // 
            // panelActiveTask
            // 
            this.panelActiveTask.BackColor = System.Drawing.Color.LightGray;
            this.panelActiveTask.Controls.Add(this.buttonFinalizeTask);
            this.panelActiveTask.Controls.Add(this.buttonExtendTaskDeadline);
            this.panelActiveTask.Controls.Add(this.buttonDropTask);
            this.panelActiveTask.Location = new System.Drawing.Point(8, 7);
            this.panelActiveTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelActiveTask.Name = "panelActiveTask";
            this.panelActiveTask.Size = new System.Drawing.Size(923, 465);
            this.panelActiveTask.TabIndex = 0;
            // 
            // buttonFinalizeTask
            // 
            this.buttonFinalizeTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizeTask.Location = new System.Drawing.Point(433, 390);
            this.buttonFinalizeTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFinalizeTask.Name = "buttonFinalizeTask";
            this.buttonFinalizeTask.Size = new System.Drawing.Size(147, 58);
            this.buttonFinalizeTask.TabIndex = 2;
            this.buttonFinalizeTask.Text = "Finalize";
            this.buttonFinalizeTask.UseVisualStyleBackColor = true;
            this.buttonFinalizeTask.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonExtendTaskDeadline
            // 
            this.buttonExtendTaskDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtendTaskDeadline.Location = new System.Drawing.Point(588, 390);
            this.buttonExtendTaskDeadline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExtendTaskDeadline.Name = "buttonExtendTaskDeadline";
            this.buttonExtendTaskDeadline.Size = new System.Drawing.Size(152, 58);
            this.buttonExtendTaskDeadline.TabIndex = 1;
            this.buttonExtendTaskDeadline.Text = "Extend";
            this.buttonExtendTaskDeadline.UseVisualStyleBackColor = true;
            this.buttonExtendTaskDeadline.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonDropTask
            // 
            this.buttonDropTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDropTask.Location = new System.Drawing.Point(748, 390);
            this.buttonDropTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDropTask.Name = "buttonDropTask";
            this.buttonDropTask.Size = new System.Drawing.Size(159, 58);
            this.buttonDropTask.TabIndex = 0;
            this.buttonDropTask.Text = "Drop";
            this.buttonDropTask.UseVisualStyleBackColor = true;
            this.buttonDropTask.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonRefreshTasks
            // 
            this.buttonRefreshTasks.Location = new System.Drawing.Point(925, 0);
            this.buttonRefreshTasks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRefreshTasks.Name = "buttonRefreshTasks";
            this.buttonRefreshTasks.Size = new System.Drawing.Size(243, 43);
            this.buttonRefreshTasks.TabIndex = 2;
            this.buttonRefreshTasks.Text = "Refresh Tasks";
            this.buttonRefreshTasks.UseVisualStyleBackColor = true;
            this.buttonRefreshTasks.Click += new System.EventHandler(this.buttonRefreshTasks_Click);
            // 
            // TeamMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 704);
            this.Controls.Add(this.buttonRefreshTasks);
            this.Controls.Add(this.tabControlTeamMember);
            this.Controls.Add(this.panelTeamMemberSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

