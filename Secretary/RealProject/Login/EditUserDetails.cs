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
        DatabaseHandler db = new DatabaseHandler();
        VerifyText verify_text = new VerifyText();
        int secretary_id;

        // Constructor
        public EditUserDetails(int id)
        {
            InitializeComponent();
            secretary_id = id;
            // Get data from database and set it in the form
            string URL = db.getAvatarLinkSecretary(secretary_id);
            pictureAvatar.ImageLocation = URL;
            textBoxDisplayName.Text = db.getDisplayNameSecretary(secretary_id);
            textBoxEmail.Text =db.getEmailSecretary(secretary_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(secretary_id);
            textBoxAvatarURL.Text = db.getAvatarLinkSecretary(secretary_id);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(secretary_id);
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Get data from database and set it in the form
            string URL = db.getAvatarLinkSecretary(secretary_id);
            pictureAvatar.ImageLocation = URL;
            textBoxDisplayName.Text = db.getDisplayNameSecretary(secretary_id);
            textBoxEmail.Text = db.getEmailSecretary(secretary_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(secretary_id);
            textBoxAvatarURL.Text = db.getAvatarLinkSecretary(secretary_id);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(secretary_id);
            textBoxConfirmPassword.Text = "";
        }

        // Accept button
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string password = textBoxpassword.Text;
            string confirmpassword = textBoxConfirmPassword.Text;
            string displayname =  textBoxDisplayName.Text;
            string email = textBoxEmail.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            string avatarurl = textBoxAvatarURL.Text;
            string personalnotes = textBoxPersonalNotes.Text;
            bool ok = true;
            bool ok_pass = false;

            // Verify password 
            if (password.Equals(confirmpassword) && !verify_text.IsNull(password) && !verify_text.IsNull(confirmpassword))
            {
                labelConfirmPassword.Hide();
                if (verify_text.IsStrongPassword(password))
                {
                    ok_pass = true;
                    labelPassword.Hide();
                }
                else
                {
                    labelPassword.Show();
                    labelPassword.Text = "The password must have 8-15 charcters containing at least" + "\n" + " one lowercase, one uppercase and one digit";
                    labelPassword.ForeColor = System.Drawing.Color.Red;
                    ok_pass = false;
                    ok = false;
                }
            }
            if (!textBoxpassword.Text.Equals(textBoxConfirmPassword.Text))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "The 2 passwords don't match";
                labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                ok_pass = false;
                ok = false;
            }

            // Verify displayname
            if (verify_text.IsInjection(displayname) || !verify_text.HasOnlyLettersNumbersUnderscore(displayname))
            {
                labelDisplayname.Show();
                labelDisplayname.Text = "Please use only letters (a-z A-Z), numbers (0-9) or" + "\n" + " underscore (-) in the DisplayName";
                labelDisplayname.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                if (!db.checkUniqueDisplayNameSecretary(displayname,secretary_id))
                {
                    labelDisplayname.Show();
                    labelDisplayname.Text = "This Displayname is already taken, please type another";
                    labelDisplayname.ForeColor = System.Drawing.Color.Red;
                    ok = false;
                }
                else
                {
                    labelDisplayname.Hide();
                }
            }

            // Verify email
            if (verify_text.IsInjection(email) || !verify_text.IsValidEmail(email))
            {
                labelEmail.Show();
                labelEmail.Text = "Please enter a valid email.";
                labelEmail.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                if (!db.checkUniqueEmailSecretary(email,secretary_id))
                {
                    labelEmail.Show();
                    labelEmail.Text = "This Email is already taken, please type another.";
                    labelEmail.ForeColor = System.Drawing.Color.Red;
                    ok = false;
                }
                else
                {
                    labelEmail.Hide();
                }
            }

            // Verify phonenumber
            if (verify_text.IsInjection(phonenumber) || !verify_text.IsValidPhoneNumber(phonenumber))
            {
                labelPhonenumber.Show();
                labelPhonenumber.Text = "The phonenumber must have exactly 10 digits";
                labelPhonenumber.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelPhonenumber.Hide();
            }

            // Verify URL
            if (verify_text.IsInjection(avatarurl) /*|| !verify_text.IsValidUrl(avatarurl)*/)
            {
                labelAvatar.Show();
                labelAvatar.Text = "The URL is not valid";
                labelAvatar.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelAvatar.Hide();
            }
               
            // Verify notes
            if(verify_text.IsInjection(personalnotes))
            {
                labelNotes.Show();
                labelNotes.Text = "Please don't use SQL injection characters like ' or \\";
                labelNotes.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelNotes.Hide();
            }

            // If all data is correct
            if (ok == true)
            {
                db.updateDisplayNameSecretary(secretary_id, displayname);
                db.updateEmailSecretary(secretary_id, email);
                db.updatePhoneNumberSecretary(secretary_id, phonenumber);
                db.updateAvatarLinkSecretary(secretary_id, avatarurl);
                db.updatePersonalNotesSecretary(secretary_id, personalnotes);
                if(ok_pass == true)
                {
                    string hashed_password = Hash.hash(password, secretary_id, 16);
                    db.updatePasswordSecretary(secretary_id, hashed_password);
                }
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
        }
    }
}
