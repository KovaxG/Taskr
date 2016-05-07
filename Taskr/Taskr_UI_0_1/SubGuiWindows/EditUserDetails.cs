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

namespace Taskr_UI_0_1
{
    public partial class EditUserData : Form
    {
                   //UserData ud;
        string tempURI;
        private DatabaseHandler dh;
        public EditUserData(DatabaseHandler d)
        {
            InitializeComponent();
            dh = d;
            tempURI = dh.User.AvatarURL;
            try
            {
                pictureAvatar.Load(tempURI);
            }
            catch (FileNotFoundException)
            {
                pictureAvatar.Image=global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
            textBoxDisplayName.Text = dh.User.DisplayName;
            textBoxEmail.Text = dh.User.Email;
            textBoxPhoneNumber.Text = dh.User.PhoneNumber;
            textBoxPersonalNotes.Text = dh.User.Notes;
        }

        private void button1_Click(object sender, EventArgs e)
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
                dh.User.Password = textBoxpassword.Text;
                MessageBox.Show("Change Successful");
                dh.User.DisplayName = textBoxDisplayName.Text;
                dh.User.Email = textBoxEmail.Text;
                dh.User.PhoneNumber = textBoxPhoneNumber.Text;
                dh.User.Notes = textBoxPersonalNotes.Text;
                dh.User.AvatarURL = tempURI;

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
            tempURI = dh.User.AvatarURL;
            pictureAvatar.Load(tempURI);
            textBoxDisplayName.Text = dh.User.DisplayName;
            textBoxEmail.Text = dh.User.Email;
            textBoxPhoneNumber.Text = dh.User.PhoneNumber;
            textBoxPersonalNotes.Text = dh.User.Notes;
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
    }
}
