using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;


namespace Taskr_UI_0_1
{
    class PanelItemProjectSuggestions : System.Windows.Forms.Panel
    {
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonAdoptProject;
        private System.Windows.Forms.PictureBox pictureProject;
        private DatabaseHandler d;

        private ProjectSuggestionData psd;
        private UserAppS us;
        

        public PanelItemProjectSuggestions(ProjectSuggestionData psd,DatabaseHandler d, UserAppS us)
        {
            this.us = us;
            this.psd = psd;
            this.d = d;
            //
            //for resourecs
            //
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAppS));
            //
            //initialize component classes
            //
            this.pictureProject = new System.Windows.Forms.PictureBox();
            this.buttonAdoptProject = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // panel
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonAdoptProject);
            this.Controls.Add(this.pictureProject);
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "panel";
            this.Size = new System.Drawing.Size(722, 157);
            this.TabIndex = 1;
            // 
            // pictureProject
            // 

            this.pictureProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProject.ErrorImage = ((System.Drawing.Image)(resources.GetObject("X.png")));
            this.pictureProject.Location = new System.Drawing.Point(15, 14);
            this.pictureProject.Name = "pictureProject";
            this.pictureProject.Size = new System.Drawing.Size(128, 128);
            this.pictureProject.TabIndex = 0;
            this.pictureProject.TabStop = false;
            try
            {
                this.pictureProject.Load(psd.imageURL);
            }
            catch
            {
                this.pictureProject.Image = this.pictureProject.ErrorImage;
            }
            // 
            // buttonJoinProjects
            // 
            this.buttonAdoptProject.Location = new System.Drawing.Point(613, 63);
            this.buttonAdoptProject.Name = "buttonAdoptProject";
            this.buttonAdoptProject.Size = new System.Drawing.Size(95, 70);
            this.buttonAdoptProject.TabIndex = 1;
            this.buttonAdoptProject.Text = "Adopt Project";
            this.buttonAdoptProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdoptProject.UseVisualStyleBackColor = true;
            this.buttonAdoptProject.Click += new System.EventHandler(buttonAdoptProject_Click);

            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(149, 14);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Text = psd.Title;
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
            this.textBoxDescription.Text = psd.ShortDescription;
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(457, 87);
            this.textBoxDescription.TabIndex = 5;

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void buttonAdoptProject_Click(object sender, EventArgs e)
        {
            var err = d.AdoptProjectSuggestion(psd);
            if (err != null)
            {
                MessageBox.Show("Project Successfully Adopted");
                us.reInitializeContents();
            }
            /*switch (err)
            {
                case 0:
                    MessageBox.Show("Project Successfully Adopted");
                    us.reInitializeContents();
                    break;
                default:
                    MessageBox.Show("Please try restarting the application. \nIf the error persists, please contact the support team",
                        "Unlabeled error " + err);
                    break;
            }*/
        }
        override public string ToString()
        {
            return textBoxTitle.Text;
        }
    }
}

