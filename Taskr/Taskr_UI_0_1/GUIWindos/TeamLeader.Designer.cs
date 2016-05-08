using System.Windows.Forms;

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
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.tabControlVarious = new System.Windows.Forms.TabControl();
            this.tabActiveTasks = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelNoItems = new System.Windows.Forms.Panel();
            this.buttonCreateTaskRedirector = new System.Windows.Forms.Button();
            this.labelNoTasks = new System.Windows.Forms.Label();
            this.tabCreateTask = new System.Windows.Forms.TabPage();
            this.panelCreateTask = new System.Windows.Forms.Panel();
            this.dateTimePickerDeadLine = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxTaskImage = new System.Windows.Forms.PictureBox();
            this.textBoxTaskImageURL = new System.Windows.Forms.TextBox();
            this.labelEmptyCreateNewTask = new System.Windows.Forms.Label();
            this.buttonCreateTask = new System.Windows.Forms.Button();
            this.labelDeadLine = new System.Windows.Forms.Label();
            this.textBoxTaskLongDescription = new System.Windows.Forms.RichTextBox();
            this.textBoxTaskShortDescription = new System.Windows.Forms.RichTextBox();
            this.labelTaskImage = new System.Windows.Forms.Label();
            this.labelTaskDetailedDescription = new System.Windows.Forms.Label();
            this.labelTaskShortDescription = new System.Windows.Forms.Label();
            this.labelTaskTitle = new System.Windows.Forms.Label();
            this.textBoxTaskTitle = new System.Windows.Forms.TextBox();
            this.tabPageProjectSuggestions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelTeamMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.panelNoTeamMember = new System.Windows.Forms.Panel();
            this.buttonInviteMember = new System.Windows.Forms.Button();
            this.labelNoTeamMembers = new System.Windows.Forms.Label();
            this.tabEditProject = new System.Windows.Forms.TabPage();
            this.LabelProjectSInfo = new System.Windows.Forms.Panel();
            this.buttonAbolishProject = new System.Windows.Forms.Button();
            this.pictureBoxProjectImage = new System.Windows.Forms.PictureBox();
            this.textBoxProjectImageURL = new System.Windows.Forms.TextBox();
            this.labelEmptyEditProjectDetails = new System.Windows.Forms.Label();
            this.textBoxAvailableFunds = new System.Windows.Forms.TextBox();
            this.ButtonUpdateProjectDetails = new System.Windows.Forms.Button();
            this.textBoxCurrentYield = new System.Windows.Forms.TextBox();
            this.textBoxModificationLog = new System.Windows.Forms.TextBox();
            this.labelAvailableFunds = new System.Windows.Forms.Label();
            this.labelModificationLog = new System.Windows.Forms.Label();
            this.labelCurrentYield = new System.Windows.Forms.Label();
            this.TextBoxProjectLongDescription = new System.Windows.Forms.RichTextBox();
            this.TextBoxProjectShortDescritpion = new System.Windows.Forms.RichTextBox();
            this.LabelProjectImage = new System.Windows.Forms.Label();
            this.LabelProjectDetailedDescription = new System.Windows.Forms.Label();
            this.LabelProjectShortDescription = new System.Windows.Forms.Label();
            this.LabelProjectTitle = new System.Windows.Forms.Label();
            this.TextBoxProjectTitle = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonRefreshAll = new System.Windows.Forms.Button();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.tabControlVarious.SuspendLayout();
            this.tabActiveTasks.SuspendLayout();
            this.flowLayoutPanelTasks.SuspendLayout();
            this.panelNoItems.SuspendLayout();
            this.tabCreateTask.SuspendLayout();
            this.panelCreateTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTaskImage)).BeginInit();
            this.tabPageProjectSuggestions.SuspendLayout();
            this.flowLayoutPanelTeamMembers.SuspendLayout();
            this.panelNoTeamMember.SuspendLayout();
            this.tabEditProject.SuspendLayout();
            this.LabelProjectSInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectImage)).BeginInit();
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
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(16, 229);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(89, 17);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "TeamLeader";
            // 
            // pictureAvatar
            // 
            this.pictureAvatar.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
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
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(14, 168);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(167, 61);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "UserName";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(14, 280);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(128, 45);
            this.buttonEditProfile.TabIndex = 2;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
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
            this.tabControlVarious.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlVarious_SelectedIndexChanged);
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
            this.flowLayoutPanelTasks.Controls.Add(this.panelNoItems);
            this.flowLayoutPanelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTasks.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            this.flowLayoutPanelTasks.Size = new System.Drawing.Size(746, 565);
            this.flowLayoutPanelTasks.TabIndex = 0;
            this.flowLayoutPanelTasks.WrapContents = false;
            // 
            // panelNoItems
            // 
            this.panelNoItems.Controls.Add(this.buttonCreateTaskRedirector);
            this.panelNoItems.Controls.Add(this.labelNoTasks);
            this.panelNoItems.Enabled = false;
            this.panelNoItems.Location = new System.Drawing.Point(3, 3);
            this.panelNoItems.Name = "panelNoItems";
            this.panelNoItems.Size = new System.Drawing.Size(740, 159);
            this.panelNoItems.TabIndex = 0;
            this.panelNoItems.Visible = false;
            // 
            // buttonCreateTaskRedirector
            // 
            this.buttonCreateTaskRedirector.Location = new System.Drawing.Point(224, 61);
            this.buttonCreateTaskRedirector.Name = "buttonCreateTaskRedirector";
            this.buttonCreateTaskRedirector.Size = new System.Drawing.Size(261, 57);
            this.buttonCreateTaskRedirector.TabIndex = 2;
            this.buttonCreateTaskRedirector.Text = "Create new task!";
            this.buttonCreateTaskRedirector.UseVisualStyleBackColor = true;
            this.buttonCreateTaskRedirector.Click += new System.EventHandler(this.buttonCreateItem_Click);
            // 
            // labelNoTasks
            // 
            this.labelNoTasks.AutoSize = true;
            this.labelNoTasks.Location = new System.Drawing.Point(176, 16);
            this.labelNoTasks.Name = "labelNoTasks";
            this.labelNoTasks.Size = new System.Drawing.Size(321, 24);
            this.labelNoTasks.TabIndex = 1;
            this.labelNoTasks.Text = "There are currently no tasks available";
            // 
            // tabCreateTask
            // 
            this.tabCreateTask.Controls.Add(this.panelCreateTask);
            this.tabCreateTask.Location = new System.Drawing.Point(4, 31);
            this.tabCreateTask.Name = "tabCreateTask";
            this.tabCreateTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateTask.Size = new System.Drawing.Size(752, 571);
            this.tabCreateTask.TabIndex = 3;
            this.tabCreateTask.Text = "Create Task";
            this.tabCreateTask.UseVisualStyleBackColor = true;
            // 
            // panelCreateTask
            // 
            this.panelCreateTask.AutoScroll = true;
            this.panelCreateTask.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCreateTask.Controls.Add(this.dateTimePickerDeadLine);
            this.panelCreateTask.Controls.Add(this.pictureBoxTaskImage);
            this.panelCreateTask.Controls.Add(this.textBoxTaskImageURL);
            this.panelCreateTask.Controls.Add(this.labelEmptyCreateNewTask);
            this.panelCreateTask.Controls.Add(this.buttonCreateTask);
            this.panelCreateTask.Controls.Add(this.labelDeadLine);
            this.panelCreateTask.Controls.Add(this.textBoxTaskLongDescription);
            this.panelCreateTask.Controls.Add(this.textBoxTaskShortDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskImage);
            this.panelCreateTask.Controls.Add(this.labelTaskDetailedDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskShortDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskTitle);
            this.panelCreateTask.Controls.Add(this.textBoxTaskTitle);
            this.panelCreateTask.Location = new System.Drawing.Point(4, 3);
            this.panelCreateTask.Name = "panelCreateTask";
            this.panelCreateTask.Size = new System.Drawing.Size(745, 564);
            this.panelCreateTask.TabIndex = 13;
            // 
            // dateTimePickerDeadLine
            // 
            this.dateTimePickerDeadLine.CustomFormat = " yyyy-MMM-dd   HH:mm";
            this.dateTimePickerDeadLine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeadLine.Location = new System.Drawing.Point(202, 431);
            this.dateTimePickerDeadLine.Name = "dateTimePickerDeadLine";
            this.dateTimePickerDeadLine.Size = new System.Drawing.Size(270, 28);
            this.dateTimePickerDeadLine.TabIndex = 30;
            // 
            // pictureBoxTaskImage
            // 
            this.pictureBoxTaskImage.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureBoxTaskImage.Image = global::Taskr_UI_0_1.Properties.Resources.X;
            this.pictureBoxTaskImage.Location = new System.Drawing.Point(540, 427);
            this.pictureBoxTaskImage.Name = "pictureBoxTaskImage";
            this.pictureBoxTaskImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxTaskImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTaskImage.TabIndex = 29;
            this.pictureBoxTaskImage.TabStop = false;
            // 
            // textBoxTaskImageURL
            // 
            this.textBoxTaskImageURL.Location = new System.Drawing.Point(202, 350);
            this.textBoxTaskImageURL.Name = "textBoxTaskImageURL";
            this.textBoxTaskImageURL.Size = new System.Drawing.Size(507, 28);
            this.textBoxTaskImageURL.TabIndex = 24;
            this.textBoxTaskImageURL.LostFocus += new System.EventHandler(this.textBoxTaskImageURL_LostFocus);
            // 
            // labelEmptyCreateNewTask
            // 
            this.labelEmptyCreateNewTask.AutoSize = true;
            this.labelEmptyCreateNewTask.Location = new System.Drawing.Point(400, 580);
            this.labelEmptyCreateNewTask.Name = "labelEmptyCreateNewTask";
            this.labelEmptyCreateNewTask.Size = new System.Drawing.Size(0, 24);
            this.labelEmptyCreateNewTask.TabIndex = 27;
            // 
            // buttonCreateTask
            // 
            this.buttonCreateTask.Location = new System.Drawing.Point(216, 505);
            this.buttonCreateTask.Name = "buttonCreateTask";
            this.buttonCreateTask.Size = new System.Drawing.Size(238, 51);
            this.buttonCreateTask.TabIndex = 0;
            this.buttonCreateTask.Text = "Create Task";
            this.buttonCreateTask.UseVisualStyleBackColor = true;
            this.buttonCreateTask.Click += new System.EventHandler(this.buttonCreateTask_Click);
            // 
            // labelDeadLine
            // 
            this.labelDeadLine.AutoSize = true;
            this.labelDeadLine.Location = new System.Drawing.Point(21, 435);
            this.labelDeadLine.Name = "labelDeadLine";
            this.labelDeadLine.Size = new System.Drawing.Size(85, 24);
            this.labelDeadLine.TabIndex = 21;
            this.labelDeadLine.Text = "Deadline";
            // 
            // textBoxTaskLongDescription
            // 
            this.textBoxTaskLongDescription.Location = new System.Drawing.Point(202, 191);
            this.textBoxTaskLongDescription.Name = "textBoxTaskLongDescription";
            this.textBoxTaskLongDescription.Size = new System.Drawing.Size(507, 144);
            this.textBoxTaskLongDescription.TabIndex = 18;
            this.textBoxTaskLongDescription.Text = "";
            // 
            // textBoxTaskShortDescription
            // 
            this.textBoxTaskShortDescription.Location = new System.Drawing.Point(202, 89);
            this.textBoxTaskShortDescription.MaxLength = 250;
            this.textBoxTaskShortDescription.Name = "textBoxTaskShortDescription";
            this.textBoxTaskShortDescription.Size = new System.Drawing.Size(507, 74);
            this.textBoxTaskShortDescription.TabIndex = 17;
            this.textBoxTaskShortDescription.Text = "";
            // 
            // labelTaskImage
            // 
            this.labelTaskImage.AutoSize = true;
            this.labelTaskImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelTaskImage.Location = new System.Drawing.Point(21, 352);
            this.labelTaskImage.Name = "labelTaskImage";
            this.labelTaskImage.Size = new System.Drawing.Size(160, 48);
            this.labelTaskImage.TabIndex = 16;
            this.labelTaskImage.Text = "Task Image (URL)\r\n(optional)\r\n";
            // 
            // labelTaskDetailedDescription
            // 
            this.labelTaskDetailedDescription.AutoSize = true;
            this.labelTaskDetailedDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelTaskDetailedDescription.Location = new System.Drawing.Point(21, 193);
            this.labelTaskDetailedDescription.Name = "labelTaskDetailedDescription";
            this.labelTaskDetailedDescription.Size = new System.Drawing.Size(175, 24);
            this.labelTaskDetailedDescription.TabIndex = 15;
            this.labelTaskDetailedDescription.Text = "Detailed description";
            // 
            // labelTaskShortDescription
            // 
            this.labelTaskShortDescription.AutoSize = true;
            this.labelTaskShortDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelTaskShortDescription.Location = new System.Drawing.Point(21, 89);
            this.labelTaskShortDescription.Name = "labelTaskShortDescription";
            this.labelTaskShortDescription.Size = new System.Drawing.Size(185, 48);
            this.labelTaskShortDescription.TabIndex = 14;
            this.labelTaskShortDescription.Text = "Short description\r\n(max 250 characters)\r\n";
            // 
            // labelTaskTitle
            // 
            this.labelTaskTitle.AutoSize = true;
            this.labelTaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelTaskTitle.Location = new System.Drawing.Point(21, 27);
            this.labelTaskTitle.Name = "labelTaskTitle";
            this.labelTaskTitle.Size = new System.Drawing.Size(45, 24);
            this.labelTaskTitle.TabIndex = 13;
            this.labelTaskTitle.Text = "Title";
            // 
            // textBoxTaskTitle
            // 
            this.textBoxTaskTitle.Location = new System.Drawing.Point(202, 25);
            this.textBoxTaskTitle.Name = "textBoxTaskTitle";
            this.textBoxTaskTitle.Size = new System.Drawing.Size(312, 28);
            this.textBoxTaskTitle.TabIndex = 12;
            // 
            // tabPageProjectSuggestions
            // 
            this.tabPageProjectSuggestions.Controls.Add(this.flowLayoutPanelTeamMembers);
            this.tabPageProjectSuggestions.Location = new System.Drawing.Point(4, 31);
            this.tabPageProjectSuggestions.Name = "tabPageProjectSuggestions";
            this.tabPageProjectSuggestions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjectSuggestions.Size = new System.Drawing.Size(752, 571);
            this.tabPageProjectSuggestions.TabIndex = 1;
            this.tabPageProjectSuggestions.Text = "Team Members";
            this.tabPageProjectSuggestions.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTeamMembers
            // 
            this.flowLayoutPanelTeamMembers.AutoScroll = true;
            this.flowLayoutPanelTeamMembers.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelTeamMembers.Controls.Add(this.panelNoTeamMember);
            this.flowLayoutPanelTeamMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTeamMembers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTeamMembers.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelTeamMembers.Name = "flowLayoutPanelTeamMembers";
            this.flowLayoutPanelTeamMembers.Size = new System.Drawing.Size(746, 565);
            this.flowLayoutPanelTeamMembers.TabIndex = 0;
            this.flowLayoutPanelTeamMembers.WrapContents = false;
            // 
            // panelNoTeamMember
            // 
            this.panelNoTeamMember.Controls.Add(this.buttonInviteMember);
            this.panelNoTeamMember.Controls.Add(this.labelNoTeamMembers);
            this.panelNoTeamMember.Enabled = false;
            this.panelNoTeamMember.Location = new System.Drawing.Point(3, 3);
            this.panelNoTeamMember.Name = "panelNoTeamMember";
            this.panelNoTeamMember.Size = new System.Drawing.Size(740, 159);
            this.panelNoTeamMember.TabIndex = 1;
            this.panelNoTeamMember.Visible = false;
            // 
            // buttonInviteMember
            // 
            this.buttonInviteMember.Enabled = false;
            this.buttonInviteMember.Location = new System.Drawing.Point(224, 61);
            this.buttonInviteMember.Name = "buttonInviteMember";
            this.buttonInviteMember.Size = new System.Drawing.Size(261, 57);
            this.buttonInviteMember.TabIndex = 2;
            this.buttonInviteMember.Text = "Send Invite";
            this.buttonInviteMember.UseVisualStyleBackColor = true;
            this.buttonInviteMember.Visible = false;
            // 
            // labelNoTeamMembers
            // 
            this.labelNoTeamMembers.AutoSize = true;
            this.labelNoTeamMembers.Location = new System.Drawing.Point(149, 16);
            this.labelNoTeamMembers.Name = "labelNoTeamMembers";
            this.labelNoTeamMembers.Size = new System.Drawing.Size(408, 24);
            this.labelNoTeamMembers.TabIndex = 1;
            this.labelNoTeamMembers.Text = "Currently you are the sole member of your team";
            // 
            // tabEditProject
            // 
            this.tabEditProject.BackColor = System.Drawing.Color.Gainsboro;
            this.tabEditProject.Controls.Add(this.LabelProjectSInfo);
            this.tabEditProject.Controls.Add(this.checkedListBox1);
            this.tabEditProject.Location = new System.Drawing.Point(4, 31);
            this.tabEditProject.Name = "tabEditProject";
            this.tabEditProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditProject.Size = new System.Drawing.Size(752, 571);
            this.tabEditProject.TabIndex = 2;
            this.tabEditProject.Text = "Edit Project Details";
            // 
            // LabelProjectSInfo
            // 
            this.LabelProjectSInfo.AutoScroll = true;
            this.LabelProjectSInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.LabelProjectSInfo.Controls.Add(this.buttonAbolishProject);
            this.LabelProjectSInfo.Controls.Add(this.pictureBoxProjectImage);
            this.LabelProjectSInfo.Controls.Add(this.textBoxProjectImageURL);
            this.LabelProjectSInfo.Controls.Add(this.labelEmptyEditProjectDetails);
            this.LabelProjectSInfo.Controls.Add(this.textBoxAvailableFunds);
            this.LabelProjectSInfo.Controls.Add(this.ButtonUpdateProjectDetails);
            this.LabelProjectSInfo.Controls.Add(this.textBoxCurrentYield);
            this.LabelProjectSInfo.Controls.Add(this.textBoxModificationLog);
            this.LabelProjectSInfo.Controls.Add(this.labelAvailableFunds);
            this.LabelProjectSInfo.Controls.Add(this.labelModificationLog);
            this.LabelProjectSInfo.Controls.Add(this.labelCurrentYield);
            this.LabelProjectSInfo.Controls.Add(this.TextBoxProjectLongDescription);
            this.LabelProjectSInfo.Controls.Add(this.TextBoxProjectShortDescritpion);
            this.LabelProjectSInfo.Controls.Add(this.LabelProjectImage);
            this.LabelProjectSInfo.Controls.Add(this.LabelProjectDetailedDescription);
            this.LabelProjectSInfo.Controls.Add(this.LabelProjectShortDescription);
            this.LabelProjectSInfo.Controls.Add(this.LabelProjectTitle);
            this.LabelProjectSInfo.Controls.Add(this.TextBoxProjectTitle);
            this.LabelProjectSInfo.Location = new System.Drawing.Point(3, 3);
            this.LabelProjectSInfo.Name = "LabelProjectSInfo";
            this.LabelProjectSInfo.Size = new System.Drawing.Size(745, 564);
            this.LabelProjectSInfo.TabIndex = 12;
            // 
            // buttonAbolishProject
            // 
            this.buttonAbolishProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbolishProject.Location = new System.Drawing.Point(471, 590);
            this.buttonAbolishProject.Name = "buttonAbolishProject";
            this.buttonAbolishProject.Size = new System.Drawing.Size(238, 51);
            this.buttonAbolishProject.TabIndex = 30;
            this.buttonAbolishProject.Text = "Abolish Project";
            this.buttonAbolishProject.UseVisualStyleBackColor = true;
            this.buttonAbolishProject.Click += new System.EventHandler(this.buttonAbolishProject_Click);
            // 
            // pictureBoxProjectImage
            // 
            this.pictureBoxProjectImage.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureBoxProjectImage.Image = global::Taskr_UI_0_1.Properties.Resources.X;
            this.pictureBoxProjectImage.Location = new System.Drawing.Point(508, 393);
            this.pictureBoxProjectImage.Name = "pictureBoxProjectImage";
            this.pictureBoxProjectImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxProjectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProjectImage.TabIndex = 29;
            this.pictureBoxProjectImage.TabStop = false;
            // 
            // textBoxProjectImageURL
            // 
            this.textBoxProjectImageURL.Location = new System.Drawing.Point(202, 350);
            this.textBoxProjectImageURL.Name = "textBoxProjectImageURL";
            this.textBoxProjectImageURL.Size = new System.Drawing.Size(507, 28);
            this.textBoxProjectImageURL.TabIndex = 24;
            this.textBoxProjectImageURL.TextChanged += new System.EventHandler(this.textBoxImageURL_TextChanged);
            this.textBoxProjectImageURL.LostFocus += new System.EventHandler(this.textBoxProjectImageURL_LostFocus);
            // 
            // labelEmptyEditProjectDetails
            // 
            this.labelEmptyEditProjectDetails.AutoSize = true;
            this.labelEmptyEditProjectDetails.Location = new System.Drawing.Point(400, 650);
            this.labelEmptyEditProjectDetails.Name = "labelEmptyEditProjectDetails";
            this.labelEmptyEditProjectDetails.Size = new System.Drawing.Size(0, 24);
            this.labelEmptyEditProjectDetails.TabIndex = 27;
            // 
            // textBoxAvailableFunds
            // 
            this.textBoxAvailableFunds.Location = new System.Drawing.Point(202, 467);
            this.textBoxAvailableFunds.Name = "textBoxAvailableFunds";
            this.textBoxAvailableFunds.Size = new System.Drawing.Size(223, 28);
            this.textBoxAvailableFunds.TabIndex = 26;
            this.textBoxAvailableFunds.TextChanged += new System.EventHandler(this.textBoxAvailableFunds_TextChanged);
            // 
            // ButtonUpdateProjectDetails
            // 
            this.ButtonUpdateProjectDetails.Location = new System.Drawing.Point(202, 590);
            this.ButtonUpdateProjectDetails.Name = "ButtonUpdateProjectDetails";
            this.ButtonUpdateProjectDetails.Size = new System.Drawing.Size(238, 51);
            this.ButtonUpdateProjectDetails.TabIndex = 0;
            this.ButtonUpdateProjectDetails.Text = "Update Details";
            this.ButtonUpdateProjectDetails.UseVisualStyleBackColor = true;
            this.ButtonUpdateProjectDetails.Click += new System.EventHandler(this.ButtonUpdateProjectDetails_Click);
            // 
            // textBoxCurrentYield
            // 
            this.textBoxCurrentYield.Location = new System.Drawing.Point(202, 411);
            this.textBoxCurrentYield.Name = "textBoxCurrentYield";
            this.textBoxCurrentYield.Size = new System.Drawing.Size(223, 28);
            this.textBoxCurrentYield.TabIndex = 25;
            this.textBoxCurrentYield.TextChanged += new System.EventHandler(this.textBoxCurrentYield_TextChanged);
            // 
            // textBoxModificationLog
            // 
            this.textBoxModificationLog.Location = new System.Drawing.Point(202, 533);
            this.textBoxModificationLog.Name = "textBoxModificationLog";
            this.textBoxModificationLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxModificationLog.Size = new System.Drawing.Size(507, 28);
            this.textBoxModificationLog.TabIndex = 28;
            this.textBoxModificationLog.TextChanged += new System.EventHandler(this.textBoxModificationLog_TextChanged);
            // 
            // labelAvailableFunds
            // 
            this.labelAvailableFunds.AutoSize = true;
            this.labelAvailableFunds.Location = new System.Drawing.Point(21, 467);
            this.labelAvailableFunds.Name = "labelAvailableFunds";
            this.labelAvailableFunds.Size = new System.Drawing.Size(145, 24);
            this.labelAvailableFunds.TabIndex = 23;
            this.labelAvailableFunds.Text = "Available Funds";
            // 
            // labelModificationLog
            // 
            this.labelModificationLog.AutoSize = true;
            this.labelModificationLog.Location = new System.Drawing.Point(21, 533);
            this.labelModificationLog.Name = "labelModificationLog";
            this.labelModificationLog.Size = new System.Drawing.Size(156, 48);
            this.labelModificationLog.TabIndex = 22;
            this.labelModificationLog.Text = "Modifications Log\r\n(URL)";
            // 
            // labelCurrentYield
            // 
            this.labelCurrentYield.AutoSize = true;
            this.labelCurrentYield.Location = new System.Drawing.Point(21, 411);
            this.labelCurrentYield.Name = "labelCurrentYield";
            this.labelCurrentYield.Size = new System.Drawing.Size(119, 24);
            this.labelCurrentYield.TabIndex = 21;
            this.labelCurrentYield.Text = "Current Yield";
            // 
            // TextBoxProjectLongDescription
            // 
            this.TextBoxProjectLongDescription.Location = new System.Drawing.Point(202, 191);
            this.TextBoxProjectLongDescription.Name = "TextBoxProjectLongDescription";
            this.TextBoxProjectLongDescription.Size = new System.Drawing.Size(507, 144);
            this.TextBoxProjectLongDescription.TabIndex = 18;
            this.TextBoxProjectLongDescription.Text = "";
            this.TextBoxProjectLongDescription.TextChanged += new System.EventHandler(this.TextBoxProjectLongDescription_TextChanged);
            // 
            // TextBoxProjectShortDescritpion
            // 
            this.TextBoxProjectShortDescritpion.Location = new System.Drawing.Point(202, 89);
            this.TextBoxProjectShortDescritpion.MaxLength = 250;
            this.TextBoxProjectShortDescritpion.Name = "TextBoxProjectShortDescritpion";
            this.TextBoxProjectShortDescritpion.Size = new System.Drawing.Size(507, 74);
            this.TextBoxProjectShortDescritpion.TabIndex = 17;
            this.TextBoxProjectShortDescritpion.Text = "";
            this.TextBoxProjectShortDescritpion.TextChanged += new System.EventHandler(this.TextBoxProjectShortDescritpion_TextChanged);
            // 
            // LabelProjectImage
            // 
            this.LabelProjectImage.AutoSize = true;
            this.LabelProjectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectImage.Location = new System.Drawing.Point(21, 352);
            this.LabelProjectImage.Name = "LabelProjectImage";
            this.LabelProjectImage.Size = new System.Drawing.Size(178, 24);
            this.LabelProjectImage.TabIndex = 16;
            this.LabelProjectImage.Text = "Project Image (URL)\r\n";
            // 
            // LabelProjectDetailedDescription
            // 
            this.LabelProjectDetailedDescription.AutoSize = true;
            this.LabelProjectDetailedDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectDetailedDescription.Location = new System.Drawing.Point(21, 193);
            this.LabelProjectDetailedDescription.Name = "LabelProjectDetailedDescription";
            this.LabelProjectDetailedDescription.Size = new System.Drawing.Size(175, 24);
            this.LabelProjectDetailedDescription.TabIndex = 15;
            this.LabelProjectDetailedDescription.Text = "Detailed description";
            // 
            // LabelProjectShortDescription
            // 
            this.LabelProjectShortDescription.AutoSize = true;
            this.LabelProjectShortDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectShortDescription.Location = new System.Drawing.Point(21, 89);
            this.LabelProjectShortDescription.Name = "LabelProjectShortDescription";
            this.LabelProjectShortDescription.Size = new System.Drawing.Size(185, 48);
            this.LabelProjectShortDescription.TabIndex = 14;
            this.LabelProjectShortDescription.Text = "Short description\r\n(max 250 characters)\r\n";
            // 
            // LabelProjectTitle
            // 
            this.LabelProjectTitle.AutoSize = true;
            this.LabelProjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.LabelProjectTitle.Location = new System.Drawing.Point(21, 27);
            this.LabelProjectTitle.Name = "LabelProjectTitle";
            this.LabelProjectTitle.Size = new System.Drawing.Size(45, 24);
            this.LabelProjectTitle.TabIndex = 13;
            this.LabelProjectTitle.Text = "Title";
            // 
            // TextBoxProjectTitle
            // 
            this.TextBoxProjectTitle.Location = new System.Drawing.Point(202, 25);
            this.TextBoxProjectTitle.Name = "TextBoxProjectTitle";
            this.TextBoxProjectTitle.Size = new System.Drawing.Size(312, 28);
            this.TextBoxProjectTitle.TabIndex = 12;
            this.TextBoxProjectTitle.TextChanged += new System.EventHandler(this.TextBoxProjectTitle_TextChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(43, 203);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 9;
            // 
            // buttonRefreshAll
            // 
            this.buttonRefreshAll.Location = new System.Drawing.Point(795, 12);
            this.buttonRefreshAll.Name = "buttonRefreshAll";
            this.buttonRefreshAll.Size = new System.Drawing.Size(185, 38);
            this.buttonRefreshAll.TabIndex = 7;
            this.buttonRefreshAll.Text = "Refresh All";
            this.buttonRefreshAll.UseVisualStyleBackColor = true;
            this.buttonRefreshAll.Click += new System.EventHandler(this.buttonRefreshAll_Click);
            // 
            // TeamLeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1002, 654);
            this.Controls.Add(this.buttonRefreshAll);
            this.Controls.Add(this.tabControlVarious);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TeamLeader";
            this.Text = "FreeLancer";
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.tabControlVarious.ResumeLayout(false);
            this.tabActiveTasks.ResumeLayout(false);
            this.tabActiveTasks.PerformLayout();
            this.flowLayoutPanelTasks.ResumeLayout(false);
            this.panelNoItems.ResumeLayout(false);
            this.panelNoItems.PerformLayout();
            this.tabCreateTask.ResumeLayout(false);
            this.panelCreateTask.ResumeLayout(false);
            this.panelCreateTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTaskImage)).EndInit();
            this.tabPageProjectSuggestions.ResumeLayout(false);
            this.flowLayoutPanelTeamMembers.ResumeLayout(false);
            this.panelNoTeamMember.ResumeLayout(false);
            this.panelNoTeamMember.PerformLayout();
            this.tabEditProject.ResumeLayout(false);
            this.LabelProjectSInfo.ResumeLayout(false);
            this.LabelProjectSInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectImage)).EndInit();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTeamMembers;
        private System.Windows.Forms.TabPage tabCreateTask;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TabPage tabEditProject;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ButtonUpdateProjectDetails;
        private System.Windows.Forms.Panel LabelProjectSInfo;
        private System.Windows.Forms.TextBox textBoxProjectImageURL;
        private System.Windows.Forms.Label labelEmptyEditProjectDetails;
        private System.Windows.Forms.TextBox textBoxAvailableFunds;
        private System.Windows.Forms.TextBox textBoxCurrentYield;
        private System.Windows.Forms.TextBox textBoxModificationLog;
        private System.Windows.Forms.Label labelAvailableFunds;
        private System.Windows.Forms.Label labelModificationLog;
        private System.Windows.Forms.Label labelCurrentYield;
        private System.Windows.Forms.RichTextBox TextBoxProjectLongDescription;
        private System.Windows.Forms.RichTextBox TextBoxProjectShortDescritpion;
        private System.Windows.Forms.Label LabelProjectImage;
        private System.Windows.Forms.Label LabelProjectDetailedDescription;
        private System.Windows.Forms.Label LabelProjectShortDescription;
        private System.Windows.Forms.Label LabelProjectTitle;
        private System.Windows.Forms.TextBox TextBoxProjectTitle;
        private System.Windows.Forms.PictureBox pictureBoxProjectImage;
        private System.Windows.Forms.Panel panelNoItems;
        private System.Windows.Forms.Button buttonCreateTaskRedirector;
        private System.Windows.Forms.Label labelNoTasks;
        private System.Windows.Forms.Panel panelCreateTask;
        private System.Windows.Forms.PictureBox pictureBoxTaskImage;
        private System.Windows.Forms.TextBox textBoxTaskImageURL;
        private System.Windows.Forms.Label labelEmptyCreateNewTask;
        private System.Windows.Forms.Button buttonCreateTask;
        private System.Windows.Forms.Label labelDeadLine;
        private System.Windows.Forms.RichTextBox textBoxTaskLongDescription;
        private System.Windows.Forms.RichTextBox textBoxTaskShortDescription;
        private System.Windows.Forms.Label labelTaskImage;
        private System.Windows.Forms.Label labelTaskDetailedDescription;
        private System.Windows.Forms.Label labelTaskShortDescription;
        private System.Windows.Forms.Label labelTaskTitle;
        private System.Windows.Forms.TextBox textBoxTaskTitle;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadLine;
        private Button buttonAbolishProject;
        private Button buttonRefreshAll;
        private Panel panelNoTeamMember;
        private Button buttonInviteMember;
        private Label labelNoTeamMembers;
    }
}