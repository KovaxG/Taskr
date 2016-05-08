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

namespace Taskr_UI_0_1.SubGuiWindows
{
    public partial class EditTaskDetails : Form
    {
        private TaskData taskData;
        private DatabaseHandler d;
        public EditTaskDetails(DatabaseHandler d, TaskData taskData)
        {
            this.d = d;
            this.taskData = taskData;

            
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            this.textBoxTaskTitle.Text = taskData.Title;
            this.textBoxTaskShortDescription.Text = taskData.ShortDescription;
            this.textBoxTaskLongDescription.Text = taskData.DetailedDescription;
            this.textBoxTaskImageURL.Text = taskData.ImageURL;
            this.dateTimePickerDeadLine.Value = taskData.DeadLine;
            try
            {
                this.pictureBoxTaskImage.Load(textBoxTaskImageURL.Text);
            }
            catch
            {
                this.pictureBoxTaskImage.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
        }


        private void TextBoxTaskTitle_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxTaskTitle.Text.Equals(taskData.Title))
            {
                textBoxTaskTitle.BackColor = Color.Yellow;
            }
            else
            {
                textBoxTaskTitle.BackColor = Color.White;
            }
        }

        private void TextBoxTaskShortDescritpion_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxTaskShortDescription.Text.Equals(taskData.ShortDescription))
            {
                textBoxTaskShortDescription.BackColor = Color.Yellow;
            }
            else
            {
                textBoxTaskShortDescription.BackColor = Color.White;
            }
        }

        private void textBoxTaskLongDescription_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxTaskLongDescription.Text.Equals(taskData.DetailedDescription))
            {
                textBoxTaskLongDescription.BackColor = Color.Yellow;
            }
            else
            {
                textBoxTaskLongDescription.BackColor = Color.White;
            }
        }

        private void textBoxTaskImageURL_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxTaskImageURL.Text.Equals(taskData.ImageURL))
            {
                textBoxTaskImageURL.BackColor = Color.Yellow;
            }
            else
            {
                textBoxTaskImageURL.BackColor = Color.White;
            }
        }

        private void dateTimePickerDeadLine_ValueChanged(object sender, EventArgs e)
        {
            if (!dateTimePickerDeadLine.Value.Equals(taskData.DeadLine))
            {
                dateTimePickerDeadLine.Font =new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                dateTimePickerDeadLine.Font= new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void textBoxTaskImageURL_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.pictureBoxTaskImage.Load(textBoxTaskImageURL.Text);
            }
            catch
            {
                this.pictureBoxTaskImage.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
        }

        private void buttonUpdateTask_Click(object sender, EventArgs e)
        {
            {
                if (this.textBoxTaskTitle.Text.Equals(""))
                {
                    MessageBox.Show("Title field is compulsory!", "Empty Field");
                    return;
                }
                if (this.textBoxTaskShortDescription.Text.Length < 20)
                {
                    MessageBox.Show("The short description needs to be at least 20 characters long!",
                        "Description too short");
                    return;
                }
                if (this.dateTimePickerDeadLine.Value.Subtract(DateTime.Now).TotalMinutes < 10)
                {
                    //if you want to check the value(always shows with minus for some reason)
                    //this.textBoxTaskLongDescription.Text = DateTime.Now.Subtract(this.dateTimePickerDeadLine.Value).TotalMinutes.ToString();
                    MessageBox.Show("You cannot create a task that is shorter than 10 minutes!", "Not enough time");
                    return;
                }
                if (this.dateTimePickerDeadLine.Value.Subtract(DateTime.Now).TotalDays > 90)
                {
                    MessageBox.Show(
                        "You cannot create a task longer than 3 months!\nTry splitting it into shorter segments",
                        "Task too long");
                    return;
                }
                TaskData TaskData = new TaskData();
                TaskData.Title = this.textBoxTaskTitle.Text;
                TaskData.ShortDescription = this.textBoxTaskShortDescription.Text;
                TaskData.DetailedDescription = this.textBoxTaskLongDescription.Text;
                TaskData.ImageURL = this.textBoxTaskImageURL.Text;
                TaskData.DeadLine = this.dateTimePickerDeadLine.Value;
                TaskData.ParentProject = d.GetCurrentProject().ID;

                TaskData backupTaskData = new TaskData(taskData);
                if (d.InsertNewTask(TaskData))
                {
                    MessageBox.Show("New Task Successfully Modified.", "Success!");
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Could not create Task");
                    taskData = backupTaskData;
                }
            }
        }

    }
}
