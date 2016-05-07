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
        private HomePage mainForm = null;
        DatabaseHandler db = new DatabaseHandler();
        int user;
        public NewUser(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as HomePage;
            user = this.mainForm.getUser;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int ok = 0;
            if (!String.IsNullOrEmpty(textBoxDisplayName.Text) && !String.IsNullOrEmpty(textBoxAvatarURL.Text) && !String.IsNullOrEmpty(textBoxFirstName.Text) && !String.IsNullOrEmpty(textBoxLastName.Text)&& !String.IsNullOrEmpty(textBoxEmail.Text)&& !String.IsNullOrEmpty(textBoxPassword.Text)&& !String.IsNullOrEmpty(textBoxPhoneNumber.Text) )
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = textBoxPassword.Text;
                string phonenumber = textBoxPhoneNumber.Text;
                string avatarurl = textBoxAvatarURL.Text;
                string displayname = textBoxDisplayName.Text;
                DateTime date = dateTimePicker.Value.Date;
              
                if (radioButtonFreelancer.Checked)
                {
                    db.createFreelancer(firstname, lastname, email, displayname, phonenumber, password, avatarurl, date, user);
                    MessageBox.Show("New Freelancer created!");
                    textBoxFirstName.Clear();
                    textBoxLastName.Clear();
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                    textBoxAvatarURL.Clear();
                    textBoxPhoneNumber.Clear();
                    textBoxDisplayName.Clear();
                    dateTimePicker.ResetText();
                }
                if (radioButtonSecretary.Checked)
                {
                    db.createSecretary(firstname, lastname, email, displayname, phonenumber, password, avatarurl, date);
                    MessageBox.Show("New Secretary created!");
                    textBoxFirstName.Clear();
                    textBoxLastName.Clear();
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                    textBoxAvatarURL.Clear();
                    textBoxPhoneNumber.Clear();
                    textBoxDisplayName.Clear();
                    dateTimePicker.ResetText();
                }
            }
                
            else
            {
                if(!radioButtonFreelancer.Checked && !radioButtonSecretary.Checked)
                {
                    MessageBox.Show("Please choose the type of user and fill all entries!");
                    ok = 1;
                }
                else
                {
                    MessageBox.Show("Please fill all entries!");
                }
            }
            if (!radioButtonFreelancer.Checked && !radioButtonSecretary.Checked && ok == 0)
            {
                MessageBox.Show("Please choose the type of user!");
            }
            
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonFreelancer_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
