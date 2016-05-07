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
    public partial class EditFormerEmployee : Form
    {
        int formermployee_id;
        DatabaseHandler db = new DatabaseHandler();
        VerifyText verify_text = new VerifyText();

        // Constructor
        public EditFormerEmployee(int id)
        {
            InitializeComponent();
            formermployee_id = id;
            setAvatarImage();
            setStatus();
            textBoxId.Text = formermployee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(formermployee_id);
            textBoxLastName.Text = db.getLastNameUser(formermployee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(formermployee_id);
            textBoxEmail.Text = db.getEmailUser(formermployee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(formermployee_id);
            dateTimePicker.Value = db.getJoinDateUser(formermployee_id);
            textBoxAddedBy.Text = db.getAddedByUser(formermployee_id).ToString();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(formermployee_id);
            dateTimePicker2.Value = db.getLeaveDateUser(formermployee_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingUser(formermployee_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilityUser(formermployee_id);
            textBoxObservations.Text = db.getObservationsUser(formermployee_id);
        }
        
        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            setAvatarImage();
            setStatus();
            textBoxId.Text = formermployee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(formermployee_id);
            textBoxLastName.Text = db.getLastNameUser(formermployee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(formermployee_id);
            textBoxEmail.Text = db.getEmailUser(formermployee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(formermployee_id);
            dateTimePicker.Value = db.getJoinDateUser(formermployee_id);
            textBoxAddedBy.Text = db.getAddedByUser(formermployee_id).ToString();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(formermployee_id);
            dateTimePicker2.Value = db.getLeaveDateUser(formermployee_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingUser(formermployee_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilityUser(formermployee_id);
            textBoxObservations.Text = db.getObservationsUser(formermployee_id);
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
            DateTime leavedate = dateTimePicker2.Value.Date;
            string reasonforleaving = textBoxReasonForLeaving.Text;
            string rejoindesirability = textBoxRejoinDesirability.Text;
            string observations = textBoxObservations.Text;
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
                if (!db.checkUniqueDisplayNameUser(displayname,formermployee_id))
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
                if (!db.checkUniqueEmailUser(email,formermployee_id))
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

            // Verify reason for leaving
            if (verify_text.IsInjection(reasonforleaving) || !verify_text.HasOnlyLetters(reasonforleaving))
            {
                labelReasonForLeaving.Show();
                labelReasonForLeaving.Text = "Please insert only letters ";
                labelReasonForLeaving.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelReasonForLeaving.Hide();
            }

            // Verify rejoin desirability
            if (verify_text.IsInjection(rejoindesirability) || !verify_text.HasOnlyLetters(rejoindesirability))
            {
                labelRejoinDesirability.Show();
                labelRejoinDesirability.Text = "Please insert only letters ";
                labelRejoinDesirability.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelRejoinDesirability.Hide();
            }

            // Verify observations
            if (verify_text.IsInjection(observations))
            {
                labelObservations.Show();
                labelObservations.Text = "Please don't use SQL injection characters like ' or \\";
                labelObservations.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelObservations.Hide();
            }

            // If all data is correct
            if(ok == true)
            {
                db.updateFirstNameUser(formermployee_id, firstname);
                db.updateLastNameUser(formermployee_id, lastname);
                db.updateDisplayNameUser(formermployee_id, displayname);
                if (ok_pass == true)
                {
                    string hashed_password = Hash.hash(password, formermployee_id, 16);
                    db.updatePasswordUser(formermployee_id, hashed_password);
                }
                db.updateEmailUser(formermployee_id, email);
                db.updatePhoneNumberUser(formermployee_id, phonenumber);
                db.updateJoinDateUser(formermployee_id, joindate);
                string s;
                s = comboBoxStatus.SelectedItem.ToString();
                db.updateStatusUser(formermployee_id, s);
                db.updatePersonalNotesUser(formermployee_id, personalnotes);
                db.updateLeaveDateUser(formermployee_id, leavedate);
                db.updateReasonForLeavingUser(formermployee_id, reasonforleaving);
                db.updateRejoinDesirabilityUser(formermployee_id, rejoindesirability);
                db.updateObservationsUser(formermployee_id, observations);
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
        }

        /* <---------------------------------------- SOME SET METHODS ----------------------------------------> */
        // Set avatar image
        private void setAvatarImage()
        {
            // Get and set photo
            pictureAvatar.ImageLocation = db.getAvatarLinkUser(formermployee_id).ToString();
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
            comboBoxStatus.Text = db.getStatusUser(formermployee_id);
        }
    }
}
