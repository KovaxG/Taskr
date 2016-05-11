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

        private void button1_Click(object sender, EventArgs e)
        {
            /*System.Windows.Forms.DialogResult result = folderBrowserDialogUploadFiles.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Folder succesfully uploaded!");
            }
            else
            {
                MessageBox.Show("Something went wrong. Restart and if problem persists contact the developer.");
            }*/

            TaskData td = d.GetActiveTask();
            td.Status = this.textBoxLinkUploadFiles.Text;

            if (d.UpdateTask(td))
            {
                MessageBox.Show("Submission successfully sent.");
            }
            else
            {
                MessageBox.Show("Submission was not sent.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void buttonSubmitUploadFiles_Click(object sender, EventArgs e)
        {
            TaskData td = d.GetActiveTask();
            td.Status = this.textBoxLinkUploadFiles.Text;

            if (d.UpdateTask(td))
            {
                MessageBox.Show("Submission successfully sent.");
            }
            else
            {
                MessageBox.Show("Submission was not sent.");
            }

            if (d.DropTask())
            {
                MessageBox.Show("Task could not be dropped.");
            }
            else
            {
                MessageBox.Show("Task was dropped.");
            }

            rp.DynamicInvoke();

            List<TaskData> ltd = d.GetRequestedTasks();
            TaskData tdr = ltd.FirstOrDefault();

            if (tdr == null)
            {
                tdr = new TaskData();
            }
            if (!tdr.IsDefault())
            {
                d.GrantTask(tdr, d.User);
                sp.DynamicInvoke();
            }

            aw.DynamicInvoke();

            this.Close();
            this.Dispose();
        }
    }
}
