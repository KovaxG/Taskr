using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Taskr_UI_0_1
{
    public partial class TeamLeader : Form
    {
        private DatabaseHandler d;
        private ProjectData projectData;
        private List<TaskData> tdl;
        public TeamLeader(DatabaseHandler d)
        {
            this.d = d;
            projectData = d.GetCurrentProject();
            tdl = d.GetTasksForProject(projectData);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            InitializeTaskList();
            InitializeProjectDetails();
            LoadAvatarArea();
        }

        private void LoadAvatarArea()
        {
            try
            {
                pictureAvatar.Load(d.User.AvatarURL);
            }
            catch// (FileNotFoundException)
            {
                pictureAvatar.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
            labelUsername.Size = new System.Drawing.Size(pictureAvatar.Size.Width, 16);
            labelUsername.Text = d.User.DisplayName; //does not change size in current Build

        }

        private void InitializeTaskList()
        {
            if (tdl != null)
            {
                foreach (TaskData td in tdl)
                {
                    PanelItemTasks item = new PanelItemTasks(td);
                    this.flowLayoutPanelTasks.Controls.Add(item);
                }
            }
            else
            {
                
            }
            /*
            List<TaskData> tdl = d.GetTasksForProject(projectData);
            PanelItemTasks pit;
            if (tdl != null)
            {
                foreach (TaskData td in tdl)
                {
                    pit = new PanelItemTasks(td);
                    this.flowLayoutPanelProjectSuggestions.Controls.Add(pit);
                }
            }*/
        }

        private void InitializeProjectDetails()
        {
            this.TextBoxProjectTitle.Text = projectData.Title;
            this.TextBoxProjectShortDescritpion.Text = projectData.ShortDescription;
            this.TextBoxProjectLongDescription.Text = projectData.DetailedDescription;
            this.textBoxProjectImageURL.Text = projectData.ImageURL;
            this.textBoxCurrentYield.Text = projectData.CurrentYield;
            this.textBoxAvailableFunds.Text = projectData.AvailibleFunds;
            this.textBoxModificationLog.Text = projectData.LogURL;
            try
            {
                this.pictureBoxProjectImage.Load(projectData.ImageURL);
            }
            catch
            {
                this.pictureBoxProjectImage.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
        }
        
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        //will be used if we have a server-side app
        /*private void ButtonChangeProjectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProjectImage.Load(openFileDialog1.FileName);
            }

            if (!pictureBoxProjectImage.ImageLocation.Equals(projectData.ImageURL))
            {
                pictureBoxProjectImage.BackColor = Color.Yellow;
            }
        }*/


        private void TextBoxProjectTitle_TextChanged(object sender, EventArgs e)
        {
            if (!TextBoxProjectTitle.Text.Equals(projectData.Title))
            {
                TextBoxProjectTitle.BackColor = Color.Yellow;
            }
            else
            {
                TextBoxProjectTitle.BackColor = Color.White;
            }
        }

        private void TextBoxProjectShortDescritpion_TextChanged(object sender, EventArgs e)
        {
            if (!TextBoxProjectShortDescritpion.Text.Equals(projectData.ShortDescription))
            {
                TextBoxProjectShortDescritpion.BackColor = Color.Yellow;
            }
            else
            {
                TextBoxProjectShortDescritpion.BackColor = Color.White;
            }
        }

        private void TextBoxProjectLongDescription_TextChanged(object sender, EventArgs e)
        {
            if (!TextBoxProjectLongDescription.Text.Equals(projectData.DetailedDescription))
            {
                TextBoxProjectLongDescription.BackColor = Color.Yellow;
            }
            else
            {
                TextBoxProjectLongDescription.BackColor = Color.White;
            }
        }

        private void textBoxImageURL_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxProjectImageURL.Text.Equals(projectData.ImageURL))
            {
                textBoxProjectImageURL.BackColor = Color.Yellow;
            }
            else
            {
                textBoxProjectImageURL.BackColor = Color.White;
            }
        }

        private void textBoxProjectImageURL_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.pictureBoxProjectImage.Load(textBoxProjectImageURL.Text);
            }
            catch
            {
                this.pictureBoxProjectImage.Image = global::Taskr_UI_0_1.Properties.Resources.X_128;
            }
        }

        private void textBoxCurrentYield_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxCurrentYield.Text.Equals(projectData.CurrentYield))
            {
                textBoxCurrentYield.BackColor = Color.Yellow;
            }
            else
            {
                textBoxCurrentYield.BackColor = Color.White;
            }
        }

        private void textBoxAvailableFunds_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxAvailableFunds.Text.Equals(projectData.AvailibleFunds))
            {
                textBoxAvailableFunds.BackColor = Color.Yellow;
            }
            else
            {
                textBoxAvailableFunds.BackColor = Color.White;
            }
        }

        private void textBoxModificationLog_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxModificationLog.Text.Equals(projectData.LogURL))
            {
                textBoxModificationLog.BackColor = Color.Yellow;
            }
            else
            {
                textBoxModificationLog.BackColor = Color.White;
            }
        }


        private void ButtonUpdateProjectDetails_Click(object sender, EventArgs e)
        {

            String t1 = projectData.Title,
                t2 = projectData.ShortDescription,
                t3 = projectData.DetailedDescription,
                t4 = projectData.ImageURL,
                t5 = projectData.CurrentYield,
                t6= projectData.AvailibleFunds,
                t7 = projectData.LogURL;
            projectData.Title = this.TextBoxProjectTitle.Text;
            projectData.ShortDescription = this.TextBoxProjectShortDescritpion.Text;
            projectData.DetailedDescription=this.TextBoxProjectLongDescription.Text;
            projectData.ImageURL = this.pictureBoxProjectImage.ImageLocation;
            projectData.CurrentYield= this.textBoxCurrentYield.Text;
            projectData.AvailibleFunds= this.textBoxAvailableFunds.Text;
            projectData.LogURL =this.textBoxModificationLog.Text;
            ///No way to copy- need to check if inserted first than change the projectData variable
            if (!d.UpdateProject(projectData))
            {
                //reverse changes

                projectData.Title = t1;
                projectData.ShortDescription =t2;
                projectData.DetailedDescription =t3;
                projectData.ImageURL =t4;
                projectData.CurrentYield = t5;
                projectData.AvailibleFunds = t6;
                projectData.LogURL=t7;
            }
            else
            {
                MessageBox.Show("Project Successfully updated", "Success!");
                
                //remove yellow background
                TextBoxProjectTitle_TextChanged(null, null);
                TextBoxProjectShortDescritpion_TextChanged(null, null);
                TextBoxProjectLongDescription_TextChanged(null, null);
                textBoxImageURL_TextChanged(null, null);
                textBoxCurrentYield_TextChanged(null, null);
                textBoxAvailableFunds_TextChanged(null, null);
                textBoxModificationLog_TextChanged(null, null);
            }
        }

        private void buttonAbandonProject_Click(object sender, EventArgs e)
        {
         
            if (d.AbolishProject("Just Couase"))
            {
                MessageBox.Show("Project Successfully abolished");
                
                UserAppS u = new UserAppS(d);

                this.Close();
                this.Dispose();
                u.ShowDialog();
            }
        }

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            //UserUpdate moved to inside field
            //UserData ud=d.User;
            EditUserData eu = new EditUserData(d);

            if (eu.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Your details have been successfully changed");
                //d.UpdateUser(ud);
                LoadAvatarArea();
            }
            else
            {
                //MessageBox.Show("Change cancelled");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textBoxTaskImageURL_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.pictureBoxTaskImage.Load(textBoxTaskImageURL.Text);
            }
            catch
            {
                this.pictureBoxTaskImage.Image = global::Taskr_UI_0_1.Properties.Resources.X;
            }
        }
        private void buttonCreateTask_Click(object sender, EventArgs e)
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
                if (this.dateTimePickerDeadLine.Value.Subtract(DateTime.Now).TotalMinutes<10)
                {
                    //if you want to check the value(always shows with minus for some reason)
                    //this.textBoxTaskLongDescription.Text = DateTime.Now.Subtract(this.dateTimePickerDeadLine.Value).TotalMinutes.ToString();
                    MessageBox.Show("You cannot create a task that is shorter than 10 minutes!","Not enough time");
                    return; 
                }
                if (this.dateTimePickerDeadLine.Value.Subtract(DateTime.Now).TotalDays >90)
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

                if (d.InsertNewTask(TaskData))
                {
                    MessageBox.Show("New Task Successfully Created. \nIt will appear in the task list", "Success!");
                    //reInitializeContents();
                }
                else
                {
                    MessageBox.Show("Could not create Task");
                }
            }
        }

        private void buttonCreateItem_Click(object sender, EventArgs e)
        {
            //can't get this to work
            tabControlVarious.Focus();
            tabControlVarious.Select();
            tabCreateTask.Focus();
            tabCreateTask.Select();
            panelCreateTask.Focus();
            panelCreateTask.Select();
            textBoxTaskTitle.Focus();
            textBoxTaskTitle.Select();
        }
    }
}
