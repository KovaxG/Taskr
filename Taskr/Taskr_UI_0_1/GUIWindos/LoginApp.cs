using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    /// <summary>
    /// Log in interface and logic
    /// </summary>
    public partial class LoginApp : Form
    {
        /// <summary>
        /// The currently logged in user data will be kept inside d.
        /// </summary>
        DatabaseHandler d;

        public LoginApp(DatabaseHandler d)
        {
            this.d = d;
            InitializeComponent();
            this.textUserName.Focus();
            d = new DatabaseHandler();
            
        }

        /// <summary>
        /// Verifies textfields for emptiness and illegal characters
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textUserName.Text.Length > 0)
                if (textPassword.Text.Length > 0)
                    if (textPassword.Text.IndexOfAny(new[] {'\'', '\\' , ';','\"'}) == -1 &&
                        textUserName.Text.IndexOfAny(new[] { '\'', '\\', ';', '\"' }) == -1)
                        if (d.Login(textUserName.Text, textPassword.Text))
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else MessageBox.Show("Invalid Username or Password");
                    else MessageBox.Show("Invalid Characters Detected");
                else MessageBox.Show("Password Field Empty");
            else MessageBox.Show("Username Field Empty");
                        

        }

        /// <summary>
        /// catches control keys caught outside of input fields
        /// </summary>
        private void LoginApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                //enter
                case (char)13:
                    buttonLogin_Click(sender, e);
                    break;
                
                //tab
                case (char)9:
                   this.textUserName.Focus();
                   this.textUserName.SelectAll();
                    break;

                default:
                    this.textUserName.Focus();
                    this.textPassword.SelectAll();
                    break;
            }
        }

        /// <summary>
        /// Switches to password field when tab or enter is pressed within username field
        /// </summary>
        private void textUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                this.textPassword.Focus();
                this.textPassword.SelectAll();
            }
        }

        /// <summary>
        /// Forces log in event on enter key from password field
        /// </summary>
        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)13:
                    buttonLogin_Click(sender, e);
                    break;

                case (char)9:
                    this.buttonLogin.Focus();
                    break;

            }
        }

        /// <summary>
        /// Terminates application on escape key
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Following three functions select introduced data on reselction of the respective fields

        private void textUserName_MouseClick(object sender, MouseEventArgs e)
        {
            this.textUserName.SelectAll();
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            this.textUserName.SelectAll();
        }

        private void textPassword_Click(object sender, EventArgs e)
        {
            this.textPassword.SelectAll();
        }

    }
}
