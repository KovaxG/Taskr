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
    public partial class Login : Form
    {
        DatabaseHandler db = new DatabaseHandler();
        int user;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string usertext = textBoxUsername.Text;
            string passtext = textBoxPassword.Text;

            user = db.getIdSecretary(usertext);

            
            if (usertext == "" || passtext == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            bool r = db.CheckLogin(usertext, passtext);
            if (r)
            {
                MessageBox.Show("Correct Login Credentials");
                HomePage homeForm = new HomePage(this);

                this.Hide();
                homeForm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Incorrect Login Credentials");
        }
        public int getUser
        {
            get { return user; }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
