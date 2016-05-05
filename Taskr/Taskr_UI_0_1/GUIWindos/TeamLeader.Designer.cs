namespace Taskr_UI_0_1
{
    partial class TeamLeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamLeader));
            this.panelSide = new System.Windows.Forms.Panel();
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.tabControlVarious = new System.Windows.Forms.TabControl();
            this.tabActiveTasks = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCreateTask = new System.Windows.Forms.TabPage();
            this.tabPageProjectSuggestions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelProjectSuggestions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabEditProject = new System.Windows.Forms.TabPage();
            this.ButtonChangeProjectImage = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ImageProjectLogo = new System.Windows.Forms.PictureBox();
            this.TextBoxProjectLongDescription = new System.Windows.Forms.RichTextBox();
            this.TextBoxProjectShortDescritpion = new System.Windows.Forms.RichTextBox();
            this.ProjectLogo = new System.Windows.Forms.Label();
            this.ProjectDIn = new System.Windows.Forms.Label();
            this.ProjectSInfo = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.Label();
            this.TextBoxProjectTitle = new System.Windows.Forms.TextBox();
            this.ButtonUpdateProjectDetails = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonAbandonProject = new System.Windows.Forms.Button();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.tabControlVarious.SuspendLayout();
            this.tabActiveTasks.SuspendLayout();
            this.tabPageProjectSuggestions.SuspendLayout();
            this.tabEditProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProjectLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSide.Controls.Add(this.labelStatus);
            this.panelSide.Controls.Add(this.pictureAvatar);
            this.panelSide.Controls.Add(this.buttonLogout);
            this.panelSide.Controls.Add(this.labelUsername);
            this.panelSide.Controls.Add(this.buttonEditProfile);
            this.panelSide.Location = new System.Drawing.Point(12, 12);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 630);
            this.panelSide.TabIndex = 5;
            // 
            // pictureAvatar
            // 
            this.pictureAvatar.Location = new System.Drawing.Point(19, 24);
            this.pictureAvatar.Name = "pictureAvatar";
            this.pictureAvatar.Size = new System.Drawing.Size(128, 128);
            this.pictureAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAvatar.TabIndex = 0;
            this.pictureAvatar.TabStop = false;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(19, 568);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(128, 45);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(14, 168);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(128, 29);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "UserName";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(19, 212);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(128, 45);
            this.buttonEditProfile.TabIndex = 2;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            // 
            // tabControlVarious
            // 
            this.tabControlVarious.Controls.Add(this.tabActiveTasks);
            this.tabControlVarious.Controls.Add(this.tabCreateTask);
            this.tabControlVarious.Controls.Add(this.tabPageProjectSuggestions);
            this.tabControlVarious.Controls.Add(this.tabEditProject);
            this.tabControlVarious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlVarious.Location = new System.Drawing.Point(230, 36);
            this.tabControlVarious.Name = "tabControlVarious";
            this.tabControlVarious.SelectedIndex = 0;
            this.tabControlVarious.Size = new System.Drawing.Size(760, 606);
            this.tabControlVarious.TabIndex = 6;
            // 
            // tabActiveTasks
            // 
            this.tabActiveTasks.Controls.Add(this.flowLayoutPanelTasks);
            this.tabActiveTasks.Location = new System.Drawing.Point(4, 31);
            this.tabActiveTasks.Name = "tabActiveTasks";
            this.tabActiveTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabActiveTasks.Size = new System.Drawing.Size(752, 571);
            this.tabActiveTasks.TabIndex = 0;
            this.tabActiveTasks.Text = "Tasks";
            this.tabActiveTasks.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTasks
            // 
            this.flowLayoutPanelTasks.AutoScroll = true;
            this.flowLayoutPanelTasks.AutoSize = true;
            this.flowLayoutPanelTasks.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTasks.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            this.flowLayoutPanelTasks.Size = new System.Drawing.Size(746, 565);
            this.flowLayoutPanelTasks.TabIndex = 0;
            this.flowLayoutPanelTasks.WrapContents = false;
            // 
            // tabCreateTask
            // 
            this.tabCreateTask.Location = new System.Drawing.Point(4, 31);
            this.tabCreateTask.Name = "tabCreateTask";
            this.tabCreateTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateTask.Size = new System.Drawing.Size(752, 571);
            this.tabCreateTask.TabIndex = 3;
            this.tabCreateTask.Text = "Create Task";
            this.tabCreateTask.UseVisualStyleBackColor = true;
            // 
            // tabPageProjectSuggestions
            // 
            this.tabPageProjectSuggestions.Controls.Add(this.flowLayoutPanelProjectSuggestions);
            this.tabPageProjectSuggestions.Location = new System.Drawing.Point(4, 31);
            this.tabPageProjectSuggestions.Name = "tabPageProjectSuggestions";
            this.tabPageProjectSuggestions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjectSuggestions.Size = new System.Drawing.Size(752, 571);
            this.tabPageProjectSuggestions.TabIndex = 1;
            this.tabPageProjectSuggestions.Text = "Team Members";
            this.tabPageProjectSuggestions.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelProjectSuggestions
            // 
            this.flowLayoutPanelProjectSuggestions.AutoScroll = true;
            this.flowLayoutPanelProjectSuggestions.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelProjectSuggestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProjectSuggestions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelProjectSuggestions.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelProjectSuggestions.Name = "flowLayoutPanelProjectSuggestions";
            this.flowLayoutPanelProjectSuggestions.Size = new System.Drawing.Size(746, 565);
            this.flowLayoutPanelProjectSuggestions.TabIndex = 0;
            this.flowLayoutPanelProjectSuggestions.WrapContents = false;
            // 
            // tabEditProject
            // 
            this.tabEditProject.BackColor = System.Drawing.Color.Gainsboro;
            this.tabEditProject.Controls.Add(this.buttonAbandonProject);
            this.tabEditProject.Controls.Add(this.ButtonChangeProjectImage);
            this.tabEditProject.Controls.Add(this.checkedListBox1);
            this.tabEditProject.Controls.Add(this.ImageProjectLogo);
            this.tabEditProject.Controls.Add(this.TextBoxProjectLongDescription);
            this.tabEditProject.Controls.Add(this.TextBoxProjectShortDescritpion);
            this.tabEditProject.Controls.Add(this.ProjectLogo);
            this.tabEditProject.Controls.Add(this.ProjectDIn);
            this.tabEditProject.Controls.Add(this.ProjectSInfo);
            this.tabEditProject.Controls.Add(this.ProjectName);
            this.tabEditProject.Controls.Add(this.TextBoxProjectTitle);
            this.tabEditProject.Controls.Add(this.ButtonUpdateProjectDetails);
            this.tabEditProject.Location = new System.Drawing.Point(4, 31);
            this.tabEditProject.Name = "tabEditProject";
            this.tabEditProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditProject.Size = new System.Drawing.Size(752, 571);
            this.tabEditProject.TabIndex = 2;
            this.tabEditProject.Text = "Edit Project Details";
            // 
            // ButtonChangeProjectImage
            // 
            this.ButtonChangeProjectImage.Location = new System.Drawing.Point(322, 363);
            this.ButtonChangeProjectImage.Name = "ButtonChangeProjectImage";
            this.ButtonChangeProjectImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButtonChangeProjectImage.Size = new System.Drawing.Size(123, 42);
            this.ButtonChangeProjectImage.TabIndex = 10;
            this.ButtonChangeProjectImage.Text = "Change Image";
            this.ButtonChangeProjectImage.UseVisualStyleBackColor = true;
            this.ButtonChangeProjectImage.Click += new System.EventHandler(this.ButtonChangeProjectImage_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(43, 203);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 9;
            // 
            // ImageProjectLogo
            // 
            this.ImageProjectLogo.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X;
            this.ImageProjectLogo.Location = new System.Drawing.Point(162, 363);
            this.ImageProjectLogo.Name = "ImageProjectLogo";
            this.ImageProjectLogo.Size = new System.Drawing.Size(128, 128);
            this.ImageProjectLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageProjectLogo.TabIndex = 8;
            this.ImageProjectLogo.TabStop = false;
            // 
            // TextBoxProjectLongDescription
            // 
            this.TextBoxProjectLongDescription.Location = new System.Drawing.Point(162, 204);
            this.TextBoxProjectLongDescription.Name = "TextBoxProjectLongDescription";
            this.TextBoxProjectLongDescription.Size = new System.Drawing.Size(573, 144);
            this.TextBoxProjectLongDescription.TabIndex = 7;
            this.TextBoxProjectLongDescription.Text = "";
            this.TextBoxProjectLongDescription.TextChanged += new System.EventHandler(this.TextBoxProjectLongDescription_TextChanged);
            // 
            // TextBoxProjectShortDescritpion
            // 
            this.TextBoxProjectShortDescritpion.Location = new System.Drawing.Point(162, 102);
            this.TextBoxProjectShortDescritpion.Name = "TextBoxProjectShortDescritpion";
            this.TextBoxProjectShortDescritpion.Size = new System.Drawing.Size(573, 74);
            this.TextBoxProjectShortDescritpion.TabIndex = 6;
            this.TextBoxProjectShortDescritpion.Text = "";
            this.TextBoxProjectShortDescritpion.TextChanged += new System.EventHandler(this.TextBoxProjectShortDescritpion_TextChanged);
            // 
            // ProjectLogo
            // 
            this.ProjectLogo.AutoSize = true;
            this.ProjectLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLogo.Location = new System.Drawing.Point(29, 363);
            this.ProjectLogo.Name = "ProjectLogo";
            this.ProjectLogo.Size = new System.Drawing.Size(128, 24);
            this.ProjectLogo.TabIndex = 5;
            this.ProjectLogo.Text = "Project Logo";
            // 
            // ProjectDIn
            // 
            this.ProjectDIn.AutoSize = true;
            this.ProjectDIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectDIn.Location = new System.Drawing.Point(6, 207);
            this.ProjectDIn.Name = "ProjectDIn";
            this.ProjectDIn.Size = new System.Drawing.Size(195, 24);
            this.ProjectDIn.TabIndex = 4;
            this.ProjectDIn.Text = "Detailed description";
            // 
            // ProjectSInfo
            // 
            this.ProjectSInfo.AutoSize = true;
            this.ProjectSInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectSInfo.Location = new System.Drawing.Point(19, 102);
            this.ProjectSInfo.Name = "ProjectSInfo";
            this.ProjectSInfo.Size = new System.Drawing.Size(168, 24);
            this.ProjectSInfo.TabIndex = 3;
            this.ProjectSInfo.Text = "Short description";
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSize = true;
            this.ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(40, 38);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(50, 24);
            this.ProjectName.TabIndex = 2;
            this.ProjectName.Text = "Title";
            // 
            // TextBoxProjectTitle
            // 
            this.TextBoxProjectTitle.Location = new System.Drawing.Point(162, 38);
            this.TextBoxProjectTitle.Name = "TextBoxProjectTitle";
            this.TextBoxProjectTitle.Size = new System.Drawing.Size(312, 28);
            this.TextBoxProjectTitle.TabIndex = 1;
            this.TextBoxProjectTitle.TextChanged += new System.EventHandler(this.TextBoxProjectTitle_TextChanged);
            // 
            // ButtonUpdateProjectDetails
            // 
            this.ButtonUpdateProjectDetails.Location = new System.Drawing.Point(162, 520);
            this.ButtonUpdateProjectDetails.Name = "ButtonUpdateProjectDetails";
            this.ButtonUpdateProjectDetails.Size = new System.Drawing.Size(123, 38);
            this.ButtonUpdateProjectDetails.TabIndex = 0;
            this.ButtonUpdateProjectDetails.Text = "Update";
            this.ButtonUpdateProjectDetails.UseVisualStyleBackColor = true;
            this.ButtonUpdateProjectDetails.Click += new System.EventHandler(this.ButtonUpdateProjectDetails_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(28, 282);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(89, 17);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "TeamLeader";
            // 
            // buttonAbandonProject
            // 
            this.buttonAbandonProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbandonProject.Location = new System.Drawing.Point(530, 513);
            this.buttonAbandonProject.Name = "buttonAbandonProject";
            this.buttonAbandonProject.Size = new System.Drawing.Size(205, 45);
            this.buttonAbandonProject.TabIndex = 11;
            this.buttonAbandonProject.Text = "Abolish Project";
            this.buttonAbandonProject.UseVisualStyleBackColor = true;
            this.buttonAbandonProject.Click += new System.EventHandler(this.buttonAbandonProject_Click);
            // 
            // TeamLeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1002, 654);
            this.Controls.Add(this.tabControlVarious);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamLeader";
            this.Text = "UserAppS";
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.tabControlVarious.ResumeLayout(false);
            this.tabActiveTasks.ResumeLayout(false);
            this.tabActiveTasks.PerformLayout();
            this.tabPageProjectSuggestions.ResumeLayout(false);
            this.tabEditProject.ResumeLayout(false);
            this.tabEditProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProjectLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureAvatar;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.TabControl tabControlVarious;
        private System.Windows.Forms.TabPage tabActiveTasks;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTasks;
        private System.Windows.Forms.TabPage tabPageProjectSuggestions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjectSuggestions;
        private System.Windows.Forms.TabPage tabEditProject;
        private System.Windows.Forms.Button ButtonChangeProjectImage;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.PictureBox ImageProjectLogo;
        private System.Windows.Forms.RichTextBox TextBoxProjectLongDescription;
        private System.Windows.Forms.RichTextBox TextBoxProjectShortDescritpion;
        private System.Windows.Forms.Label ProjectLogo;
        private System.Windows.Forms.Label ProjectDIn;
        private System.Windows.Forms.Label ProjectSInfo;
        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.TextBox TextBoxProjectTitle;
        private System.Windows.Forms.Button ButtonUpdateProjectDetails;
        private System.Windows.Forms.TabPage tabCreateTask;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonAbandonProject;
    }
}