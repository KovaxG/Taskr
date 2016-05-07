using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class RemoveEmployee : Form
    {
        int ID;
        DatabaseHandler db = new DatabaseHandler();
        public RemoveEmployee(int id)
        {
            InitializeComponent();
            ID = id;
            textBoxFirstName.Text = db.getFirstNameUser(ID);
            textBoxLastName.Text = db.getLastNameUser(ID);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = db.getFirstNameUser(ID);
            textBoxLastName.Text = db.getLastNameUser(ID);
            textBoxReasonForLeaving.Text = "";
            textBoxRejoinDesirability.Text = "";
            textBoxObservatios.Text = "";
            dateTimePickerLeaveDate.Value = DateTime.Now;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string reasonforleaving = textBoxReasonForLeaving.Text;
            string rejoindesirability = textBoxRejoinDesirability.Text;
            string observations = textBoxObservatios.Text;
            DateTime leavedate = dateTimePickerLeaveDate.Value;
            db.updateReasonForLeavingUser(ID, reasonforleaving);
            db.updateRejoinDesirabilityUser(ID, rejoindesirability);
            db.updateLeaveDateUser(ID, leavedate);
            db.updateObservationsUser(ID, observations);
            db.deleteProjectRequestUser(ID);
            db.deleteTaskRequestUser(ID);
            db.deleteFromActiveProject(ID);
            db.deleteFromActiveTask(ID);
            MessageBox.Show("Succsessfully updated!");
        }
    }
}
