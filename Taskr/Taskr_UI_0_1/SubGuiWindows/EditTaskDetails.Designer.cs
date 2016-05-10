namespace Taskr_UI_0_1.SubGuiWindows
{
    partial class EditTaskDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTaskDetails));
            this.panelCreateTask = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerDeadLine = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxTaskImage = new System.Windows.Forms.PictureBox();
            this.textBoxTaskImageURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdateTask = new System.Windows.Forms.Button();
            this.labelDeadLine = new System.Windows.Forms.Label();
            this.textBoxTaskLongDescription = new System.Windows.Forms.RichTextBox();
            this.textBoxTaskShortDescription = new System.Windows.Forms.RichTextBox();
            this.labelTaskImage = new System.Windows.Forms.Label();
            this.labelTaskDetailedDescription = new System.Windows.Forms.Label();
            this.labelTaskShortDescription = new System.Windows.Forms.Label();
            this.labelTaskTitle = new System.Windows.Forms.Label();
            this.textBoxTaskTitle = new System.Windows.Forms.TextBox();
            this.panelCreateTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTaskImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCreateTask
            // 
            this.panelCreateTask.AutoScroll = true;
            this.panelCreateTask.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCreateTask.Controls.Add(this.buttonCancel);
            this.panelCreateTask.Controls.Add(this.dateTimePickerDeadLine);
            this.panelCreateTask.Controls.Add(this.pictureBoxTaskImage);
            this.panelCreateTask.Controls.Add(this.textBoxTaskImageURL);
            this.panelCreateTask.Controls.Add(this.label1);
            this.panelCreateTask.Controls.Add(this.buttonUpdateTask);
            this.panelCreateTask.Controls.Add(this.labelDeadLine);
            this.panelCreateTask.Controls.Add(this.textBoxTaskLongDescription);
            this.panelCreateTask.Controls.Add(this.textBoxTaskShortDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskImage);
            this.panelCreateTask.Controls.Add(this.labelTaskDetailedDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskShortDescription);
            this.panelCreateTask.Controls.Add(this.labelTaskTitle);
            this.panelCreateTask.Controls.Add(this.textBoxTaskTitle);
            this.panelCreateTask.Location = new System.Drawing.Point(3, 3);
            this.panelCreateTask.Name = "panelCreateTask";
            this.panelCreateTask.Size = new System.Drawing.Size(745, 669);
            this.panelCreateTask.TabIndex = 14;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(482, 583);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(227, 51);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePickerDeadLine
            // 
            this.dateTimePickerDeadLine.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.dateTimePickerDeadLine.CalendarTitleBackColor = System.Drawing.Color.AntiqueWhite;
            this.dateTimePickerDeadLine.CustomFormat = " yyyy-MMM-dd   HH:mm";
            this.dateTimePickerDeadLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDeadLine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeadLine.Location = new System.Drawing.Point(202, 451);
            this.dateTimePickerDeadLine.Name = "dateTimePickerDeadLine";
            this.dateTimePickerDeadLine.Size = new System.Drawing.Size(270, 22);
            this.dateTimePickerDeadLine.TabIndex = 30;
            this.dateTimePickerDeadLine.ValueChanged += new System.EventHandler(this.dateTimePickerDeadLine_ValueChanged);
            // 
            // pictureBoxTaskImage
            // 
            this.pictureBoxTaskImage.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureBoxTaskImage.Image = global::Taskr_UI_0_1.Properties.Resources.X;
            this.pictureBoxTaskImage.Location = new System.Drawing.Point(508, 393);
            this.pictureBoxTaskImage.Name = "pictureBoxTaskImage";
            this.pictureBoxTaskImage.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxTaskImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTaskImage.TabIndex = 29;
            this.pictureBoxTaskImage.TabStop = false;
            // 
            // textBoxTaskImageURL
            // 
            this.textBoxTaskImageURL.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTaskImageURL.Location = new System.Drawing.Point(202, 350);
            this.textBoxTaskImageURL.Name = "textBoxTaskImageURL";
            this.textBoxTaskImageURL.Size = new System.Drawing.Size(507, 22);
            this.textBoxTaskImageURL.TabIndex = 24;
            this.textBoxTaskImageURL.TextChanged += new System.EventHandler(this.textBoxTaskImageURL_TextChanged);
            this.textBoxTaskImageURL.LostFocus += new System.EventHandler(this.textBoxTaskImageURL_LostFocus);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 27;
            // 
            // buttonUpdateTask
            // 
            this.buttonUpdateTask.Location = new System.Drawing.Point(193, 583);
            this.buttonUpdateTask.Name = "buttonUpdateTask";
            this.buttonUpdateTask.Size = new System.Drawing.Size(238, 51);
            this.buttonUpdateTask.TabIndex = 0;
            this.buttonUpdateTask.Text = "Update Task";
            this.buttonUpdateTask.UseVisualStyleBackColor = true;
            this.buttonUpdateTask.Click += new System.EventHandler(this.buttonUpdateTask_Click);
            // 
            // labelDeadLine
            // 
            this.labelDeadLine.AutoSize = true;
            this.labelDeadLine.Location = new System.Drawing.Point(21, 455);
            this.labelDeadLine.Name = "labelDeadLine";
            this.labelDeadLine.Size = new System.Drawing.Size(64, 17);
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
            this.textBoxTaskLongDescription.TextChanged += new System.EventHandler(this.textBoxTaskLongDescription_TextChanged);
            // 
            // textBoxTaskShortDescription
            // 
            this.textBoxTaskShortDescription.Location = new System.Drawing.Point(202, 89);
            this.textBoxTaskShortDescription.MaxLength = 250;
            this.textBoxTaskShortDescription.Name = "textBoxTaskShortDescription";
            this.textBoxTaskShortDescription.Size = new System.Drawing.Size(507, 74);
            this.textBoxTaskShortDescription.TabIndex = 17;
            this.textBoxTaskShortDescription.Text = "";
            this.textBoxTaskShortDescription.TextChanged += new System.EventHandler(this.TextBoxTaskShortDescritpion_TextChanged);
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
            this.textBoxTaskTitle.Size = new System.Drawing.Size(312, 22);
            this.textBoxTaskTitle.TabIndex = 12;
            this.textBoxTaskTitle.TextChanged += new System.EventHandler(this.TextBoxTaskTitle_TextChanged);
            // 
            // EditTaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 675);
            this.Controls.Add(this.panelCreateTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditTaskDetails";
            this.Text = "Edit Task Details";
            this.panelCreateTask.ResumeLayout(false);
            this.panelCreateTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTaskImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCreateTask;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadLine;
        private System.Windows.Forms.PictureBox pictureBoxTaskImage;
        private System.Windows.Forms.TextBox textBoxTaskImageURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdateTask;
        private System.Windows.Forms.Label labelDeadLine;
        private System.Windows.Forms.RichTextBox textBoxTaskLongDescription;
        private System.Windows.Forms.RichTextBox textBoxTaskShortDescription;
        private System.Windows.Forms.Label labelTaskImage;
        private System.Windows.Forms.Label labelTaskDetailedDescription;
        private System.Windows.Forms.Label labelTaskShortDescription;
        private System.Windows.Forms.Label labelTaskTitle;
        private System.Windows.Forms.TextBox textBoxTaskTitle;
        private System.Windows.Forms.Button buttonCancel;
    }
}