using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1.GUISubElements
{
    class PanelItemUser : System.Windows.Forms.Panel
    {
        
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.PictureBox pictureTask;
        private System.Windows.Forms.Button buttonMoreInfo;
        protected System.Windows.Forms.Label labelStatus;

        protected int zero = 15;
        protected const int textWidth = 580;

        protected DatabaseHandler d;
        protected ProjectData projectData;
        protected TeamLeader teamLeader;
        protected UserData userData;

        public PanelItemUser(DatabaseHandler d, UserData userData, ProjectData projectData, TeamLeader teamLeader)
        {
            //
            //for resourecs
            //
            this.d = d;
            this.projectData = projectData;
            this.teamLeader = teamLeader;
            this.userData = userData;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeLancer));
            //
            //initialize component classes
            //
            this.pictureTask = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonMoreInfo = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureTask);
            this.Controls.Add(this.buttonMoreInfo);
            this.Controls.Add(this.labelStatus);
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
            /*try
            {
                new Thread(() => pictureTask.Load(this.userData.AvatarURL)).Start(); 
                zero = 150;
            }
            catch
            {
                //this.pictureTask.Image = this.pictureTask.ErrorImage;
                this.pictureTask.Enabled = false;
                this.pictureTask.Visible = false;
                zero = 15;
            }*/
            new Thread(() =>
            {
                try
                {
                    pictureTask.Load(this.userData.AvatarURL);
                    zero = 150;
                }
                catch
                {
                    EnablePicureTask();
                    zero = 15;
                }
                finally
                {
                    FinalizeZeroValue();
                }
            }).Start();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = true;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = this.userData.DisplayName;
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = true;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Text = this.userData.Notes;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.TabIndex = 5;

            //
            //View Details
            //
            this.buttonMoreInfo.Location = new System.Drawing.Point(textWidth + 10, 15);
            this.buttonMoreInfo.Name = "buttonMoreInfo";
            this.buttonMoreInfo.Size = new System.Drawing.Size(120, 35);
            this.buttonMoreInfo.TabIndex = 2;
            this.buttonMoreInfo.Text = "More Info";
            this.buttonMoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoreInfo.UseVisualStyleBackColor = true;
            this.buttonMoreInfo.Click += new System.EventHandler(this.buttonMoreInfo_Click);

            //
            //Label Status
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(textWidth + 15, 100);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 20);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = userData.WorkStatus;

            FinalizeZeroValue();


            this.ResumeLayout();
            this.PerformLayout();
        }

        private delegate void EnablePictureTaskReturnCall();
        private void EnablePicureTask()
        {
            if (pictureTask.InvokeRequired)
            {
                EnablePictureTaskReturnCall enablePictureTask = new EnablePictureTaskReturnCall(EnablePicureTask);
                this.Invoke(enablePictureTask, new object[] { });
            }
            else
            {
                this.pictureTask.Enabled = false;
                this.pictureTask.Visible = false;
            }
        }

        private delegate void FinalizeZeroValueReturnCall();

        private  void FinalizeZeroValue()
        {
            if (textBoxTitle.InvokeRequired || textBoxDescription.InvokeRequired || textBoxTitle.InvokeRequired)
            {
                FinalizeZeroValueReturnCall finalizeZeroValue=new FinalizeZeroValueReturnCall(FinalizeZeroValue);
                this.Invoke(finalizeZeroValue, new object[] { });
            }
            else
            {
                this.textBoxTitle.Location = new System.Drawing.Point(zero, 14);

                this.textBoxDescription.Size = new System.Drawing.Size(textWidth - zero, 87);
                this.textBoxDescription.Location = new System.Drawing.Point(zero, 55);

                this.textBoxTitle.Size = new System.Drawing.Size(textWidth - zero, 34);


            }
        
        }


        private void buttonMoreInfo_Click(object sender, EventArgs e)
        {
            EditUserData editor=new EditUserData(d,userData,teamLeader,projectData);
            editor.Show();
        }




    }
}
