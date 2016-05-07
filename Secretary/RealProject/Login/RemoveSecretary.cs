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
    public partial class RemoveSecretary : Form
    {
        int ID;
        DatabaseHandler db = new DatabaseHandler();
        public RemoveSecretary(int id)
        {
            InitializeComponent();
            ID = id;
            textBoxFirstName.Text = db.getFirstNameSecretary(ID);
            textBoxLastName.Text = db.getLastNameSecretary(ID);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = db.getFirstNameSecretary(ID);
            textBoxLastName.Text = db.getLastNameSecretary(ID);
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
            db.updateReasonForLeavingSecretary(ID, reasonforleaving);
            db.updateRejoinDesirabilitySecretary(ID, rejoindesirability);
            db.updateLeaveDateSecretary(ID, leavedate);
            db.updateObservationsSecretary(ID, observations);
            MessageBox.Show("Succsessfully updated!");

        }
    }
}
