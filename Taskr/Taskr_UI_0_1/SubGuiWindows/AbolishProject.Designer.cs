namespace Taskr_UI_0_1.SubGuiWindows
{
    partial class AbolishProject
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
            this.labelTitleAbolish = new System.Windows.Forms.Label();
            this.labelThisWillRemove = new System.Windows.Forms.Label();
            this.labelCannotUndo = new System.Windows.Forms.Label();
            this.labelReason = new System.Windows.Forms.Label();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.buttonAbolish = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProjectTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitleAbolish
            // 
            this.labelTitleAbolish.AutoSize = true;
            this.labelTitleAbolish.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAbolish.Location = new System.Drawing.Point(31, 26);
            this.labelTitleAbolish.Name = "labelTitleAbolish";
            this.labelTitleAbolish.Size = new System.Drawing.Size(499, 32);
            this.labelTitleAbolish.TabIndex = 0;
            this.labelTitleAbolish.Text = "You are about to abolish the project";
            // 
            // labelThisWillRemove
            // 
            this.labelThisWillRemove.AutoSize = true;
            this.labelThisWillRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThisWillRemove.Location = new System.Drawing.Point(32, 150);
            this.labelThisWillRemove.Name = "labelThisWillRemove";
            this.labelThisWillRemove.Size = new System.Drawing.Size(501, 29);
            this.labelThisWillRemove.TabIndex = 1;
            this.labelThisWillRemove.Text = "This will remove all members from the project";
            // 
            // labelCannotUndo
            // 
            this.labelCannotUndo.AutoSize = true;
            this.labelCannotUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCannotUndo.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCannotUndo.Location = new System.Drawing.Point(125, 197);
            this.labelCannotUndo.Name = "labelCannotUndo";
            this.labelCannotUndo.Size = new System.Drawing.Size(286, 29);
            this.labelCannotUndo.TabIndex = 2;
            this.labelCannotUndo.Text = "This cannot be undone!";
            // 
            // labelReason
            // 
            this.labelReason.AutoSize = true;
            this.labelReason.Location = new System.Drawing.Point(26, 291);
            this.labelReason.Name = "labelReason";
            this.labelReason.Size = new System.Drawing.Size(150, 17);
            this.labelReason.TabIndex = 3;
            this.labelReason.Text = "Please state a reason:";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Location = new System.Drawing.Point(29, 311);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(501, 112);
            this.textBoxReason.TabIndex = 4;
            // 
            // buttonAbolish
            // 
            this.buttonAbolish.Location = new System.Drawing.Point(29, 434);
            this.buttonAbolish.Name = "buttonAbolish";
            this.buttonAbolish.Size = new System.Drawing.Size(201, 62);
            this.buttonAbolish.TabIndex = 5;
            this.buttonAbolish.Text = "Abolish";
            this.buttonAbolish.UseVisualStyleBackColor = true;
            this.buttonAbolish.Click += new System.EventHandler(this.buttonAbolish_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(348, 434);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 62);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelProjectTitle
            // 
            this.labelProjectTitle.AutoSize = true;
            this.labelProjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectTitle.Location = new System.Drawing.Point(225, 83);
            this.labelProjectTitle.Name = "labelProjectTitle";
            this.labelProjectTitle.Size = new System.Drawing.Size(100, 32);
            this.labelProjectTitle.TabIndex = 8;
            this.labelProjectTitle.Text = "<title>";
            // 
            // AbolishProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 519);
            this.Controls.Add(this.labelProjectTitle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAbolish);
            this.Controls.Add(this.textBoxReason);
            this.Controls.Add(this.labelReason);
            this.Controls.Add(this.labelCannotUndo);
            this.Controls.Add(this.labelThisWillRemove);
            this.Controls.Add(this.labelTitleAbolish);
            this.Name = "AbolishProject";
            this.Text = "Abolish Project <title>";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleAbolish;
        private System.Windows.Forms.Label labelThisWillRemove;
        private System.Windows.Forms.Label labelCannotUndo;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Button buttonAbolish;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProjectTitle;
    }
}