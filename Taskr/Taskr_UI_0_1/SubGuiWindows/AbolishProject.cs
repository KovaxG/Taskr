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
    public partial class AbolishProject : Form
    {
        public AbolishProject(ProjectData projectData)
        {
            InitializeComponent();
            this.Text=this.Text.Replace("<title>",projectData.Title);
            this.labelProjectTitle.Text = this.labelProjectTitle.Text.Replace("<title>", projectData.Title);
           
        }

        public DialogResult ShowDialog(out string s)
        {
            DialogResult temp= ShowDialog();
            s = this.textBoxReason.Text;
            return temp;

        }
        private void buttonAbolish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
