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
    public partial class LoginSecretary : Form
    {
        // Database handler: methods with queries
        private DatabaseHandler database_handler = new DatabaseHandler();
        private VerifyText verify_text = new VerifyText();

        // Constructor 
        public LoginSecretary()
        {
            InitializeComponent();
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
            if(verify_text.IsInjection(username) || verify_text.IsInjection(password))
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
    }
}
