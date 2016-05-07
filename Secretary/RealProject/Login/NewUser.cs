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
    
    public partial class NewUser : Form
    {
        DatabaseHandler db = new DatabaseHandler();
        VerifyText verify_text = new VerifyText();
        int secretary_id;
        
        // Constructor
        public NewUser(int id)
        {
            InitializeComponent();
            secretary_id = id;
        }

        // Create button
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            bool ok = true;
            bool ok_pass = false;
            string displayname = textBoxDisplayName.Text;
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string confirmpassword = textBoxConfirmPassword.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            DateTime date = dateTimePicker.Value.Date;

            // Verify firstname
            if(verify_text.IsInjection(firstname) || !verify_text.HasOnlyLetters(firstname))
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
            if (radioButtonFreelancer.Checked)
            {
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
                    if (!db.checkUniqueDisplayNameUser(displayname,0))
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
                    if (!db.checkUniqueEmailUser(email,0))
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
            }

            if (radioButtonSecretary.Checked)
            {
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
                    if (!db.checkUniqueDisplayNameSecretary(displayname,0))
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
                    if (!db.checkUniqueEmailSecretary(email,0))
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
            if(verify_text.IsInjection(phonenumber) || !verify_text.IsValidPhoneNumber(phonenumber))
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

            // Verify radiobuttons
            if(!radioButtonFreelancer.Checked && !radioButtonSecretary.Checked)
            {
                labelRadiobuttons.Show();
                labelRadiobuttons.Text = "Choose the type of the user.";
                labelRadiobuttons.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelRadiobuttons.Hide();
            }

            // If all data is correct
            if(ok == true)
            {
                if (radioButtonFreelancer.Checked)
                {
                    if (ok_pass == true)
                    {
                        //string hashed_password = Hash.hash(password, employee_id, 16);
                        db.createFreelancer(firstname, lastname, email, displayname, phonenumber, password, date, secretary_id);
                        int id = db.getIdUser(email);
                        string hashed_password = Hash.hash(password, id, 16);
                        db.updatePasswordUser(id, hashed_password);
                        MessageBox.Show("New Freelancer created!");
                        textBoxFirstName.Clear();
                        textBoxLastName.Clear();
                        textBoxEmail.Clear();
                        textBoxPassword.Clear();
                        textBoxPhoneNumber.Clear();
                        textBoxDisplayName.Clear();
                        dateTimePicker.ResetText();
                        this.Close();
                    }
                }
                if (radioButtonSecretary.Checked)
                {
                    if (ok_pass == true)
                    {
                        db.createSecretary(firstname, lastname, email, displayname, phonenumber, password, date);
                        int id = db.getIdSecretary(email);
                        string hashed_password = Hash.hash(password, id, 16);
                        db.updatePasswordSecretary(id, hashed_password);
                        MessageBox.Show("New Secretary created!");
                        textBoxFirstName.Clear();
                        textBoxLastName.Clear();
                        textBoxEmail.Clear();
                        textBoxPassword.Clear();
                        textBoxPhoneNumber.Clear();
                        textBoxDisplayName.Clear();
                        dateTimePicker.ResetText();
                        this.Close();
                    }
                }
            }
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
