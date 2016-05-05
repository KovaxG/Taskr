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

            //Application.Run(new LoginApp());

            DatabaseHandler dh = new DatabaseHandler();
            UserAppS ua;
            LoginApp la = new LoginApp(dh);
            //dh.VerifyLogin("Dan", "passworddan9");
            //ua = new UserAppS(dh);
            //ua.ShowDialog();
            
            if (la.ShowDialog() == DialogResult.OK)
            {
                ua = new UserAppS(dh);
                ua.ShowDialog();
            }
        }
    }
}
