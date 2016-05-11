namespace Taskr_UI_0_1
{
    partial class DropTask
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
            this.labelWarningDropTask = new System.Windows.Forms.Label();
            this.labelReasonDropTask = new System.Windows.Forms.Label();
            this.richTextBoxReasonDropTask = new System.Windows.Forms.RichTextBox();
            this.buttonBackDropTask = new System.Windows.Forms.Button();
            this.buttonSubmitDropTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWarningDropTask
            // 
            this.labelWarningDropTask.AutoSize = true;
            this.labelWarningDropTask.BackColor = System.Drawing.SystemColors.Info;
            this.labelWarningDropTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWarningDropTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarningDropTask.Location = new System.Drawing.Point(12, 38);
            this.labelWarningDropTask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWarningDropTask.Name = "labelWarningDropTask";
            this.labelWarningDropTask.Size = new System.Drawing.Size(446, 50);
            this.labelWarningDropTask.TabIndex = 0;
            this.labelWarningDropTask.Text = "Warning! By dropping a task you may incure a \r\npenalty at the discetion of the te" +
    "am leader!";
            // 
            // labelReasonDropTask
            // 
            this.labelReasonDropTask.AutoSize = true;
            this.labelReasonDropTask.Location = new System.Drawing.Point(197, 121);
            this.labelReasonDropTask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReasonDropTask.Name = "labelReasonDropTask";
            this.labelReasonDropTask.Size = new System.Drawing.Size(81, 24);
            this.labelReasonDropTask.TabIndex = 1;
            this.labelReasonDropTask.Text = "Reason";
            // 
            // richTextBoxReasonDropTask
            // 
            this.richTextBoxReasonDropTask.Location = new System.Drawing.Point(12, 160);
            this.richTextBoxReasonDropTask.Name = "richTextBoxReasonDropTask";
            this.richTextBoxReasonDropTask.Size = new System.Drawing.Size(446, 169);
            this.richTextBoxReasonDropTask.TabIndex = 2;
            this.richTextBoxReasonDropTask.Text = "";
            // 
            // buttonBackDropTask
            // 
            this.buttonBackDropTask.Location = new System.Drawing.Point(43, 365);
            this.buttonBackDropTask.Name = "buttonBackDropTask";
            this.buttonBackDropTask.Size = new System.Drawing.Size(97, 46);
            this.buttonBackDropTask.TabIndex = 3;
            this.buttonBackDropTask.Text = "Back";
            this.buttonBackDropTask.UseVisualStyleBackColor = true;
            this.buttonBackDropTask.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSubmitDropTask
            // 
            this.buttonSubmitDropTask.Location = new System.Drawing.Point(319, 365);
            this.buttonSubmitDropTask.Name = "buttonSubmitDropTask";
            this.buttonSubmitDropTask.Size = new System.Drawing.Size(102, 46);
            this.buttonSubmitDropTask.TabIndex = 4;
            this.buttonSubmitDropTask.Text = "Submit";
            this.buttonSubmitDropTask.UseVisualStyleBackColor = true;
            this.buttonSubmitDropTask.Click += new System.EventHandler(this.buttonSubmitDropTask_Click);
            // 
            // DropTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 441);
            this.Controls.Add(this.buttonSubmitDropTask);
            this.Controls.Add(this.buttonBackDropTask);
            this.Controls.Add(this.richTextBoxReasonDropTask);
            this.Controls.Add(this.labelReasonDropTask);
            this.Controls.Add(this.labelWarningDropTask);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DropTask";
            this.Text = "DropTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWarningDropTask;
        private System.Windows.Forms.Label labelReasonDropTask;
        private System.Windows.Forms.RichTextBox richTextBoxReasonDropTask;
        private System.Windows.Forms.Button buttonBackDropTask;
        private System.Windows.Forms.Button buttonSubmitDropTask;
    }
}