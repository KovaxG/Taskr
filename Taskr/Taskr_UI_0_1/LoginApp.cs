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
    public partial class LoginApp : Form
    {
        DatabaseHandler d;

        //UserAppS u;
        public LoginApp(DatabaseHandler d)
        {
            this.d = d;
            InitializeComponent();
            this.textUserName.Focus();
            d = new DatabaseHandler();
            if (!d.Test())
            {
                MessageBox.Show("Could not connect to database!");
                this.Close();
                this.Dispose();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textUserName.Text.Length > 0)
                if (textPassword.Text.Length > 0)
                    if (d.Login(textUserName.Text, textPassword.Text))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else MessageBox.Show("Invalid Username or Password");
                else MessageBox.Show("Password Field Empty");
            else MessageBox.Show("Username Field Empty");
                        

        }

        private void LoginApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)13:
                    buttonLogin_Click(sender, e);
                    break;

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

        private void textUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                this.textPassword.Focus();
                this.textPassword.SelectAll();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

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

        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) 13:
                    buttonLogin_Click(sender, e);
                    break;

                case (char) 9:
                    this.buttonLogin.Focus();
                    break;

            }
        }
    }
}
