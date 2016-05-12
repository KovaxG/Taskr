using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Taskr_UI_0_1;
using System.Windows.Forms;
using System.Threading;

namespace Taskr_UI_0_1
{
    public class PanelItem : Form
    {

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadline;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonJoinTask;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button buttonRemoveTask;

        private TaskData td;
        private DatabaseHandler d;
        private Delegate sp;
        private Delegate aw;

        public PanelItem(int width, int height, int x, int y, TaskData td, bool ScrollBar ,DatabaseHandler d, Delegate sp, Delegate aw, bool ca)
        {
            this.td = td;
            this.d = d;
            this.sp = sp;
            this.aw = aw;

            //Room for the scroll bar
            if (ScrollBar)
            {
                width -= 25;
            }

            this.panel = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.buttonJoinTask = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerDeadline = new System.Windows.Forms.DateTimePicker();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();

            this.panel.Controls.Add(this.dateTimePickerDeadline);
            this.panel.Controls.Add(this.textBoxScore);
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.textBoxTitle);
            this.panel.Controls.Add(this.buttonJoinTask);
            this.panel.Controls.Add(this.picture);

            this.panel.Size = new System.Drawing.Size(width, height);
            this.panel.Location = new System.Drawing.Point(x, y);
            if (ca)
            {
                this.panel.BackColor = Color.GreenYellow;
                this.buttonJoinTask.BackColor = Color.AntiqueWhite;
            }
            else
            {
                this.panel.BackColor = System.Drawing.Color.Azure;
            }

            this.picture.Size = new System.Drawing.Size((int)(width / 4), height);
            this.picture.Location = new System.Drawing.Point(3, 3);
            new Thread(() =>
            {
                try
                {
                    this.picture.Load(this.td.ImageURL);
                }
                catch
                {
                    //MessageBox.Show("Picture could not pe loaded!");
                    this.picture.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
                }
            }).Start();
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.Visible = true;
            this.picture.Enabled = true;

            this.textBoxTitle.Size = new System.Drawing.Size((int)(3 * width / 5), (int)(height / 5));
            this.textBoxTitle.Location = new System.Drawing.Point((int)(width / 4 + 6), 3);
            this.textBoxTitle.Text = td.Title;//"TEST text";
            this.textBoxTitle.ReadOnly = true;

