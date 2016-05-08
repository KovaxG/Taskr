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
    public partial class AsignTaskWindows : Form
    {
        public AsignTaskWindows(DatabaseHandler d,TeamLeader teamLeader,ProjectData projectData, UserData userData)
        {
            InitializeComponent();

            List<TaskData> taskDataList = d.GetTasksForProject(projectData);
            foreach (TaskData taskData in taskDataList)
            {
                this.flowLayoutPanelTasks.Controls.Add(new PanelItemTasksFromLeader(d,taskData,teamLeader,userData,this));
            }
        }
    }
}
