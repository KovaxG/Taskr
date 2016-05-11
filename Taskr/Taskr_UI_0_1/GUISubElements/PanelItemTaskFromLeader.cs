using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1
{
    class PanelItemTasksFromLeader : Panel
    {
        protected System.Windows.Forms.TextBox textBoxDescription;
        protected System.Windows.Forms.TextBox textBoxTitle;
        protected System.Windows.Forms.PictureBox pictureTask;

        protected int zero = 15;
        protected const int textWidth = 580;

        protected DatabaseHandler d;
        protected TaskData taskData;
        protected TeamLeader teamLeader;

        public PanelItemTasksFromLeader(DatabaseHandler d, TaskData taskData, TeamLeader teamLeader)
        {
            
            this.d = d;
            this.taskData = taskData;
            this.teamLeader = teamLeader;
            InitializeComponents();
        }


        protected void InitializeComponents()
        {
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
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
            this.Size = new System.Drawing.Size(720, 157);
            this.TabIndex = 1;
            // 
            // pictureTask
            // 

            this.pictureTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTask.ErrorImage = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.pictureTask.Location = new System.Drawing.Point(15, 14);
            this.pictureTask.Name = "pictureTask";
            this.pictureTask.Size = new System.Drawing.Size(128, 128);
            this.pictureTask.TabIndex = 0;
            this.pictureTask.TabStop = false;

            new Thread(() =>
            {
                try
                {
                    this.pictureTask.Load(taskData.ImageURL);
                    zero = 150;
                }
                catch
                {
                    this.pictureTask.Enabled = false;
                    this.pictureTask.Visible = false;
                    zero = 15;
                }
                finally
                {
                    SetFinalSize();

                }
            }).Start();

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = true;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = taskData.Title;
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = true;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = taskData.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.TabIndex = 5;

            SetFinalSize();

            this.ResumeLayout();
            this.PerformLayout();
        }
        delegate void SetFinalSizeCallback();
        private void SetFinalSize()
        {
            if (this.textBoxTitle.InvokeRequired || this.textBoxDescription.InvokeRequired)
            {
                SetFinalSizeCallback d = new SetFinalSizeCallback(SetFinalSize);
                this.Invoke(d, new object[] { });
            }
            else
            {

                this.textBoxTitle.Size = new System.Drawing.Size(textWidth - zero, 34);
                this.textBoxTitle.Location = new System.Drawing.Point(zero, 14);

                this.textBoxDescription.Location = new System.Drawing.Point(zero, 55);
                this.textBoxDescription.Size = new System.Drawing.Size(textWidth - zero, 87);
                
            }

        }
        

    }
}
