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
    public partial class EditSecretary : Form
    {
        int ID;
        DatabaseHandler db = new DatabaseHandler();
        public EditSecretary(int id)
        {
            ID = id;
            InitializeComponent();
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
            if (firstname != null && lastname != null && displayname != null && avatarlink != null && password != null && email != null && phonenumber != null && workstatus != null && personalnotes != null)
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
