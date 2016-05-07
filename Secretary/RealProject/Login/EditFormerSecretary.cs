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
    public partial class EditFormerSecretary : Form
    {
        int ID;
        DatabaseHandler db = new DatabaseHandler();
        public EditFormerSecretary(int id)
        {
            InitializeComponent();
            ID = id;
            textBoxId.Text = ID.ToString();
            textBoxFirstName.Text = db.getFirstNameSecretary(ID);
            textBoxLastName.Text = db.getLastNameSecretary(ID);
            textBoxDisplayName.Text = db.getDisplayNameSecretary(ID);
            textBoxAvatarLink.Text = db.getAvatarLinkSecretary(ID);
            textBoxPassword.Text = db.getPasswordSecretary(ID);
            textBoxEmail.Text = db.getEmailSecretary(ID);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(ID);
            dateTimePicker.Value = db.getJoinDateSecretary(ID);
            textBoxWorkStatus.Text = db.getStatusSecretary(ID);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(ID);
            dateTimePicker2.Value = db.getLeaveDateSecretary(ID);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingSecretary(ID);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilitySecretary(ID);
            textBoxObservations.Text = db.getObservationsSecretary(ID);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Text = ID.ToString();
            textBoxFirstName.Text = db.getFirstNameSecretary(ID);
            textBoxLastName.Text = db.getLastNameSecretary(ID);
            textBoxDisplayName.Text = db.getDisplayNameSecretary(ID);
            textBoxAvatarLink.Text = db.getAvatarLinkSecretary(ID);
            textBoxPassword.Text = db.getPasswordSecretary(ID);
            textBoxEmail.Text = db.getEmailSecretary(ID);
            textBoxPhoneNumber.Text = db.getPhoneNumberSecretary(ID);
            dateTimePicker.Value = db.getJoinDateSecretary(ID);
            textBoxWorkStatus.Text = db.getStatusSecretary(ID);
            textBoxPersonalNotes.Text = db.getPersonalNotesSecretary(ID);
            dateTimePicker2.Value = db.getLeaveDateSecretary(ID);
            textBoxReasonForLeaving.Text = db.getReasonForLeavingSecretary(ID);
            textBoxRejoinDesirability.Text = db.getRejoinDesirabilitySecretary(ID);
            textBoxObservations.Text = db.getObservationsSecretary(ID);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string displayname = textBoxDisplayName.Text;
            string avatarlink = textBoxAvatarLink.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            DateTime joindate = dateTimePicker.Value.Date;
            string workstatus = textBoxWorkStatus.Text;
            string personalnotes = textBoxPersonalNotes.Text;
            DateTime leavedate = dateTimePicker2.Value.Date;
            string reasonforleaving = textBoxReasonForLeaving.Text;
            string rejoindesirability = textBoxRejoinDesirability.Text;
            string observations = textBoxObservations.Text;
            if (reasonforleaving != null && rejoindesirability != null && observations != null && lastname != null && displayname != null && avatarlink != null && password != null && email != null && phonenumber != null && workstatus != null && personalnotes != null)
            {
                db.updateFirstNameSecretary(ID, firstname);
                db.updateLastNameSecretary(ID, lastname);
                db.updateDisplayNameSecretary(ID, displayname);
                db.updateAvatarLinkSecretary(ID, avatarlink);
                db.updatePasswordSecretary(ID, password);
                db.updateEmailSecretary(ID, email);
                db.updatePhoneNumberSecretary(ID, phonenumber);
                db.updateJoinDateSecretary(ID, joindate);
                db.updateStatusSecretary(ID, workstatus);
                db.updatePersonalNotesSecretary(ID, personalnotes);
                db.updateLeaveDateSecretary(ID, leavedate);
                db.updateReasonForLeavingSecretary(ID, reasonforleaving);
                db.updateRejoinDesirabilitySecretary(ID, rejoindesirability);
                db.updateObservationsSecretary(ID, observations);
                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Please fill all fields!");

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
