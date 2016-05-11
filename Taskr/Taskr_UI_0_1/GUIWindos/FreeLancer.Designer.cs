namespace Taskr_UI_0_1
{
    partial class FreeLancer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tabControlProjects = new System.Windows.Forms.TabControl();
            this.tabActiveProjects = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelActiveProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageProjectSuggestions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelProjectSuggestions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCreateNewProject = new System.Windows.Forms.TabPage();
            this.panelCreateNewProject = new System.Windows.Forms.Panel();
            this.pictureBoxProjectImage = new System.Windows.Forms.PictureBox();
            this.textBoxImageURL = new System.Windows.Forms.TextBox();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.textBoxAvailableFunds = new System.Windows.Forms.TextBox();
            this.textBoxCurrentYield = new System.Windows.Forms.TextBox();
            this.textBoxModificationLog = new System.Windows.Forms.TextBox();
            this.labelAvailableFunds = new System.Windows.Forms.Label();
            this.labelModificationLog = new System.Windows.Forms.Label();
            this.labelCurrentYield = new System.Windows.Forms.Label();
            this.TextBoxProjectLongDetails = new System.Windows.Forms.RichTextBox();
            this.TextBoxProjectShortDetails = new System.Windows.Forms.RichTextBox();
            this.LabelProjectImage = new System.Windows.Forms.Label();
            this.LabelProjectDetailedDescription = new System.Windows.Forms.Label();
            this.LabelProjectShortDescription = new System.Windows.Forms.Label();
            this.LabelProjectTitle = new System.Windows.Forms.Label();
            this.TextBoxProjectTitle = new System.Windows.Forms.TextBox();
            this.ButtonCreateProject = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.panelSide.SuspendLayout();
            this.tabControlProjects.SuspendLayout();
            this.tabActiveProjects.SuspendLayout();
            this.tabPageProjectSuggestions.SuspendLayout();
            this.tabCreateNewProject.SuspendLayout();
            this.panelCreateNewProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureAvatar
            // 
            this.pictureAvatar.Location = new System.Drawing.Point(19, 24);
            this.pictureAvatar.Name = "pictureAvatar";
            this.pictureAvatar.Size = new System.Drawing.Size(128, 128);
            this.pictureAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAvatar.TabIndex = 0;
            this.pictureAvatar.TabStop = false;
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(19, 169);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(168, 52);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "UserName";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(19, 281);
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
            this.panelSide.Controls.Add(this.labelStatus);
            this.panelSide.Controls.Add(this.pictureAvatar);
            this.panelSide.Controls.Add(this.buttonLogout);
            this.panelSide.Controls.Add(this.labelUsername);
            this.panelSide.Controls.Add(this.buttonEditProfile);
            this.panelSide.Location = new System.Drawing.Point(12, 12);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 630);
            this.panelSide.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(21, 221);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(76, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Freelancer";
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
            this.tabCreateNewProject.Controls.Add(this.panelCreateNewProject);
            this.tabCreateNewProject.Controls.Add(this.checkedListBox1);
            this.tabCreateNewProject.Location = new System.Drawing.Point(4, 31);
            this.tabCreateNewProject.Name = "tabCreateNewProject";
            this.tabCreateNewProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateNewProject.Size = new System.Drawing.Size(752, 571);
            this.tabCreateNewProject.TabIndex = 2;
            this.tabCreateNewProject.Text = "Create New Poject";
            this.tabCreateNewProject.UseVisualStyleBackColor = true;
            // 
            // panelCreateNewProject
            // 
            this.panelCreateNewProject.AutoScroll = true;
            this.panelCreateNewProject.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCreateNewProject.Controls.Add(this.pictureBoxProjectImage);
            this.panelCreateNewProject.Controls.Add(this.textBoxImageURL);
            this.panelCreateNewProject.Controls.Add(this.labelEmpty);
            this.panelCreateNewProject.Controls.Add(this.textBoxAvailableFunds);
            this.panelCreateNewProject.Controls.Add(this.textBoxCurrentYield);
            this.panelCreateNewProject.Controls.Add(this.textBoxModificationLog);
            this.panelCreateNewProject.Controls.Add(this.labelAvailableFunds);
            this.panelCreateNewProject.Controls.Add(this.labelModificationLog);
            this.panelCreateNewProject.Controls.Add(this.labelCurrentYield);
            this.panelCreateNewProject.Controls.Add(this.TextBoxProjectLongDetails);
            this.panelCreateNewProject.Controls.Add(this.TextBoxProjectShortDetails);
            this.panelCreateNewProject.Controls.Add(this.LabelProjectImage);
            this.panelCreateNewProject.Controls.Add(this.LabelProjectDetailedDescription);
            this.panelCreateNewProject.Controls.Add(this.LabelProjectShortDescription);
            this.panelCreateNewProject.Controls.Add(this.LabelProjectTitle);
            this.panelCreateNewProject.Controls.Add(this.TextBoxProjectTitle);
            this.panelCreateNewProject.Controls.Add(this.ButtonCreateProject);
            this.panelCreateNewProject.Location = new System.Drawing.Point(4, 4);
            this.panelCreateNewProject.Name = "panelCreateNewProject";
            this.panelCreateNewProject.Size = new System.Drawing.Size(745, 564);
            this.panelCreateNewProject.TabIndex = 10;
            // 
            // pictureBoxProjectImage
            // 
            this.pictureBoxProjectImage.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureBoxProjectImage.Image = global::Taskr_UI_0_1.Properties.Resources.X;
            this.pictureBoxProjectImage.Location = new System.Drawing.Point(506, 379);
            this.pictureBoxProjectImage.Name = "pictureBoxProjectImage";
            this.pictureBoxProjectImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxProjectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProjectImage.TabIndex = 30;
            this.pictureBoxProjectImage.TabStop = false;
            // 
            // textBoxImageURL
            // 
            this.textBoxImageURL.Location = new System.Drawing.Point(202, 341);
            this.textBoxImageURL.Name = "textBoxImageURL";
            this.textBoxImageURL.Size = new System.Drawing.Size(507, 28);
            this.textBoxImageURL.TabIndex = 24;
            this.textBoxImageURL.LostFocus += new System.EventHandler(this.textBoxImageURL_LostFocus);
            // 
            // labelEmpty
            // 
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.Location = new System.Drawing.Point(400, 650);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(0, 24);
            this.labelEmpty.TabIndex = 27;
            // 
            // textBoxAvailableFunds
            // 
            this.textBoxAvailableFunds.Location = new System.Drawing.Point(202, 463);
            this.textBoxAvailableFunds.Name = "textBoxAvailableFunds";
            this.textBoxAvailableFunds.Size = new System.Drawing.Size(223, 28);
            this.textBoxAvailableFunds.TabIndex = 26;
            // 
            // textBoxCurrentYield
            // 
            this.textBoxCurrentYield.Location = new System.Drawing.Point(202, 406);
            this.textBoxCurrentYield.Name = "textBoxCurrentYield";
            this.textBoxCurrentYield.Size = new System.Drawing.Size(223, 28);
            this.textBoxCurrentYield.TabIndex = 25;
            // 
            // textBoxModificationLog
            // 
            this.textBoxModificationLog.Location = new System.Drawing.Point(202, 518);
            this.textBoxModificationLog.Name = "textBoxModificationLog";
            this.textBoxModificationLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxModificationLog.Size = new System.Drawing.Size(507, 28);
            this.textBoxModificationLog.TabIndex = 28;
            // 
            // labelAvailableFunds
            // 
            this.labelAvailableFunds.AutoSize = true;
            this.labelAvailableFunds.Location = new System.Drawing.Point(21, 463);
            this.labelAvailableFunds.Name = "labelAvailableFunds";
            this.labelAvailableFunds.Size = new System.Drawing.Size(145, 24);
            this.labelAvailableFunds.TabIndex = 23;
            this.labelAvailableFunds.Text = "Available Funds";
            // 
            // labelModificationLog
            // 
            this.labelModificationLog.AutoSize = true;
            this.labelModificationLog.Location = new System.Drawing.Point(21, 518);
            this.labelModificationLog.Name = "labelModificationLog";
            this.labelModificationLog.Size = new System.Drawing.Size(156, 48);
            this.labelModificationLog.TabIndex = 22;
            this.labelModificationLog.Text = "Modifications Log\r\n(URL)";
            // 
            // labelCurrentYield
            // 
            this.labelCurrentYield.AutoSize = true;
            this.labelCurrentYield.Location = new System.Drawing.Point(21, 406);
            this.labelCurrentYield.Name = "labelCurrentYield";
            this.labelCurrentYield.Size = new System.Drawing.Size(119, 24);
            this.labelCurrentYield.TabIndex = 21;
            this.labelCurrentYield.Text = "Current Yield";
            // 
            // TextBoxProjectLongDetails
            // 
            this.TextBoxProjectLongDetails.Location = new System.Drawing.Point(202, 182);
            this.TextBoxProjectLongDetails.Name = "TextBoxProjectLongDetails";
            this.TextBoxProjectLongDetails.Size = new System.Drawing.Size(507, 144);
            this.TextBoxProjectLongDetails.TabIndex = 18;
            this.TextBoxProjectLongDetails.Text = "";
            // 
            // TextBoxProjectShortDetails
            // 
            this.TextBoxProjectShortDetails.Location = new System.Drawing.Point(202, 80);
            this.TextBoxProjectShortDetails.MaxLength = 250;
            this.TextBoxProjectShortDetails.Name = "TextBoxProjectShortDetails";
            this.TextBoxProjectShortDetails.Size = new System.Drawing.Size(507, 74);
            this.TextBoxProjectShortDetails.TabIndex = 17;
            this.TextBoxProjectShortDetails.Text = "";
            // 
            // LabelProjectImage
            // 
            this.LabelProjectImage.AutoSize = true;
            this.LabelProjectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectImage.Location = new System.Drawing.Point(21, 343);
            this.LabelProjectImage.Name = "LabelProjectImage";
            this.LabelProjectImage.Size = new System.Drawing.Size(178, 24);
            this.LabelProjectImage.TabIndex = 16;
            this.LabelProjectImage.Text = "Project Image (URL)\r\n";
            // 
            // LabelProjectDetailedDescription
            // 
            this.LabelProjectDetailedDescription.AutoSize = true;
            this.LabelProjectDetailedDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectDetailedDescription.Location = new System.Drawing.Point(21, 184);
            this.LabelProjectDetailedDescription.Name = "LabelProjectDetailedDescription";
            this.LabelProjectDetailedDescription.Size = new System.Drawing.Size(175, 24);
            this.LabelProjectDetailedDescription.TabIndex = 15;
            this.LabelProjectDetailedDescription.Text = "Detailed description";
            // 
            // LabelProjectShortDescription
            // 
            this.LabelProjectShortDescription.AutoSize = true;
            this.LabelProjectShortDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectShortDescription.Location = new System.Drawing.Point(21, 80);
            this.LabelProjectShortDescription.Name = "LabelProjectShortDescription";
            this.LabelProjectShortDescription.Size = new System.Drawing.Size(185, 48);
            this.LabelProjectShortDescription.TabIndex = 14;
            this.LabelProjectShortDescription.Text = "Short description\r\n(max 250 characters)\r\n";
            // 
            // LabelProjectTitle
            // 
            this.LabelProjectTitle.AutoSize = true;
            this.LabelProjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectTitle.Location = new System.Drawing.Point(21, 18);
            this.LabelProjectTitle.Name = "LabelProjectTitle";
            this.LabelProjectTitle.Size = new System.Drawing.Size(175, 48);
            this.LabelProjectTitle.TabIndex = 13;
            this.LabelProjectTitle.Text = "Title\r\n(max 50 characters)";
            // 
            // TextBoxProjectTitle
            // 
            this.TextBoxProjectTitle.Location = new System.Drawing.Point(202, 16);
            this.TextBoxProjectTitle.MaxLength = 50;
            this.TextBoxProjectTitle.Name = "TextBoxProjectTitle";
            this.TextBoxProjectTitle.Size = new System.Drawing.Size(332, 28);
            this.TextBoxProjectTitle.TabIndex = 12;
            // 
            // ButtonCreateProject
            // 
            this.ButtonCreateProject.Location = new System.Drawing.Point(278, 588);
            this.ButtonCreateProject.Name = "ButtonCreateProject";
            this.ButtonCreateProject.Size = new System.Drawing.Size(256, 55);
            this.ButtonCreateProject.TabIndex = 29;
            this.ButtonCreateProject.Text = "Create Project";
            this.ButtonCreateProject.UseVisualStyleBackColor = true;
            this.ButtonCreateProject.Click += new System.EventHandler(this.ButtonCreateProject_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(43, 203);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 9;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(762, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(226, 40);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh Projects";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // FreeLancer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1002, 654);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.tabControlProjects);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FreeLancer";
            this.Text = "FreeLancer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            this.tabControlProjects.ResumeLayout(false);
            this.tabActiveProjects.ResumeLayout(false);
            this.tabActiveProjects.PerformLayout();
            this.tabPageProjectSuggestions.ResumeLayout(false);
            this.tabCreateNewProject.ResumeLayout(false);
            this.panelCreateNewProject.ResumeLayout(false);
            this.panelCreateNewProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectImage)).EndInit();
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
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panelCreateNewProject;
        private System.Windows.Forms.RichTextBox TextBoxProjectLongDetails;
        private System.Windows.Forms.RichTextBox TextBoxProjectShortDetails;
        private System.Windows.Forms.Label LabelProjectImage;
        private System.Windows.Forms.Label LabelProjectDetailedDescription;
        private System.Windows.Forms.Label LabelProjectShortDescription;
        private System.Windows.Forms.Label LabelProjectTitle;
        private System.Windows.Forms.TextBox TextBoxProjectTitle;
        private System.Windows.Forms.Button ButtonCreateProject;
        private System.Windows.Forms.Label labelEmpty;
        private System.Windows.Forms.TextBox textBoxAvailableFunds;
        private System.Windows.Forms.TextBox textBoxCurrentYield;
        private System.Windows.Forms.TextBox textBoxModificationLog;
        private System.Windows.Forms.Label labelAvailableFunds;
        private System.Windows.Forms.Label labelModificationLog;
        private System.Windows.Forms.Label labelCurrentYield;
        private System.Windows.Forms.TextBox textBoxImageURL;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.PictureBox pictureBoxProjectImage;
    }
}