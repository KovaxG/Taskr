namespace Taskr_UI_0_1
{
    partial class ExtendTask
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
            this.richTextBoxReasonExtension = new System.Windows.Forms.RichTextBox();
            this.labelReasonForExtension = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelForExtension = new System.Windows.Forms.Label();
            this.dateTimePickerExtension = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // richTextBoxReasonExtension
            // 
            this.richTextBoxReasonExtension.Location = new System.Drawing.Point(18, 103);
            this.richTextBoxReasonExtension.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxReasonExtension.Name = "richTextBoxReasonExtension";
            this.richTextBoxReasonExtension.Size = new System.Drawing.Size(460, 194);
            this.richTextBoxReasonExtension.TabIndex = 0;
            this.richTextBoxReasonExtension.Text = "";
            // 
            // labelReasonForExtension
            // 
            this.labelReasonForExtension.AutoSize = true;
            this.labelReasonForExtension.Location = new System.Drawing.Point(131, 53);
            this.labelReasonForExtension.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReasonForExtension.Name = "labelReasonForExtension";
            this.labelReasonForExtension.Size = new System.Drawing.Size(208, 24);
            this.labelReasonForExtension.TabIndex = 1;
            this.labelReasonForExtension.Text = "Reason for extension";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(67, 508);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(93, 42);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(328, 508);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(90, 42);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelForExtension
            // 
            this.labelForExtension.AutoSize = true;
            this.labelForExtension.Location = new System.Drawing.Point(47, 354);
            this.labelForExtension.Name = "labelForExtension";
            this.labelForExtension.Size = new System.Drawing.Size(123, 24);
            this.labelForExtension.TabIndex = 4;
            this.labelForExtension.Text = "Extend Until";
            // 
            // dateTimePickerExtension
            // 
            this.dateTimePickerExtension.Location = new System.Drawing.Point(185, 348);
            this.dateTimePickerExtension.Name = "dateTimePickerExtension";
            this.dateTimePickerExtension.Size = new System.Drawing.Size(285, 29);
            this.dateTimePickerExtension.TabIndex = 5;
            // 
            // ExtendTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 565);
            this.Controls.Add(this.dateTimePickerExtension);
            this.Controls.Add(this.labelForExtension);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelReasonForExtension);
            this.Controls.Add(this.richTextBoxReasonExtension);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ExtendTask";
            this.Text = "ExtendTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxReasonExtension;
        private System.Windows.Forms.Label labelReasonForExtension;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelForExtension;
        private System.Windows.Forms.DateTimePicker dateTimePickerExtension;
    }
}