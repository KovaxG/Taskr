using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login
{
    public partial class EditFormerSecretary : Form
    {
        int formersecretary_id;
        DatabaseHandler db = new DatabaseHandler();
        VerifyText verify_text = new VerifyText();
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;

        // Constructor
        public EditFormerSecretary(int id)
        {
            InitializeComponent();
            setTheme();
            formersecretary_id = id;
            setAvatarImage();
            setStatus();
            textBoxId.Text = formersecretary_id.ToString();
            textBoxFirstName.Text = db.getFirstNameSecretary(formersecretary_id);
            textBoxLastName.Text = db.getLastNameSecretary(formersecretary_id);
            textBoxDisplayName.Text = db.getDisplayNameSecretary(formersecretary_id);
            textBoxEmail.Text = db.getEmailSecretary(formersecretary_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(formersecretary_id);
            dateTimePicker.Value = db.getJoinDateSecretary(formersecretary_id);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(formersecretary_id);
            dateTimePicker2.Value = db.getLeaveDateSecretary(formersecretary_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingSecretary(formersecretary_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilitySecretary(formersecretary_id);
            textBoxObservations.Text = db.getObservationsSecretary(formersecretary_id);
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = formersecretary_id.ToString();
            setAvatarImage();
            setStatus();
            textBoxFirstName.Text = db.getFirstNameSecretary(formersecretary_id);
            textBoxLastName.Text = db.getLastNameSecretary(formersecretary_id);
            textBoxDisplayName.Text = db.getDisplayNameSecretary(formersecretary_id);
            textBoxEmail.Text = db.getEmailSecretary(formersecretary_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(formersecretary_id);
            dateTimePicker.Value = db.getJoinDateSecretary(formersecretary_id);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(formersecretary_id);
            dateTimePicker2.Value = db.getLeaveDateSecretary(formersecretary_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingSecretary(formersecretary_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilitySecretary(formersecretary_id);
            textBoxObservations.Text = db.getObservationsSecretary(formersecretary_id);
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
                labelFirstname.Text = "Please use only letters (a-z A-Z) in the Firstname.";
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
                labelLastname.Text = "Please use only letters (a-z A-Z) in the Lastname.";
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
                labelDisplayname.Text = "Please use only letters (a-z A-Z), numbers (0-9) or" + "\n" + " underscore (-) in the DisplayName.";
                labelDisplayname.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                if (!db.checkUniqueDisplayNameSecretary(displayname,formersecretary_id))
                {
                    labelDisplayname.Show();
                    labelDisplayname.Text = "This Displayname is already taken, please type another.";
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
                if (!db.checkUniqueEmailSecretary(email,formersecretary_id))
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
                    labelConfirmPassword.Text = "The password must have 8-15 charcters containing at least" + "\n" + " one lowercase, one uppercase and one digit.";
                    labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                    ok_pass = false;
                    ok = false;
                }
            }
            if (!password.Equals(confirmpassword))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "The 2 passwords don't match.";
                labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                ok_pass = false;
                ok = false;
            }

            // // Verify phonenumber
            if (verify_text.IsInjection(phonenumber) || !verify_text.IsValidPhoneNumber(phonenumber))
            {
                labelPhonenumber.Show();
                labelPhonenumber.Text = "The phonenumber must have exactly 10 digits.";
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
                labelNotes.Text = "Please don't use SQL injection characters like ' or \\.";
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
                labelReasonForLeaving.Text = "Please insert only letters.";
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
                labelRejoinDesirability.Text = "Please insert only letters.";
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
                labelObservations.Text = "Please don't use SQL injection characters like ' or \\.";
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
                db.updateFirstNameSecretary(formersecretary_id, firstname);
                db.updateLastNameSecretary(formersecretary_id, lastname);
                db.updateDisplayNameSecretary(formersecretary_id, displayname);
                if (ok_pass == true)
                {
                    db.updatePasswordSecretary(formersecretary_id, password);
                }
                db.updateEmailSecretary(formersecretary_id, email);
                db.updatePhoneNumberSecretary(formersecretary_id, phonenumber);
                db.updateJoinDateSecretary(formersecretary_id, joindate);
                string s;
                s = comboBoxStatus.SelectedItem.ToString();
                db.updateStatusSecretary(formersecretary_id, s);
                db.updatePersonalNotesSecretary(formersecretary_id, personalnotes);
                db.updateLeaveDateSecretary(formersecretary_id, leavedate);
                db.updateReasonForLeavingSecretary(formersecretary_id, reasonforleaving);
                db.updateRejoinDesirabilitySecretary(formersecretary_id, rejoindesirability);
                db.updateObservationsSecretary(formersecretary_id, observations);
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* <---------------------------------------- SOME SET METHODS ----------------------------------------> */
        // Set avatar image
        private void setAvatarImage()
        {
            // Get and set photo
            pictureAvatar.ImageLocation = db.getAvatarLinkSecretary(formersecretary_id).ToString();
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
            comboBoxStatus.Text = db.getStatusSecretary(formersecretary_id);
        }
        private void setColors()
        {
            List<string> lines = new List<string>();

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", theme_file);
            StreamReader Colors = new StreamReader(path);
            while (!Colors.EndOfStream)
            {
                lines.Add(Colors.ReadLine());
            }
            ButtonTextColor = Color.FromArgb(Convert.ToInt32(lines[0]));
            ButtonBackColor = Color.FromArgb(Convert.ToInt32(lines[1]));
            FormTextColor = Color.FromArgb(Convert.ToInt32(lines[2]));
            FormBackColor = Color.FromArgb(Convert.ToInt32(lines[3]));
            TextboxTextColor = Color.FromArgb(Convert.ToInt32(lines[8]));
            TextboxBackColor = Color.FromArgb(Convert.ToInt32(lines[9]));
            Colors.Close();
        }

        private void setTheme()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Selected theme.txt");
            StreamReader r = new StreamReader(path);
            string text_file = r.ReadLine();
            r.Close();

            if (text_file == "Gray")
            {
                theme_file = "Gray.txt";
            }

            if (text_file == "Purple")
            {
                theme_file = "Purple.txt";
            }
            if (text_file == "Taskr")
            {
                theme_file = "Taskr.txt";
            }
            if (text_file == "Colors")
            {
                theme_file = "Colors.txt";
            }

            setColors();
            foreach (Control c in this.Controls)
            {
                setColorControls(c);
            }
        }

        private void setColorControls(Control c)
        {

            if (c is Button)
            {
                c.ForeColor = ButtonTextColor;
                c.BackColor = ButtonBackColor;
            }
            if (c is TextBox)
            {
                c.ForeColor = TextboxTextColor;
                c.BackColor = TextboxBackColor;
            }
            this.ForeColor = FormTextColor;
            this.BackColor = FormBackColor;
        }

    }
}