            this.textBoxDescription.Size = new System.Drawing.Size((int)((width * 3 / 4) - 9), (int)((height * 2 / 5) - 9));
            this.textBoxDescription.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height / 5 + 9));
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Text = td.ShortDescription;//"TEST text 2"; 
            this.textBoxDescription.ReadOnly = true;

            this.dateTimePickerDeadline.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.dateTimePickerDeadline.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height * 4 / 5 - 3));
            this.dateTimePickerDeadline.Text = td.DeadLine.ToString();// "01.01.2024";
            this.dateTimePickerDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeadline.CustomFormat = "yyyy-MM-dd";
            //this.dateTimePickerDeadline.Enabled = false;

            this.textBoxScore.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.textBoxScore.Location = new System.Drawing.Point((int)(width * 2 / 4 + 9), (int)(height * 4 / 5 - 3));
            this.textBoxScore.Text = "1000";

            this.buttonJoinTask.Size = new System.Drawing.Size((int)((width / 4 - 15)), (int)(height / 5 + 3));
            this.buttonJoinTask.Location = new System.Drawing.Point((int)(width * 3 / 4 + 12), (int)(height * 4 / 5 - 3));
            this.buttonJoinTask.Text = "Join Task";
            this.buttonJoinTask.Click += new System.EventHandler(this.buttonJoinTask_Click);

            this.panel.ResumeLayout();
            this.panel.PerformLayout();
        }

        public PanelItem(int width, int height, int x, int y, TaskData td, bool ScrollBar, Delegate aw, DatabaseHandler d)
        {
            this.td = td;
            this.aw = aw;
            this.d = d;

            //Room for the scroll bar
            if (ScrollBar)
            {
                width -= 25;
            }

            this.panel = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.buttonJoinTask = new System.Windows.Forms.Button();
            this.buttonRemoveTask = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.dateTimePickerDeadline = new System.Windows.Forms.DateTimePicker();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();

            this.panel.Controls.Add(this.dateTimePickerDeadline);
            this.panel.Controls.Add(this.textBoxScore);
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.textBoxTitle);
            //this.panel.Controls.Add(this.buttonJoinTask);
            this.panel.Controls.Add(this.picture);

            if (ScrollBar)
            {
                this.panel.Controls.Add(this.buttonRemoveTask);
            }

            this.panel.Size = new System.Drawing.Size(width, height);
            this.panel.Location = new System.Drawing.Point(x, y);
            this.panel.BackColor = System.Drawing.Color.Azure;
            this.panel.Name = "ActiveTaskPanel";

            this.picture.Size = new System.Drawing.Size((int)(width / 4), height);
            this.picture.Location = new System.Drawing.Point(3, 3);
            new Thread(() =>
            {
                try
                {
                    this.picture.Load(this.td.ImageURL);
                }
                catch
                {
                    //MessageBox.Show("Picture could not pe loaded!");
                    this.picture.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
                }
            }).Start();
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.Visible = true;
            this.picture.Enabled = true;

            this.textBoxTitle.Size = new System.Drawing.Size((int)(3 * width / 5), (int)(height / 5));
            this.textBoxTitle.Location = new System.Drawing.Point((int)(width / 4 + 6), 3);
            this.textBoxTitle.Text = td.Title;//"TEST text";
            this.textBoxTitle.ReadOnly = true;

            this.textBoxDescription.Size = new System.Drawing.Size((int)((width * 3 / 4) - 9), (int)((height * 2 / 5) - 9));
            this.textBoxDescription.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height / 5 + 9));
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Text = td.ShortDescription;//"TEST text 2"; 
            this.textBoxDescription.ReadOnly = true;

            this.dateTimePickerDeadline.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.dateTimePickerDeadline.Location = new System.Drawing.Point((int)(width / 4 + 6), (int)(height * 7 / 10));
            this.dateTimePickerDeadline.Text = td.DeadLine.ToString();// "01.01.2024";
            this.dateTimePickerDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeadline.CustomFormat = "yyyy-MM-dd";
            //this.dateTimePickerDeadline.Enabled = false;

            this.textBoxScore.Size = new System.Drawing.Size((int)((width / 4 - 3)), (int)(height / 5));
            this.textBoxScore.Location = new System.Drawing.Point((int)(width * 2 / 4 + 9), (int)(height * 7 / 10));
            this.textBoxScore.Text = "1000 points";

            this.buttonJoinTask.Size = new System.Drawing.Size((int)((width / 4 - 15)), (int)(height / 5 + 3));
            this.buttonJoinTask.Location = new System.Drawing.Point((int)(width * 3 / 4 + 12), (int)(height * 4 / 5 - 3));
            this.buttonJoinTask.Text = "Join Task";
            this.buttonJoinTask.Click += new System.EventHandler(this.buttonJoinTask_Click);

            try
            {
                this.buttonRemoveTask.Size = new System.Drawing.Size((int)((width / 4 - 15)), (int)(height / 5 ));
                this.buttonRemoveTask.Location = new System.Drawing.Point((int)(width * 3 / 4 + 12), (int)(height * 7 / 10));
                this.buttonRemoveTask.Text = "Remove";
                this.buttonRemoveTask.Click += new System.EventHandler(this.buttonRemoveTask_Click);
            }
            catch (Exception e) { }
            this.panel.ResumeLayout();
            this.panel.PerformLayout();
        }

            public System.Windows.Forms.Panel GetPanel()
            {
                return (this.panel);
            }

            public void buttonJoinTask_Click(Object sender, EventArgs e)
            {
                //If no change in deadline

                if (!d.TaskRequest(td) || d.User.ActiveTask == td.ID)
                {
                    MessageBox.Show("Task is already requested or active.");
                }
                else
                {
                    if (DateTime.Parse(this.dateTimePickerDeadline.Text) == td.DeadLine)
                    {
                        /*if (d.User.ActiveTask == 0)
                        {
                            if (d.GrantTask(td, d.User))
                            {
                                MessageBox.Show("Successfully applied for task!!!");
                                sp.DynamicInvoke();
                            }
                            else
                            {
                                MessageBox.Show("Some error has occurred in the DatabaseHandler!");
                            }
                        }*/
                        //else

                        if (d.User.ActiveTask == 0)
                        {
                            this.panel.BackColor = Color.GreenYellow;
                            this.buttonJoinTask.BackColor = Color.AntiqueWhite;
                            MessageBox.Show("Successfully applied for task. Please wait for team leader response.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "No more than one task can be active in the same time. Task has been added to your task queue");
                        }

                        aw.DynamicInvoke();
                    }
                    //Else negotiate
                    else
                    {
                        MessageBox.Show("Deadlines do not match. Negotiation.");
                    }
                }
            }

            public void buttonRemoveTask_Click(Object sender, EventArgs e)
            {
                if (td == null)
                {
                    MessageBox.Show("Task data is null in buttonRemoveTask_Click");
                }
                else
                {
                    if (d.CancelTaskRequest(td))
                    {
                        MessageBox.Show("Task successfully removed!");
                    }
                    else
                    {
                        MessageBox.Show("Task was not removed!");
                    }
                }

                aw.DynamicInvoke();
            }
    }
}
