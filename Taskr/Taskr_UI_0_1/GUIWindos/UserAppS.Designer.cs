namespace Taskr_UI_0_1
{
    partial class UserAppS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAppS));
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.tabControlProjects = new System.Windows.Forms.TabControl();
            this.tabActiveProjects = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelActiveProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageProjectSuggestions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelProjectSuggestions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCreateNewProject = new System.Windows.Forms.TabPage();
            this.ChangeProjectImage = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ProjectLogoImage = new System.Windows.Forms.PictureBox();
            this.ProjectLongDetailsBox = new System.Windows.Forms.RichTextBox();
            this.ProjectShortDetailsBox = new System.Windows.Forms.RichTextBox();
            this.ProjectLogo = new System.Windows.Forms.Label();
            this.ProjectDIn = new System.Windows.Forms.Label();
            this.ProjectSInfo = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.Label();
            this.ProjectTitleBox = new System.Windows.Forms.TextBox();
            this.newProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.panelSide.SuspendLayout();
            this.tabControlProjects.SuspendLayout();
            this.tabActiveProjects.SuspendLayout();
            this.tabPageProjectSuggestions.SuspendLayout();
            this.tabCreateNewProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectLogoImage)).BeginInit();
            this.SuspendLayout();
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
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
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
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSide.Controls.Add(this.pictureAvatar);
            this.panelSide.Controls.Add(this.buttonLogout);
            this.panelSide.Controls.Add(this.labelUsername);
            this.panelSide.Controls.Add(this.buttonEditProfile);
            this.panelSide.Location = new System.Drawing.Point(12, 12);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 630);
            this.panelSide.TabIndex = 4;
            // 
            // tabControlProjects
            // 
            this.tabControlProjects.Controls.Add(this.tabActiveProjects);
            this.tabControlProjects.Controls.Add(this.tabPageProjectSuggestions);
            this.tabControlProjects.Controls.Add(this.tabCreateNewProject);
            this.tabControlProjects.Enabled = false;
            this.tabControlProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlProjects.Location = new System.Drawing.Point(228, 36);
            this.tabControlProjects.Name = "tabControlProjects";
            this.tabControlProjects.SelectedIndex = 0;
            this.tabControlProjects.Size = new System.Drawing.Size(760, 606);
            this.tabControlProjects.TabIndex = 5;
            this.tabControlProjects.Visible = false;
            // 
            // tabActiveProjects
            // 
            this.tabActiveProjects.Controls.Add(this.flowLayoutPanelActiveProjects);
            this.tabActiveProjects.Location = new System.Drawing.Point(4, 31);
            this.tabActiveProjects.Name = "tabActiveProjects";
            this.tabActiveProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabActiveProjects.Size = new System.Drawing.Size(752, 571);
            this.tabActiveProjects.TabIndex = 0;
            this.tabActiveProjects.Text = "Active Projects";
            this.tabActiveProjects.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelActiveProjects
            // 
            this.flowLayoutPanelActiveProjects.AutoScroll = true;
            this.flowLayoutPanelActiveProjects.AutoSize = true;
            this.flowLayoutPanelActiveProjects.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelActiveProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelActiveProjects.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelActiveProjects.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelActiveProjects.Name = "flowLayoutPanelActiveProjects";
            this.flowLayoutPanelActiveProjects.Size = new System.Drawing.Size(746, 565);
            this.flowLayoutPanelActiveProjects.TabIndex = 0;
            this.flowLayoutPanelActiveProjects.WrapContents = false;
            // 
            // tabPageProjectSuggestions
            // 
            this.tabPageProjectSuggestions.Controls.Add(this.flowLayoutPanelProjectSuggestions);
            this.tabPageProjectSuggestions.Location = new System.Drawing.Point(4, 31);
            this.tabPageProjectSuggestions.Name = "tabPageProjectSuggestions";
            this.tabPageProjectSuggestions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjectSuggestions.Size = new System.Drawing.Size(752, 571);
            this.tabPageProjectSuggestions.TabIndex = 1;
            this.tabPageProjectSuggestions.Text = "Project Suggestions";
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
            // tabCreateNewProject
            // 
            this.tabCreateNewProject.Controls.Add(this.ChangeProjectImage);
            this.tabCreateNewProject.Controls.Add(this.checkedListBox1);
            this.tabCreateNewProject.Controls.Add(this.ProjectLogoImage);
            this.tabCreateNewProject.Controls.Add(this.ProjectLongDetailsBox);
            this.tabCreateNewProject.Controls.Add(this.ProjectShortDetailsBox);
            this.tabCreateNewProject.Controls.Add(this.ProjectLogo);
            this.tabCreateNewProject.Controls.Add(this.ProjectDIn);
            this.tabCreateNewProject.Controls.Add(this.ProjectSInfo);
            this.tabCreateNewProject.Controls.Add(this.ProjectName);
            this.tabCreateNewProject.Controls.Add(this.ProjectTitleBox);
            this.tabCreateNewProject.Controls.Add(this.newProject);
            this.tabCreateNewProject.Location = new System.Drawing.Point(4, 31);
            this.tabCreateNewProject.Name = "tabCreateNewProject";
            this.tabCreateNewProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateNewProject.Size = new System.Drawing.Size(752, 571);
            this.tabCreateNewProject.TabIndex = 2;
            this.tabCreateNewProject.Text = "Create New Poject";
            this.tabCreateNewProject.UseVisualStyleBackColor = true;
            // 
            // ChangeProjectImage
            // 
            this.ChangeProjectImage.Location = new System.Drawing.Point(590, 382);
            this.ChangeProjectImage.Name = "ChangeProjectImage";
            this.ChangeProjectImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChangeProjectImage.Size = new System.Drawing.Size(123, 42);
            this.ChangeProjectImage.TabIndex = 10;
            this.ChangeProjectImage.Text = "Change Image";
            this.ChangeProjectImage.UseVisualStyleBackColor = true;
            this.ChangeProjectImage.Click += new System.EventHandler(this.ChangeProjectImage_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(43, 203);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 9;
            // 
            // ProjectLogoImage
            // 
            this.ProjectLogoImage.Location = new System.Drawing.Point(162, 363);
            this.ProjectLogoImage.Name = "ProjectLogoImage";
            this.ProjectLogoImage.Size = new System.Drawing.Size(384, 207);
            this.ProjectLogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProjectLogoImage.TabIndex = 8;
            this.ProjectLogoImage.TabStop = false;
            // 
            // ProjectLongDetailsBox
            // 
            this.ProjectLongDetailsBox.Location = new System.Drawing.Point(162, 204);
            this.ProjectLongDetailsBox.Name = "ProjectLongDetailsBox";
            this.ProjectLongDetailsBox.Size = new System.Drawing.Size(573, 144);
            this.ProjectLongDetailsBox.TabIndex = 7;
            this.ProjectLongDetailsBox.Text = "";
            // 
            // ProjectShortDetailsBox
            // 
            this.ProjectShortDetailsBox.Location = new System.Drawing.Point(162, 102);
            this.ProjectShortDetailsBox.Name = "ProjectShortDetailsBox";
            this.ProjectShortDetailsBox.Size = new System.Drawing.Size(573, 74);
            this.ProjectShortDetailsBox.TabIndex = 6;
            this.ProjectShortDetailsBox.Text = "";
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
            this.ProjectName.Size = new System.Drawing.Size(65, 24);
            this.ProjectName.TabIndex = 2;
            this.ProjectName.Text = "Name";
            // 
            // ProjectTitleBox
            // 
            this.ProjectTitleBox.Location = new System.Drawing.Point(162, 38);
            this.ProjectTitleBox.Name = "ProjectTitleBox";
            this.ProjectTitleBox.Size = new System.Drawing.Size(312, 28);
            this.ProjectTitleBox.TabIndex = 1;
            // 
            // newProject
            // 
            this.newProject.Location = new System.Drawing.Point(590, 518);
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(123, 38);
            this.newProject.TabIndex = 0;
            this.newProject.Text = "Create Project";
            this.newProject.UseVisualStyleBackColor = true;
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // UserAppS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1002, 654);
            this.Controls.Add(this.tabControlProjects);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserAppS";
            this.Text = "UserAppS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.panelSide.ResumeLayout(false);
            this.tabControlProjects.ResumeLayout(false);
            this.tabActiveProjects.ResumeLayout(false);
            this.tabActiveProjects.PerformLayout();
            this.tabPageProjectSuggestions.ResumeLayout(false);
            this.tabCreateNewProject.ResumeLayout(false);
            this.tabCreateNewProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectLogoImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureAvatar;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.TabControl tabControlProjects;
        private System.Windows.Forms.TabPage tabActiveProjects;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelActiveProjects;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProjectSuggestions;
        private System.Windows.Forms.TabPage tabPageProjectSuggestions;
        private System.Windows.Forms.TabPage tabCreateNewProject;
        private System.Windows.Forms.Label ProjectSInfo;
        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.TextBox ProjectTitleBox;
        private System.Windows.Forms.Button newProject;
        private System.Windows.Forms.PictureBox ProjectLogoImage;
        private System.Windows.Forms.RichTextBox ProjectLongDetailsBox;
        private System.Windows.Forms.RichTextBox ProjectShortDetailsBox;
        private System.Windows.Forms.Label ProjectLogo;
        private System.Windows.Forms.Label ProjectDIn;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ChangeProjectImage;
    }
}