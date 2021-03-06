﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient.Properties;

namespace Taskr_UI_0_1
{
    public partial class FreeLancer : Form
    {
        DatabaseHandler d;

        public FreeLancer(DatabaseHandler d)
        {
            this.d = d;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Avatar area
            loadAvatarArea();

            //other areas
            reInitializeContents();
        }
        private void loadAvatarArea()
        {
            try
            {
                pictureAvatar.Load(d.User.AvatarURL);
            }
            // (FileNotFoundException) or any other exception may occur, the
            // X image is loaded as a replacement
            catch
            {
                pictureAvatar.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
            labelUsername.Size = new System.Drawing.Size(pictureAvatar.Size.Width, 16);
            labelUsername.Text = d.User.DisplayName; //does not change size in current Build

        }

        /// <summary>
        ///  Initializes all graphical components
        /// </summary>
        public void reInitializeContents()
        {
            disposeElements();

            //Based on which result is return from Getmode, it launches the appropriate window
            //If freelancer is returned, this window is kept open, otherwise it's closed
            switch (d.GetMode())
            {
                case ("freelancer"):
                    //populates the Active Task List
                    List<ProjectData> pdl = d.GetActiveProjectsList();
                    PanelItemActiveProjects ppi;
                    pdl = null;
                    if (pdl != null)
                    {
                        foreach (ProjectData pd in pdl)
                        {
                            ppi = new PanelItemActiveProjects(pd, d, this);
                            this.flowLayoutPanelActiveProjects.Controls.Add(ppi);
                        }
                    }

                    //populates the Project Suggestion List
                    List<ProjectSuggestionData> psdl = d.GetProjectSuggestionsList();
                    PanelItemProjectSuggestions pips;
                    if (psdl != null)
                    {
                        foreach (ProjectSuggestionData psd in psdl)
                        {
                            pips = new PanelItemProjectSuggestions(psd, d, this);
                            this.flowLayoutPanelProjectSuggestions.Controls.Add(pips);
                        }
                    }

                    break;

                 //switches to teammember window
                case ("teammember"):
                    this.Close();
                    this.Dispose();
                    TeamMember td = new TeamMember(d);
                    td.ShowDialog();
                    break;

                 //switches to teamleader window
                case ("teamleader"):
                    TeamLeader tl = new TeamLeader(d);

                    this.Close();
                    this.Dispose();
                    tl.ShowDialog();
                    break;
            }
        }

        /// <summary>
        /// removes references to graphical elements
        /// </summary>
        private void disposeElements()
        {
            foreach (System.Windows.Forms.Control cc in this.flowLayoutPanelActiveProjects.Controls)
            {
                cc.Dispose();
            }
            this.flowLayoutPanelActiveProjects.Controls.Clear();

            foreach (System.Windows.Forms.Control cc in this.flowLayoutPanelProjectSuggestions.Controls)
            {
                cc.Dispose();
            }
            this.flowLayoutPanelProjectSuggestions.Controls.Clear();

            //this slows down the application. Should only be used when testing for memory leaks
            /*GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();*/
        }

        /// <summary>
        /// opens the interface to edit the user's data
        /// </summary>
        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            EditUserData eu = new EditUserData(d);

            //updating user details is done inside the eu form
            if (eu.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Your details have been successfully changed");
                loadAvatarArea();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //this is only aplicalbe if there is a server side app
            //d.logOut();
            this.Close();
            this.Dispose();
        }

        /*--removed in favor of image URL. This will be reused if server side app is created
        private void ChangeProjectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProjectImage.Load(openFileDialog1.FileName);
            }
        }*/


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ButtonCreateProject_Click(object sender, EventArgs e)
        {
            if (this.TextBoxProjectTitle.Text.Equals(""))
            {
                MessageBox.Show("Title field is compulsory!", "Empty Field");
                return;
            }
            if (this.TextBoxProjectShortDetails.Text.Length < 20)
            {
                MessageBox.Show("The short description needs to be at least 20 characters long!",
                    "Description too short");
                return;
            }
            ProjectData projectData = new ProjectData(d.User.ID);
            projectData.Title = this.TextBoxProjectTitle.Text;
            projectData.ShortDescription = this.TextBoxProjectShortDetails.Text;
            projectData.DetailedDescription = this.TextBoxProjectLongDetails.Text;
            projectData.LogURL = this.textBoxModificationLog.Text;
            projectData.ImageURL = this.textBoxImageURL.Text;
            projectData.AvailibleFunds = this.labelAvailableFunds.Text;
            projectData.CurrentYield = this.textBoxCurrentYield.Text;


            if (d.InsertNewProject(projectData))
            {
                MessageBox.Show("New Project Successfully Created.\nYou are now its team leader", "Success!");
                reInitializeContents();
            }
            else
            {
                MessageBox.Show("Please try clicking the refresh button or\n restarting the application",
                    "Could not create Project.");
            }
        }

        /// <summary>
        /// Updates image in the apropriate box when focus of textbox is lost
        /// </summary>
        private void textBoxImageURL_LostFocus(object sender, EventArgs e)
        {

            new Thread(() =>
            {
                try
                {
                    this.pictureBoxProjectImage.Load(textBoxImageURL.Text);
                }
                catch
                {
                    this.pictureBoxProjectImage.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
                }
            }).Start();
        }

        /// <summary>
        /// Refreshes current perspective
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            reInitializeContents();
        }
    }
}
