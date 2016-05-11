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
using Taskr_UI_0_1.GUISubElements;

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
                if (taskData.CompletedBy == 0 && d.GetUserWorkingOnTask(taskData)==null)
                {
                    this.flowLayoutPanelTasks.Controls.Add(new PanelItemTasksFromSelector(d,taskData,teamLeader,userData,this));
                }
            }
        }
    }
}
