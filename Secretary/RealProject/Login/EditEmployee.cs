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
    public partial class EditEmployee : Form
    {
        int employee_id;
        VerifyText verify_text = new VerifyText();
        DatabaseHandler db = new DatabaseHandler();

        // Constructor
        public EditEmployee(int id)
        {
            employee_id = id;
            InitializeComponent();
            textBoxId.Text = employee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(employee_id);
            textBoxLastName.Text = db.getLastNameUser(employee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(employee_id);
            setAvatarImage();
            textBoxEmail.Text = db.getEmailUser(employee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(employee_id);
            dateTimePicker.Value = db.getJoinDateUser(employee_id);
            textBoxAddedBy.Text = db.getDisplayNameSecretary(Int32.Parse(db.getAddedByUser(employee_id))).ToString();
            textBoxActiveProject.Text = db.getActiveProjectUser(employee_id).ToString();
            setStatus();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(employee_id);
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = employee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(employee_id);
            textBoxLastName.Text = db.getLastNameUser(employee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(employee_id);
            setAvatarImage();
            textBoxEmail.Text = db.getEmailUser(employee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(employee_id);
            dateTimePicker.Value = db.getJoinDateUser(employee_id);
            textBoxAddedBy.Text = db.getDisplayNameSecretary(Int32.Parse(db.getAddedByUser(employee_id))).ToString();
            textBoxActiveProject.Text = db.getActiveProjectUser(employee_id).ToString();
            setStatus();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(employee_id);
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Accept button
        private void buttonAccept_Click(object sender, EventArgs e)
        {  
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string displayname = textBoxDisplayName.Text;
            string password = textBoxPassword.Text;
            string confirmpassword = textBoxConfirmPassword.Text;
            string email = textBoxEmail.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            DateTime joindate = dateTimePicker.Value.Date;
            string personalnotes = textBoxPersonalNotes.Text;
            bool ok = true;
            bool ok_pass = false;

            // Verify firstname
            if (verify_text.IsInjection(firstname) || !verify_text.HasOnlyLetters(firstname))
            {
                labelFirstname.Show();
                labelFirstname.Text = "Please use only letters (a-z A-Z) in the Firstname";
                labelFirstname.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelFirstname.Hide();
            }

            // Verify lastname
            if (verify_text.IsInjection(lastname) || !verify_text.HasOnlyLetters(lastname))
            {
                labelLastname.Show();
                labelLastname.Text = "Please use only letters (a-z A-Z) in the Lastname";
                labelLastname.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelLastname.Hide();
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
                if (!db.checkUniqueDisplayNameUser(displayname,employee_id))
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
                if (!db.checkUniqueEmailUser(email,employee_id))
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

            // Verify password 
            if (password.Equals(confirmpassword) && !verify_text.IsNull(password) && !verify_text.IsNull(confirmpassword))
            {
                labelConfirmPassword.Hide();
                if (verify_text.IsStrongPassword(password))
                {
                    ok_pass = true;
                    labelConfirmPassword.Hide();
                }
                else
                {
                    labelConfirmPassword.Show();
                    labelConfirmPassword.Text = "The password must have 8-15 charcters containing at least" + "\n" + " one lowercase, one uppercase and one digit";
                    labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                    ok_pass = false;
                    ok = false;
                }
            }
            if (!password.Equals(confirmpassword))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "The 2 passwords don't match";
                labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                ok_pass = false;
                ok = false;
            }

            // // Verify phonenumber
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

            // Verify notes
            if (verify_text.IsInjection(personalnotes))
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
                db.updateFirstNameUser(employee_id, firstname);
                db.updateLastNameUser(employee_id, lastname);
                db.updateDisplayNameUser(employee_id, displayname);
                string s;
                s = comboBoxStatus.SelectedItem.ToString();
                db.updateStatusUser(employee_id, s);
                if (ok_pass == true)
                {
                    string hashed_password = Hash.hash(password, employee_id, 16);
                    db.updatePasswordUser(employee_id, hashed_password);
                }
                db.updateEmailUser(employee_id, email);
                db.updatePhoneNumberUser(employee_id, phonenumber);
                db.updateJoinDateUser(employee_id, joindate);
                db.updatePersonalNotesUser(employee_id, personalnotes);
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
        }

        /* <---------------------------------------- SOME SET METHODS ----------------------------------------> */
        // Set avatar image
        private void setAvatarImage()
        {
            // Get and set photo
            pictureAvatar.ImageLocation = db.getAvatarLinkUser(employee_id).ToString();
        }

        // Set status
        private void setStatus()
        {
            // Get and set status
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("Available");
            comboBoxStatus.Items.Add("Working");
            comboBoxStatus.Items.Add("Day off");
            comboBoxStatus.Items.Add("Holiday");
            comboBoxStatus.Items.Add("Sick");
            comboBoxStatus.Items.Add("Not Available");
            comboBoxStatus.Text = db.getStatusUser(employee_id);
        }
    }
}
