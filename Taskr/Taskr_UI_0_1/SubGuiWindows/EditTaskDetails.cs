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
        private TaskData td;
        private DatabaseHandler d;
        public EditTaskDetails(DatabaseHandler d, TaskData td)
        {
            this.d = d;
            this.td = td;

            
            InitializeComponent();
        }
    }
}
