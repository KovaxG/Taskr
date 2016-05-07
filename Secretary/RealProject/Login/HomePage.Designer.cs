﻿namespace Login
{
    partial class HomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCreateNewUser = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.panelSide = new System.Windows.Forms.Panel();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.TabControlUsers = new System.Windows.Forms.TabControl();
            this.TabPageUsers = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchUserLastName = new System.Windows.Forms.TextBox();
            this.textBoxSearchUserFirstName = new System.Windows.Forms.TextBox();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.ColumnEdit1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnRemoveUsers = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TabPageFormerUser = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSearchFormerUserLastName = new System.Windows.Forms.TextBox();
            this.textBoxSearchFormerUserFirstName = new System.Windows.Forms.TextBox();
            this.dataGridViewFormerUsers = new System.Windows.Forms.DataGridView();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageSecretary = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSearchSecretaryLastName = new System.Windows.Forms.TextBox();
            this.textBoxSearchSecretaryFirstName = new System.Windows.Forms.TextBox();
            this.dataGridViewSecretary = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageFormerSecretary = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxSearchFormerSecretaryLastName = new System.Windows.Forms.TextBox();
            this.textBoxSearchFormerSecretaryFirstName = new System.Windows.Forms.TextBox();
            this.dataGridViewFormerSecretary = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PanelUsers = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).BeginInit();
            this.TabControlUsers.SuspendLayout();
            this.TabPageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.TabPageFormerUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormerUsers)).BeginInit();
            this.tabPageSecretary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecretary)).BeginInit();
            this.tabPageFormerSecretary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormerSecretary)).BeginInit();
            this.PanelUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateNewUser
            // 
            this.buttonCreateNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateNewUser.Location = new System.Drawing.Point(37, 349);
            this.buttonCreateNewUser.Name = "buttonCreateNewUser";
            this.buttonCreateNewUser.Size = new System.Drawing.Size(128, 45);
            this.buttonCreateNewUser.TabIndex = 7;
            this.buttonCreateNewUser.Text = "Create new User";
            this.buttonCreateNewUser.UseVisualStyleBackColor = true;
            this.buttonCreateNewUser.Click += new System.EventHandler(this.buttonCreateNewUser_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(37, 150);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(128, 29);
            this.labelUsername.TabIndex = 10;
            this.labelUsername.Text = "UserName";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProfile.Location = new System.Drawing.Point(37, 209);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(128, 45);
            this.buttonEditProfile.TabIndex = 11;
            this.buttonEditProfile.Text = "Edit Profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSide.Controls.Add(this.comboBoxStatus);
            this.panelSide.Controls.Add(this.labelUsername);
            this.panelSide.Controls.Add(this.buttonRefresh);
            this.panelSide.Controls.Add(this.buttonEditProfile);
            this.panelSide.Controls.Add(this.buttonCreateNewUser);
            this.panelSide.Controls.Add(this.buttonLogout);
            this.panelSide.Location = new System.Drawing.Point(12, 22);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(203, 630);
            this.panelSide.TabIndex = 12;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(37, 182);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(128, 21);
            this.comboBoxStatus.TabIndex = 13;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(37, 260);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(128, 45);
            this.buttonRefresh.TabIndex = 9;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(37, 549);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(128, 45);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureAvatar
            // 
            this.pictureAvatar.Location = new System.Drawing.Point(49, 41);
            this.pictureAvatar.Name = "pictureAvatar";
            this.pictureAvatar.Size = new System.Drawing.Size(128, 128);
            this.pictureAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAvatar.TabIndex = 9;
            this.pictureAvatar.TabStop = false;
            this.pictureAvatar.Click += new System.EventHandler(this.pictureAvatar_Click);
            // 
            // TabControlUsers
            // 
            this.TabControlUsers.Controls.Add(this.TabPageUsers);
            this.TabControlUsers.Controls.Add(this.TabPageFormerUser);
            this.TabControlUsers.Controls.Add(this.tabPageSecretary);
            this.TabControlUsers.Controls.Add(this.tabPageFormerSecretary);
            this.TabControlUsers.Location = new System.Drawing.Point(34, 19);
            this.TabControlUsers.Name = "TabControlUsers";
            this.TabControlUsers.SelectedIndex = 0;
            this.TabControlUsers.Size = new System.Drawing.Size(858, 630);
            this.TabControlUsers.TabIndex = 0;
            // 
            // TabPageUsers
            // 
            this.TabPageUsers.Controls.Add(this.label3);
            this.TabPageUsers.Controls.Add(this.label2);
            this.TabPageUsers.Controls.Add(this.label1);
            this.TabPageUsers.Controls.Add(this.textBoxSearchUserLastName);
            this.TabPageUsers.Controls.Add(this.textBoxSearchUserFirstName);
            this.TabPageUsers.Controls.Add(this.dataGridViewUsers);
            this.TabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.TabPageUsers.Name = "TabPageUsers";
            this.TabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageUsers.Size = new System.Drawing.Size(850, 604);
            this.TabPageUsers.TabIndex = 0;
            this.TabPageUsers.Text = "Users";
            this.TabPageUsers.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "LastName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FirstName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // textBoxSearchUserLastName
            // 
            this.textBoxSearchUserLastName.Location = new System.Drawing.Point(448, 7);
            this.textBoxSearchUserLastName.Name = "textBoxSearchUserLastName";
            this.textBoxSearchUserLastName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchUserLastName.TabIndex = 3;
            this.textBoxSearchUserLastName.TextChanged += new System.EventHandler(this.textBoxSearchLastName_TextChanged);
            // 
            // textBoxSearchUserFirstName
            // 
            this.textBoxSearchUserFirstName.Location = new System.Drawing.Point(228, 7);
            this.textBoxSearchUserFirstName.Name = "textBoxSearchUserFirstName";
            this.textBoxSearchUserFirstName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchUserFirstName.TabIndex = 2;
            this.textBoxSearchUserFirstName.TextChanged += new System.EventHandler(this.textBoxSearchFirstName_TextChanged);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEdit1,
            this.ColumnRemoveUsers});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUsers.Location = new System.Drawing.Point(31, 43);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(794, 528);
            this.dataGridViewUsers.TabIndex = 1;
            this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick);
            // 
            // ColumnEdit1
            // 
            this.ColumnEdit1.HeaderText = "Edit";
            this.ColumnEdit1.Name = "ColumnEdit1";
            this.ColumnEdit1.ReadOnly = true;
            // 
            // ColumnRemoveUsers
            // 
            this.ColumnRemoveUsers.HeaderText = "Remove";
            this.ColumnRemoveUsers.Name = "ColumnRemoveUsers";
            this.ColumnRemoveUsers.ReadOnly = true;
            // 
            // TabPageFormerUser
            // 
            this.TabPageFormerUser.Controls.Add(this.label4);
            this.TabPageFormerUser.Controls.Add(this.label5);
            this.TabPageFormerUser.Controls.Add(this.label6);
            this.TabPageFormerUser.Controls.Add(this.textBoxSearchFormerUserLastName);
            this.TabPageFormerUser.Controls.Add(this.textBoxSearchFormerUserFirstName);
            this.TabPageFormerUser.Controls.Add(this.dataGridViewFormerUsers);
            this.TabPageFormerUser.Location = new System.Drawing.Point(4, 22);
            this.TabPageFormerUser.Name = "TabPageFormerUser";
            this.TabPageFormerUser.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFormerUser.Size = new System.Drawing.Size(850, 604);
            this.TabPageFormerUser.TabIndex = 1;
            this.TabPageFormerUser.Text = "Former Users";
            this.TabPageFormerUser.UseVisualStyleBackColor = true;
            this.TabPageFormerUser.Click += new System.EventHandler(this.TabPageFormerUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "LastName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "FirstName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Search";
            // 
            // textBoxSearchFormerUserLastName
            // 
            this.textBoxSearchFormerUserLastName.Location = new System.Drawing.Point(526, 12);
            this.textBoxSearchFormerUserLastName.Name = "textBoxSearchFormerUserLastName";
            this.textBoxSearchFormerUserLastName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchFormerUserLastName.TabIndex = 8;
            this.textBoxSearchFormerUserLastName.TextChanged += new System.EventHandler(this.textBoxSearchFormerUserLastName_TextChanged);
            // 
            // textBoxSearchFormerUserFirstName
            // 
            this.textBoxSearchFormerUserFirstName.Location = new System.Drawing.Point(306, 12);
            this.textBoxSearchFormerUserFirstName.Name = "textBoxSearchFormerUserFirstName";
            this.textBoxSearchFormerUserFirstName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchFormerUserFirstName.TabIndex = 7;
            this.textBoxSearchFormerUserFirstName.TextChanged += new System.EventHandler(this.textBoxSearchFormerUserFirstName_TextChanged);
            // 
            // dataGridViewFormerUsers
            // 
            this.dataGridViewFormerUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFormerUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFormerUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEdit});
            this.dataGridViewFormerUsers.Location = new System.Drawing.Point(26, 51);
            this.dataGridViewFormerUsers.Name = "dataGridViewFormerUsers";
            this.dataGridViewFormerUsers.ReadOnly = true;
            this.dataGridViewFormerUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFormerUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFormerUsers.Size = new System.Drawing.Size(798, 515);
            this.dataGridViewFormerUsers.TabIndex = 2;
            this.dataGridViewFormerUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFormerUsers_CellContentClick);
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.HeaderText = "Edit";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            // 
            // tabPageSecretary
            // 
            this.tabPageSecretary.Controls.Add(this.label7);
            this.tabPageSecretary.Controls.Add(this.label8);
            this.tabPageSecretary.Controls.Add(this.label9);
            this.tabPageSecretary.Controls.Add(this.textBoxSearchSecretaryLastName);
            this.tabPageSecretary.Controls.Add(this.textBoxSearchSecretaryFirstName);
            this.tabPageSecretary.Controls.Add(this.dataGridViewSecretary);
            this.tabPageSecretary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSecretary.Name = "tabPageSecretary";
            this.tabPageSecretary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSecretary.Size = new System.Drawing.Size(850, 604);
            this.tabPageSecretary.TabIndex = 2;
            this.tabPageSecretary.Text = "Secretaries";
            this.tabPageSecretary.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "LastName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "FirstName";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Search";
            // 
            // textBoxSearchSecretaryLastName
            // 
            this.textBoxSearchSecretaryLastName.Location = new System.Drawing.Point(508, 13);
            this.textBoxSearchSecretaryLastName.Name = "textBoxSearchSecretaryLastName";
            this.textBoxSearchSecretaryLastName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchSecretaryLastName.TabIndex = 8;
            this.textBoxSearchSecretaryLastName.TextChanged += new System.EventHandler(this.textBoxSearchSecretaryLastName_TextChanged);
            // 
            // textBoxSearchSecretaryFirstName
            // 
            this.textBoxSearchSecretaryFirstName.Location = new System.Drawing.Point(288, 13);
            this.textBoxSearchSecretaryFirstName.Name = "textBoxSearchSecretaryFirstName";
            this.textBoxSearchSecretaryFirstName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchSecretaryFirstName.TabIndex = 7;
            this.textBoxSearchSecretaryFirstName.TextChanged += new System.EventHandler(this.textBoxSearchSecretaryFirstName_TextChanged);
            // 
            // dataGridViewSecretary
            // 
            this.dataGridViewSecretary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSecretary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSecretary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.ColumnRemove});
            this.dataGridViewSecretary.Location = new System.Drawing.Point(23, 50);
            this.dataGridViewSecretary.Name = "dataGridViewSecretary";
            this.dataGridViewSecretary.ReadOnly = true;
            this.dataGridViewSecretary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSecretary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSecretary.Size = new System.Drawing.Size(798, 527);
            this.dataGridViewSecretary.TabIndex = 3;
            this.dataGridViewSecretary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSecretary_CellContentClick);
            this.dataGridViewSecretary.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewSecretary_UserDeletingRow);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Edit";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // ColumnRemove
            // 
            this.ColumnRemove.HeaderText = "Remove";
            this.ColumnRemove.Name = "ColumnRemove";
            this.ColumnRemove.ReadOnly = true;
            // 
            // tabPageFormerSecretary
            // 
            this.tabPageFormerSecretary.Controls.Add(this.label10);
            this.tabPageFormerSecretary.Controls.Add(this.label11);
            this.tabPageFormerSecretary.Controls.Add(this.label12);
            this.tabPageFormerSecretary.Controls.Add(this.textBoxSearchFormerSecretaryLastName);
            this.tabPageFormerSecretary.Controls.Add(this.textBoxSearchFormerSecretaryFirstName);
            this.tabPageFormerSecretary.Controls.Add(this.dataGridViewFormerSecretary);
            this.tabPageFormerSecretary.Location = new System.Drawing.Point(4, 22);
            this.tabPageFormerSecretary.Name = "tabPageFormerSecretary";
            this.tabPageFormerSecretary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFormerSecretary.Size = new System.Drawing.Size(850, 604);
            this.tabPageFormerSecretary.TabIndex = 3;
            this.tabPageFormerSecretary.Text = "Former Secretaries";
            this.tabPageFormerSecretary.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(457, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "LastName";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "FirstName";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(149, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Search";
            // 
            // textBoxSearchFormerSecretaryLastName
            // 
            this.textBoxSearchFormerSecretaryLastName.Location = new System.Drawing.Point(527, 17);
            this.textBoxSearchFormerSecretaryLastName.Name = "textBoxSearchFormerSecretaryLastName";
            this.textBoxSearchFormerSecretaryLastName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchFormerSecretaryLastName.TabIndex = 8;
            this.textBoxSearchFormerSecretaryLastName.TextChanged += new System.EventHandler(this.textBoxSearchFormerSecretaryLastName_TextChanged);
            // 
            // textBoxSearchFormerSecretaryFirstName
            // 
            this.textBoxSearchFormerSecretaryFirstName.Location = new System.Drawing.Point(307, 17);
            this.textBoxSearchFormerSecretaryFirstName.Name = "textBoxSearchFormerSecretaryFirstName";
            this.textBoxSearchFormerSecretaryFirstName.Size = new System.Drawing.Size(103, 20);
            this.textBoxSearchFormerSecretaryFirstName.TabIndex = 7;
            this.textBoxSearchFormerSecretaryFirstName.TextChanged += new System.EventHandler(this.textBoxSearchFormerSecretaryFirstName_TextChanged);
            // 
            // dataGridViewFormerSecretary
            // 
            this.dataGridViewFormerSecretary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFormerSecretary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFormerSecretary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn2});
            this.dataGridViewFormerSecretary.Location = new System.Drawing.Point(26, 56);
            this.dataGridViewFormerSecretary.Name = "dataGridViewFormerSecretary";
            this.dataGridViewFormerSecretary.ReadOnly = true;
            this.dataGridViewFormerSecretary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFormerSecretary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFormerSecretary.Size = new System.Drawing.Size(798, 519);
            this.dataGridViewFormerSecretary.TabIndex = 4;
            this.dataGridViewFormerSecretary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Edit";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            // 
            // PanelUsers
            // 
            this.PanelUsers.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelUsers.Controls.Add(this.TabControlUsers);
            this.PanelUsers.Location = new System.Drawing.Point(253, 22);
            this.PanelUsers.Name = "PanelUsers";
            this.PanelUsers.Size = new System.Drawing.Size(935, 630);
            this.PanelUsers.TabIndex = 13;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 687);
            this.Controls.Add(this.PanelUsers);
            this.Controls.Add(this.pictureAvatar);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HomePage";
            this.Text = "Form1";
            this.panelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAvatar)).EndInit();
            this.TabControlUsers.ResumeLayout(false);
            this.TabPageUsers.ResumeLayout(false);
            this.TabPageUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.TabPageFormerUser.ResumeLayout(false);
            this.TabPageFormerUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormerUsers)).EndInit();
            this.tabPageSecretary.ResumeLayout(false);
            this.tabPageSecretary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecretary)).EndInit();
            this.tabPageFormerSecretary.ResumeLayout(false);
            this.tabPageFormerSecretary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFormerSecretary)).EndInit();
            this.PanelUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateNewUser;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureAvatar;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        internal System.Windows.Forms.TabControl TabControlUsers;
        internal System.Windows.Forms.TabPage TabPageUsers;
        internal System.Windows.Forms.DataGridView dataGridViewUsers;
        internal System.Windows.Forms.TabPage TabPageFormerUser;
        internal System.Windows.Forms.DataGridView dataGridViewFormerUsers;
        private System.Windows.Forms.Panel PanelUsers;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit1;
        private System.Windows.Forms.TabPage tabPageSecretary;
        internal System.Windows.Forms.DataGridView dataGridViewSecretary;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TextBox textBoxSearchUserFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchUserLastName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageFormerSecretary;
        internal System.Windows.Forms.DataGridView dataGridViewFormerSecretary;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSearchFormerUserLastName;
        private System.Windows.Forms.TextBox textBoxSearchFormerUserFirstName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSearchSecretaryLastName;
        private System.Windows.Forms.TextBox textBoxSearchSecretaryFirstName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxSearchFormerSecretaryLastName;
        private System.Windows.Forms.TextBox textBoxSearchFormerSecretaryFirstName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnRemove;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnRemoveUsers;
    }
}

