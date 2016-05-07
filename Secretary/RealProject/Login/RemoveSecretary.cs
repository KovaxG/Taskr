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
        int secretary_id;
        DatabaseHandler db = new DatabaseHandler();
        VerifyText verify_text = new VerifyText();
        
        // Constructor
        public RemoveSecretary(int id)
        {
            InitializeComponent();
            secretary_id = id;
            textBoxFirstName.Text = db.getFirstNameSecretary(secretary_id);
            textBoxLastName.Text = db.getLastNameSecretary(secretary_id);
        }

        // Cancel button
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Reset button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = db.getFirstNameSecretary(secretary_id);
            textBoxLastName.Text = db.getLastNameSecretary(secretary_id);
            textBoxReasonForLeaving.Text = "";
            textBoxRejoinDesirability.Text = "";
            textBoxObservations.Text = "";
            dateTimePickerLeaveDate.Value = DateTime.Now;
        }

        // Accept button
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string reasonforleaving = textBoxReasonForLeaving.Text;
            string rejoindesirability = textBoxRejoinDesirability.Text;
            string observations = textBoxObservations.Text;
            DateTime leavedate = dateTimePickerLeaveDate.Value;
            bool ok = true;

            // Verify reason for leaving
            if (verify_text.IsInjection(reasonforleaving) || !verify_text.HasOnlyLetters(reasonforleaving))
            {
                labelReasonForLeaving.Show();
                labelReasonForLeaving.Text = "Please insert only letters ";
                labelReasonForLeaving.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelReasonForLeaving.Hide();
            }

            // Verify rejoin desirability
            if (verify_text.IsInjection(rejoindesirability) || !verify_text.HasOnlyLetters(rejoindesirability))
            {
                labelRejoinDesirability.Show();
                labelRejoinDesirability.Text = "Please insert only letters ";
                labelRejoinDesirability.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelRejoinDesirability.Hide();
            }

            // Verify observations
            if (verify_text.IsInjection(observations))
            {
                labelObservations.Show();
                labelObservations.Text = "Please don't use SQL injection characters like ' or \\";
                labelObservations.ForeColor = System.Drawing.Color.Red;
                ok = false;
            }
            else
            {
                labelObservations.Hide();
            }

            // If all data is correct
            if (ok == true)
            {
                db.updateReasonForLeavingSecretary(secretary_id, reasonforleaving);
                db.updateRejoinDesirabilitySecretary(secretary_id, rejoindesirability);
                db.updateLeaveDateSecretary(secretary_id, leavedate);
                db.updateObservationsSecretary(secretary_id, observations);
                MessageBox.Show("Succsessfully updated!");
                this.Close();
            }
        }
    }
}
