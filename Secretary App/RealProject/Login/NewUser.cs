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

    public partial class NewUser : Form
    {
        // Id of the secretary adding the new user
        int secretary_id;

        // Instance of the class, used for verifying the data entered by the user
        VerifyText verify_text = new VerifyText();

        // Database handler which makes the connections to the database
        DatabaseHandler db = new DatabaseHandler();

        // Colors
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;

        // Constructor
        public NewUser(int id)
        {
            InitializeComponent();
            secretary_id = id;
            setTheme();
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

            if (radioButtonFreelancer.Checked)
            {
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
                    if (!db.checkUniqueDisplayNameUser(displayname, 0))
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
                    if (!db.checkUniqueEmailUser(email, 0))
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
                    labelDisplayname.Text = "Please use only letters (a-z A-Z), numbers (0-9) or" + "\n" + " underscore (-) in the DisplayName.";
                    labelDisplayname.ForeColor = System.Drawing.Color.Red;
                    ok = false;
                }
                else
                {
                    if (!db.checkUniqueDisplayNameSecretary(displayname, 0))
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
                    if (!db.checkUniqueEmailSecretary(email, 0))
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
            if (verify_text.IsNull(password) && verify_text.IsNull(confirmpassword))
            {
                labelConfirmPassword.Show();
                labelConfirmPassword.Text = "Please insert a password.";
                labelConfirmPassword.ForeColor = System.Drawing.Color.Red;
                ok_pass = false;
                ok = false;
            }
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

            // Verify radiobuttons
            if (!radioButtonFreelancer.Checked && !radioButtonSecretary.Checked)
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
            if (ok == true)
            {
                if (radioButtonFreelancer.Checked)
                {
                    if (ok_pass == true)
                    {
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
                        db.updatePasswordSecretary(id, password);
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

        // Set colors
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
