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
    public partial class LoginSecretary : Form
    {
        // Instance of the class, used for verifying the data entered by the user
        private VerifyText verify_text = new VerifyText();

        // Database handler which makes the connections to the database
        private DatabaseHandler database_handler = new DatabaseHandler();

        // Colors
        Color ButtonTextColor;
        Color ButtonBackColor;
        Color FormTextColor;
        Color FormBackColor;
        Color TextboxTextColor;
        Color TextboxBackColor;
        string theme_file;

        // Constructor 
        public LoginSecretary()
        {
            InitializeComponent();
            setTheme();
        }

        // Login button
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // If fields are empty
            if (verify_text.IsNull(username) || verify_text.IsNull(password))
            {
                MessageBox.Show("Empty fields detected! Please fill up all the fields");
            }

            // If there are inserted ' or /
            if (verify_text.IsInjection(username) || verify_text.IsInjection(password))
            {
                // do nothing 
            }

            else
            {
                // Check if the data is correct
                bool correct_data = database_handler.CheckLogin(username, password);

                // Correct data
                if (correct_data)
                {
                    // Get the id of the user
                    int id_secretary = database_handler.getIdSecretary(username);

                    // Create a secretary specific form, sending the Id of the secretary via constructor
                    Secretary home_form = new Secretary(id_secretary);

                    this.Hide();
                    home_form.ShowDialog();
                    setTheme();
                    this.Show();

                    // Clear the text box for the password when returning
                    textBoxPassword.Clear();
                }

                // Incorrect data
                else
                {
                    MessageBox.Show("Incorrect Login Credentials");
                }
            }
        }

        private void buttonLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
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
