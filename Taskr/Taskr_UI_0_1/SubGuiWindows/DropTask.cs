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
    public partial class DropTask : Form
    {
        DatabaseHandler d;
        private Delegate rp;
        private Delegate sp;
        private Delegate aw;
        public DropTask(DatabaseHandler d, Delegate rp, Delegate sp, Delegate aw)
        {
            this.d = d;
            this.rp = rp;
            this.sp = sp;
            this.aw = aw;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void buttonSubmitDropTask_Click(object sender, EventArgs e)
        {
            if (d.SubmitDropTask(richTextBoxReasonDropTask.Text))
            {
                if (d.DropTask())
                { 
                    MessageBox.Show("Task drop submission succesfully sent!");             
                }
                else
                {
                    MessageBox.Show("Task drop submission was not sent!");
                }

                rp.DynamicInvoke();

                List<TaskData> ltd = d.GetRequestedTasks();
                TaskData td = ltd.FirstOrDefault();

                if (td == null)
                {
                    td = new TaskData();
                }
                if (!td.IsDefault())
                {
                    d.GrantTask(td, d.User);
                    sp.DynamicInvoke();
                }

                aw.DynamicInvoke();

                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Task drop submission failed to send! Try again later please.");
            }
        }
    }
}