using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class EditUserDetails : Form
    {
        private HomePage mainForm = null;
        DatabaseHandler db = new DatabaseHandler();
        int user;
        public EditUserDetails(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as HomePage;
            user = this.mainForm.getUser;
            string URL = db.getAvatarLinkSecretary(user);
            pictureAvatar.ImageLocation = URL;
            textBoxDisplayName.Text = db.getDisplayNameSecretary(user);
            textBoxEmail.Text =db.getEmailSecretary(user);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(user);
            textBoxAvatarURL.Text = db.getAvatarLinkSecretary(user);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(user);
            
        }


        private void pictureAvatar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click_1(object sender, EventArgs e)
        {
            string URL = db.getAvatarLinkSecretary(user);
            pictureAvatar.ImageLocation = URL;
            textBoxDisplayName.Text = db.getDisplayNameSecretary(user);
            textBoxEmail.Text = db.getEmailSecretary(user);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(user);
            textBoxAvatarURL.Text = db.getAvatarLinkSecretary(user);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(user);
            textBoxConfirmPassword.Text = "";
        }

        private void buttonAccept_Click_1(object sender, EventArgs e)
        {
            if (textBoxpassword.Text.Equals(textBoxConfirmPassword.Text))
            {
               string password = textBoxpassword.Text;
               string displayname =  textBoxDisplayName.Text;
               string email = textBoxEmail.Text;
               string phonenumber = textBoxPhoneNumber.Text;
               string avatarurl = textBoxAvatarURL.Text;
               string personalnotes = textBoxPersonalNotes.Text;
               if (textBoxpassword.Text !="")
               {
                   db.updatePasswordSecretary(user, password);
               }
                db.updateDisplayNameSecretary(user,displayname);
                db.updateEmailSecretary(user,email);
                db.updatePhoneNumberSecretary(user,phonenumber);
                db.updateAvatarLinkSecretary(user,avatarurl);
                db.updatePersonalNotesSecretary(user, personalnotes);

                MessageBox.Show("Data updated successfully");
                this.Close();


            }
            else
            {
                MessageBox.Show("The two Passwords do not match");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
