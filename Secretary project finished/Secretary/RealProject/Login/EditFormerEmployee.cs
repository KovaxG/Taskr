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
    public partial class EditFormerEmployee : Form
    {
        // Id of the former employee being edited
        int formeremployee_id;

        // Database handler which makes the connections to the database
        DatabaseHandler db = new DatabaseHandler();

        // Instance of the class, used for verifying the data entered by the user
        VerifyText verify_text = new VerifyText();

        // Colors
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;

        // Constructor
        public EditFormerEmployee(int id)
        {
            InitializeComponent();
            formeremployee_id = id;
            setTheme();
            setAvatarImage();
            setStatus();
            // Take data from database and show it in form
            textBoxId.Text = formeremployee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(formeremployee_id);
            textBoxLastName.Text = db.getLastNameUser(formeremployee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(formeremployee_id);
            textBoxEmail.Text = db.getEmailUser(formeremployee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(formeremployee_id);
            dateTimePicker.Value = db.getJoinDateUser(formeremployee_id);
            textBoxAddedBy.Text = db.getDisplayNameSecretary(Int32.Parse(db.getAddedByUser(formeremployee_id))).ToString();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(formeremployee_id);
            dateTimePicker2.Value = db.getLeaveDateUser(formeremployee_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingUser(formeremployee_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilityUser(formeremployee_id);
            textBoxObservations.Text = db.getObservationsUser(formeremployee_id);
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            setAvatarImage();
            setStatus();
            textBoxId.Text = formeremployee_id.ToString();
            textBoxFirstName.Text = db.getFirstNameUser(formeremployee_id);
            textBoxLastName.Text = db.getLastNameUser(formeremployee_id);
            textBoxDisplayName.Text = db.getDisplayNameUser(formeremployee_id);
            textBoxEmail.Text = db.getEmailUser(formeremployee_id);
            textBoxPhoneNumber.Text = db.getPhoneNumberUser(formeremployee_id);
            dateTimePicker.Value = db.getJoinDateUser(formeremployee_id);
            textBoxAddedBy.Text = db.getDisplayNameSecretary(Int32.Parse(db.getAddedByUser(formeremployee_id))).ToString();
            textBoxPersonalNotes.Text = db.getPersonalNotesUser(formeremployee_id);
            dateTimePicker2.Value = db.getLeaveDateUser(formeremployee_id);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingUser(formeremployee_id);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilityUser(formeremployee_id);
            textBoxObservations.Text = db.getObservationsUser(formeremployee_id);
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
                if (!db.checkUniqueDisplayNameUser(displayname, formeremployee_id))
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
                if (!db.checkUniqueEmailUser(email, formeremployee_id))
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
            if (password.Equals(confirmpassword) && !verify_text.IsNull(password) && !verify_text.IsNull(confirmpassword) && !verify_text.IsInjection(confirmpassword) && !verify_text.IsInjection(password))
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
            // If passwords do not match
            if (!password.Equals(confirmpassword))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "The 2 passwords don't match.";
                labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                ok_pass = false;
                ok = false;
            }
            // If passwords contain SQL injection
            if (verify_text.IsInjection(confirmpassword) || verify_text.IsInjection(confirmpassword))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "Please don't use SQL injection characters like ' or \\.";
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

            // If all data is correct update it
            if (ok == true)
            {
                db.updateFirstNameUser(formeremployee_id, firstname);
                db.updateLastNameUser(formeremployee_id, lastname);
                db.updateDisplayNameUser(formeremployee_id, displayname);
                if (ok_pass == true)
                {
                    db.updatePasswordUser(formeremployee_id, password);
                }
                db.updateEmailUser(formeremployee_id, email);
                db.updatePhoneNumberUser(formeremployee_id, phonenumber);
                db.updateJoinDateUser(formeremployee_id, joindate);
                string status;
                status = comboBoxStatus.SelectedItem.ToString();
                db.updateStatusUser(formeremployee_id, status);
                db.updatePersonalNotesUser(formeremployee_id, personalnotes);
                db.updateLeaveDateUser(formeremployee_id, leavedate);
                db.updateReasonForLeavingUser(formeremployee_id, reasonforleaving);
                db.updateRejoinDesirabilityUser(formeremployee_id, rejoindesirability);
                db.updateObservationsUser(formeremployee_id, observations);
                MessageBox.Show("Successfully updated!");
                this.Close();
            }
        }

        /* <---------------------------------------- SOME SET METHODS ----------------------------------------> */
        // Set avatar image
        private void setAvatarImage()
        {
            // Get and set photo
            pictureAvatar.ImageLocation = db.getAvatarLinkUser(formeremployee_id).ToString();
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
            comboBoxStatus.Text = db.getStatusUser(formeremployee_id);
        }

        // Set colors from file
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

        // Select theme
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

        // Set colors in the form
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
