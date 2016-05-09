
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

            DatabaseHandler d = new DatabaseHandler();
            FreeLancer ua;
            LoginApp la = new LoginApp(d);
            if (d.Login("Tavi", "T??øxàgD*?8P8p?"))
            {
                ua = new FreeLancer(d);
                ua.ShowDialog();
            }
            /*try
            {
                if (la.ShowDialog() == DialogResult.OK)
                {
                    ua = new FreeLancer(dh);
                    ua.ShowDialog();
                }
            }
            catch (Exception e) {}*/
        }
    }
}