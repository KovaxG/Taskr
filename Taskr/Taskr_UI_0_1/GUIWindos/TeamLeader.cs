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
        public TeamLeader(DatabaseHandler d)
        {
            this.d = d;
            projectData = d.GetCurrentProject();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            InitializeTaskList();
            InitializeProjectDetails();
        }

        private void InitializeTaskList()
        {
            List<TaskData> tdl = d.GetTasksForProject(projectData);
            PanelItemTasks pit;
            if (tdl != null)
            {
                foreach (TaskData td in tdl)
                {
                    pit = new PanelItemTasks(td);
                    this.flowLayoutPanelProjectSuggestions.Controls.Add(pit);
                }
            }
        }

        private void InitializeProjectDetails()
        {
            this.TextBoxProjectTitle.Text = projectData.Title;
            this.TextBoxProjectShortDescritpion.Text = projectData.ShortDescription;
            this.TextBoxProjectLongDescription.Text = projectData.DetailedDescription;
            try
            {
                this.ImageProjectLogo.Load(projectData.ImageURL);
            }
            catch
            {
                this.ImageProjectLogo.Load("resources/X.png");
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

        private void ButtonChangeProjectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageProjectLogo.Load(openFileDialog1.FileName);
            }

            if (!ImageProjectLogo.ImageLocation.Equals(projectData.ImageURL))
            {
                ProjectLogo.BackColor = Color.Yellow;
            }
        }

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

        private void ButtonUpdateProjectDetails_Click(object sender, EventArgs e)
        {

            String t1=projectData.Title, t2=projectData.ShortDescription, t3=projectData.DetailedDescription, t4=projectData.ImageURL;
            projectData.Title = this.TextBoxProjectTitle.Text;
            projectData.ShortDescription = this.TextBoxProjectShortDescritpion.Text;
            projectData.DetailedDescription=this.TextBoxProjectLongDescription.Text;
            projectData.ImageURL = this.ImageProjectLogo.ImageLocation;
            ///No way to copy- need to check if inserted first than change the projectData variable
            if (!d.UpdateProject(projectData))
            {
                //reverse changes

                projectData.Title = t1;
                projectData.ShortDescription =t2;
                projectData.DetailedDescription =t3;
                projectData.ImageURL =t4;
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
    }
}
