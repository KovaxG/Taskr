﻿namespace Taskr_UI_0_1.SubGuiWindows
{
    partial class AsignTaskWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignTaskWindows));
            this.flowLayoutPanelTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelTasks
            // 
            this.flowLayoutPanelTasks.AutoScroll = true;
            this.flowLayoutPanelTasks.AutoSize = true;
            this.flowLayoutPanelTasks.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTasks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTasks.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            this.flowLayoutPanelTasks.Size = new System.Drawing.Size(844, 630);
            this.flowLayoutPanelTasks.TabIndex = 1;
            this.flowLayoutPanelTasks.WrapContents = false;
            // 
            // AsignTaskWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 630);
            this.Controls.Add(this.flowLayoutPanelTasks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsignTaskWindows";
            this.Text = "Task Assigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTasks;
    }
}