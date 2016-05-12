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
    public partial class UploadFiles : Form
    {

        DatabaseHandler d;

        Delegate sp;
        Delegate aw;
        Delegate rp;

        public UploadFiles(DatabaseHandler d, Delegate sp, Delegate aw, Delegate rp)
        {
            this.d = d;
            this.sp = sp;
            this.rp = rp;
            this.aw = aw;

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void buttonSubmitUploadFiles_Click(object sender, EventArgs e)
        {
            TaskData td = d.GetActiveTask();

            if (textBoxLinkUploadFiles.Text == "")
            {
                MessageBox.Show("Must complete designated section with link to relevant files!");
            }
            else
            {
                string text = this.textBoxLinkUploadFiles.Text;
                td.Status = text;

                /*if (d.UpdateTask(td))
                {
                    MessageBox.Show("Submission successfully sent.");
                }
                else
                {
                    MessageBox.Show("Submission was not sent.");
                }

                if (d.DropTask())
                {
                    MessageBox.Show("Task was dropped.");
                }
                else
                {
                    MessageBox.Show("Task could not be dropped!");
                }*/

                d.User.ActiveTask = 0;
                d.DropTask();

                rp.DynamicInvoke();

                List<TaskData> ltd = d.GetRequestedTasks();
                TaskData tdr = ltd.FirstOrDefault();

                /*if (tdr == null)
                {
                    tdr = new TaskData();
                }
                if (!tdr.IsDefault())
                {
                    d.GrantTask(tdr, d.User);
                    sp.DynamicInvoke();
                }*/

                aw.DynamicInvoke();

                this.Close();
                this.Dispose();
            }
        }
    }
}
