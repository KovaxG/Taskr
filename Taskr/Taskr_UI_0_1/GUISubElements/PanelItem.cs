using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Taskr_UI_0_1;

namespace TeamMember
{
    public class PanelItem
    {

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker textBoxDeadline;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonJoinTask;
        private System.Windows.Forms.PictureBox picture;

        private TaskData td;

        public PanelItem(int width, int height, int x, int y, TaskData td)
        {
            this.td = td;

            this.panel = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.buttonJoinTask = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxDeadline = new System.Windows.Forms.DateTimePicker();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();

            this.panel.Controls.Add(this.textBoxDeadline);
            this.panel.Controls.Add(this.textBoxScore);
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.textBoxTitle);
            this.panel.Controls.Add(this.buttonJoinTask);
            this.panel.Controls.Add(this.picture);

            this.panel.Size = new System.Drawing.Size(width, height);
            this.panel.Location = new System.Drawing.Point(x, y);
            this.panel.BackColor = System.Drawing.Color.Azure;

            this.picture.Size = new System.Drawing.Size((int)(width / 4), height);
            this.picture.Location = new System.Drawing.Point(3, 3);
            this.picture.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.Visible = true;
            this.picture.Enabled = true;

            this.textBoxTitle.Size = new System.Drawing.Size((int)(3 * width / 5), (int)(height / 5));
            this.textBoxTitle.Location = new System.Drawing.Point((int)(width / 4 + 6), 3);
            this.textBoxTitle.Text = td.Title;//"TEST text";

            this.textBoxDescription.Size = new System.Drawing.Size((int)((width * 3 / 4) - 9), (int)((height * 2 / 5) - 9));
            this.textBoxDescription.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height / 5 + 9));
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Text = td.ShortDescription;//"TEST text 2"; 

            this.textBoxDeadline.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.textBoxDeadline.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height * 4 / 5 - 3));
            this.textBoxDeadline.Text = td.DeadLine.ToString();// "01.01.2024";
            this.textBoxDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //this.textBoxDeadline.Enabled = false;

            this.textBoxScore.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.textBoxScore.Location = new System.Drawing.Point((int)(width * 2 / 4 + 9), (int)(height * 4 / 5 - 3));
            this.textBoxScore.Text ="1000 points";

            this.buttonJoinTask.Size = new System.Drawing.Size((int)((width / 4 - 15)), (int)(height / 5 + 3));
            this.buttonJoinTask.Location = new System.Drawing.Point((int)(width * 3 / 4 + 12), (int)(height * 4 / 5 - 3));
            this.buttonJoinTask.Text = "Join Task";
            this.buttonJoinTask.Click += new System.EventHandler(this.buttonJoinTask_Click);

            this.panel.ResumeLayout();
            this.panel.PerformLayout();
        }

            public System.Windows.Forms.Panel GetPanel()
            {
                return (this.panel);
            }

            public void buttonJoinTask_Click(Object sender, EventArgs e)
            {
                if (this.textBoxDeadline.Text == td.DeadLine.ToString())
                {

                }
            }
    }
}
