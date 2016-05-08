using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using Taskr_UI_0_1.SubGuiWindows;

namespace Taskr_UI_0_1
{
    public partial class EditUserData : Form
    {
        string tempURI;
        private DatabaseHandler dh;
        private UserData userData;
        private TeamLeader teamLeader;
        private ProjectData projectData;

        public EditUserData(DatabaseHandler d)
        {
            InitializeComponent();
            dh = d;
            userData = d.User;

            tempURI = userData.AvatarURL;
            try
            {
                pictureAvatar.Load(tempURI);
            }
            catch (FileNotFoundException)
            {
                pictureAvatar.Image=global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
            textBoxDisplayName.Text = userData.DisplayName;
            textBoxEmail.Text = userData.Email;
            textBoxPhoneNumber.Text = userData.PhoneNumber;
            textBoxPersonalNotes.Text = userData.Notes;
            
        }

        /// <summary>
        /// This is meant to be used from the teamleader to assign tasks
        /// </summary>
        /// <param name="d"></param>
        /// <param name="userData">This doesn't allow modification of one's details</param>
        public EditUserData(DatabaseHandler d,UserData userData, TeamLeader teamLeader, ProjectData projectData)
        {
            this.Text = userData.DisplayName + "Details";
            this.userData = userData;
            this.teamLeader = teamLeader;
            this.projectData = projectData;

            InitializeComponent();
            dh = d;
            tempURI = userData.AvatarURL;
            try
            {
                pictureAvatar.Load(tempURI);
            }
            catch (FileNotFoundException)
            {
                pictureAvatar.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
            textBoxDisplayName.Text = userData.DisplayName;
            textBoxEmail.Text = userData.Email;
            textBoxPhoneNumber.Text = userData.PhoneNumber;
            textBoxPersonalNotes.Text = userData.Notes;
            DisableEditing();
            EnableTaskAssignment();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
               
                tempURI = openFileDialog1.FileName;
                pictureAvatar.Load(tempURI);
            }

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxpassword.Text.Equals(textBoxConfirmPassword.Text))
            {
                userData.Password = textBoxpassword.Text;
                MessageBox.Show("Change Successful");
                userData.DisplayName = textBoxDisplayName.Text;
                userData.Email = textBoxEmail.Text;
                userData.PhoneNumber = textBoxPhoneNumber.Text;
                userData.Notes = textBoxPersonalNotes.Text;
                userData.AvatarURL = tempURI;

                if (dh.UpdateThisUser())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update Failed. Please check your connection and try again");
                }

            }
            else
            {
                MessageBox.Show("The two Passwords do not match");
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tempURI = userData.AvatarURL;
            pictureAvatar.Load(tempURI);
            textBoxDisplayName.Text = userData.DisplayName;
            textBoxEmail.Text = userData.Email;
            textBoxPhoneNumber.Text = userData.PhoneNumber;
            textBoxPersonalNotes.Text = userData.Notes;
            textBoxpassword.Text = "";
            textBoxConfirmPassword.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void DisableEditing()
        {
            buttonUpload.Visible = false;
            buttonUpload.Enabled = false;
            textBoxDisplayName.ReadOnly = true;
            textBoxEmail.ReadOnly = true;
            textBoxPersonalNotes.ReadOnly = true;
            textBoxPhoneNumber.ReadOnly = true;
            textBoxPersonalNotes.ReadOnly = true;

            buttonAccept.Visible = false;
            buttonAccept.Enabled = false;
            buttonReset.Visible = false;
            buttonReset.Enabled = false;

            textBoxpassword.Enabled = false;
            textBoxpassword.Visible = false;
            textBoxConfirmPassword.Visible = false;
            textBoxConfirmPassword.Enabled = false;
            labelConfirmPassword.Visible = false;
            labelPassword.Visible = false;
        }

        public void EnableTaskAssignment()
        {
            buttonAsignTask.Visible = true;
            buttonAsignTask.Enabled = true;
            buttonKick.Visible = true;
            buttonKick.Enabled = true;

        }

        private void buttonAsignTask_Click(object sender, EventArgs e)
        {
            AsignTaskWindows asignTaskWindows=new AsignTaskWindows(dh,teamLeader,projectData,userData);
            if (asignTaskWindows.ShowDialog()== DialogResult.OK)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            /*int activeProject = userData.ActiveProject;
            userData.ActiveProject = 0;

            if (dh.Kick(userData))
            {
                MessageBox.Show("User Succesfully removed from project", "Kick succesful");
            }
            else
            {
                MessageBox.Show("Could not kick " + userData.DisplayName, "Kick Failed");
                userData.ActiveProject = activeProject;
            }*/
        }
    }
}
