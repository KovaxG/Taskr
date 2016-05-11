namespace Taskr_UI_0_1
{
    partial class UploadFiles
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
            this.labelDetailsUploadFiles = new System.Windows.Forms.Label();
            this.richTextBoxDetailsUploadFiles = new System.Windows.Forms.RichTextBox();
            this.buttonBackUploadFiles = new System.Windows.Forms.Button();
            this.buttonSubmitUploadFiles = new System.Windows.Forms.Button();
            this.textBoxLinkUploadFiles = new System.Windows.Forms.TextBox();
            this.labelLinkUploadFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDetailsUploadFiles
            // 
            this.labelDetailsUploadFiles.AutoSize = true;
            this.labelDetailsUploadFiles.Location = new System.Drawing.Point(34, 106);
            this.labelDetailsUploadFiles.Name = "labelDetailsUploadFiles";
            this.labelDetailsUploadFiles.Size = new System.Drawing.Size(331, 24);
            this.labelDetailsUploadFiles.TabIndex = 1;
            this.labelDetailsUploadFiles.Text = "Specify additional necesary details\r\n";
            // 
            // richTextBoxDetailsUploadFiles
            // 
            this.richTextBoxDetailsUploadFiles.Location = new System.Drawing.Point(12, 144);
            this.richTextBoxDetailsUploadFiles.Name = "richTextBoxDetailsUploadFiles";
            this.richTextBoxDetailsUploadFiles.Size = new System.Drawing.Size(381, 207);
            this.richTextBoxDetailsUploadFiles.TabIndex = 2;
            this.richTextBoxDetailsUploadFiles.Text = "";
            // 
            // buttonBackUploadFiles
            // 
            this.buttonBackUploadFiles.Location = new System.Drawing.Point(12, 357);
            this.buttonBackUploadFiles.Name = "buttonBackUploadFiles";
            this.buttonBackUploadFiles.Size = new System.Drawing.Size(111, 50);
            this.buttonBackUploadFiles.TabIndex = 3;
            this.buttonBackUploadFiles.Text = "Back";
            this.buttonBackUploadFiles.UseVisualStyleBackColor = true;
            this.buttonBackUploadFiles.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSubmitUploadFiles
            // 
            this.buttonSubmitUploadFiles.Location = new System.Drawing.Point(292, 357);
            this.buttonSubmitUploadFiles.Name = "buttonSubmitUploadFiles";
            this.buttonSubmitUploadFiles.Size = new System.Drawing.Size(101, 50);
            this.buttonSubmitUploadFiles.TabIndex = 4;
            this.buttonSubmitUploadFiles.Text = "Submit";
            this.buttonSubmitUploadFiles.UseVisualStyleBackColor = true;
            this.buttonSubmitUploadFiles.Click += new System.EventHandler(this.buttonSubmitUploadFiles_Click);
            // 
            // textBoxLinkUploadFiles
            // 
            this.textBoxLinkUploadFiles.Location = new System.Drawing.Point(12, 52);
            this.textBoxLinkUploadFiles.Name = "textBoxLinkUploadFiles";
            this.textBoxLinkUploadFiles.Size = new System.Drawing.Size(381, 29);
            this.textBoxLinkUploadFiles.TabIndex = 5;
            // 
            // labelLinkUploadFiles
            // 
            this.labelLinkUploadFiles.AutoSize = true;
            this.labelLinkUploadFiles.Location = new System.Drawing.Point(79, 9);
            this.labelLinkUploadFiles.Name = "labelLinkUploadFiles";
            this.labelLinkUploadFiles.Size = new System.Drawing.Size(229, 24);
            this.labelLinkUploadFiles.TabIndex = 6;
            this.labelLinkUploadFiles.Text = "Link to Completed Files";
            // 
            // UploadFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 419);
            this.Controls.Add(this.labelLinkUploadFiles);
            this.Controls.Add(this.textBoxLinkUploadFiles);
            this.Controls.Add(this.buttonSubmitUploadFiles);
            this.Controls.Add(this.buttonBackUploadFiles);
            this.Controls.Add(this.richTextBoxDetailsUploadFiles);
            this.Controls.Add(this.labelDetailsUploadFiles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UploadFiles";
            this.Text = "UploadFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDetailsUploadFiles;
        private System.Windows.Forms.RichTextBox richTextBoxDetailsUploadFiles;
        private System.Windows.Forms.Button buttonBackUploadFiles;
        private System.Windows.Forms.Button buttonSubmitUploadFiles;
        private System.Windows.Forms.TextBox textBoxLinkUploadFiles;
        private System.Windows.Forms.Label labelLinkUploadFiles;
    }
}