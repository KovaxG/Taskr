
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //initializes the databasehandler and establishes connection to the database
            DatabaseHandler d = new DatabaseHandler();

            //checks for valid connection
            if (!d.Test())
            {
                MessageBox.Show("Could not connect to database!");
                return;
            }

            //check username and password
            FreeLancer ua;
            LoginApp la = new LoginApp(d);

            try
            {
                if (la.ShowDialog() == DialogResult.OK)
                {
                    ua = new FreeLancer(d);
                    ua.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error occured during launch");
            }
            
        }
    }
}