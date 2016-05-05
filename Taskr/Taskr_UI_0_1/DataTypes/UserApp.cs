using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taskr_UI_0_1
{
    public partial class UserApp : Form
    {
        DatabaseHandler d;
        public UserApp(DatabaseHandler d)
        {
            InitializeComponent();
            this.buttonUsername.Text = d.User.DisplayName;
            this.d = d;
        }

        private void UserApp_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //d.logOut();
            this.Close();
            this.Dispose();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonUsername_Click(object sender, EventArgs e)
        {
            comboStatus.PerformLayout();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
