using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    class PanelItemTasks : Panel
    {
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.PictureBox pictureTask;

        public PanelItemTasks( TaskData td)
        {
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAppS));
            //
            //initialize component classes
            //
            this.pictureTask = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureTask);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "panel";
            this.Size = new System.Drawing.Size(620, 157);
            this.TabIndex = 1;
            // 
            // pictureTask
            // 

            this.pictureTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTask.ErrorImage = ((System.Drawing.Image)(resources.GetObject("X.png")));
            this.pictureTask.Location = new System.Drawing.Point(15, 14);
            this.pictureTask.Name = "pictureTask";
            this.pictureTask.Size = new System.Drawing.Size(128, 128);
            this.pictureTask.TabIndex = 0;
            this.pictureTask.TabStop = false;
            try {
                this.pictureTask.Load(td.imageURL);
            }
            catch
            {
                this.pictureTask.Image = this.pictureTask.ErrorImage;
            }

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(149, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = td.Title;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(319, 34);
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(150, 55);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = td.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(457, 87);
            this.textBoxDescription.TabIndex = 5;

            this.ResumeLayout();
            this.PerformLayout();
        }



    }
}
